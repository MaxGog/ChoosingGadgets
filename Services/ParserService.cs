using System.Diagnostics;
using System.Text.RegularExpressions;
using ChoosingGadgets.Models;
using HtmlAgilityPack;

using Device = ChoosingGadgets.Models.Device;
using DeviceType = ChoosingGadgets.Models.DeviceType;

namespace ChoosingGadgets.Services;

public class ParserService
{
    private readonly HttpClient _httpClient;

    public ParserService()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
    }

    public async Task<List<Device>> ParseDevicesFromWeb(DeviceType deviceType, string sourceUrl)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(sourceUrl))
                return [];

            if (sourceUrl.Contains("dns-shop.ru") && deviceType == DeviceType.Computer)
                return await ParseDnsShopComputers(sourceUrl);
            else if (sourceUrl.Contains("citilink.ru") && deviceType == DeviceType.Computer)
                return await ParseCitilinkComputers(sourceUrl);
            else if (sourceUrl.Contains("gsmarena.com") && deviceType == DeviceType.Smartphone)
                return await ParseGsmArenaSmartphones(sourceUrl);
            else if (sourceUrl.Contains("wildberries.ru") && deviceType == DeviceType.Smartphone)
                return await ParseWildberriesSmartphones(sourceUrl);

            return new List<Device>();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Ошибка парсинга: {ex.Message}");
            return new List<Device>();
        }
    }

    private async Task<List<Device>> ParseDnsShopComputers(string url)
    {
        var html = await _httpClient.GetStringAsync(url);
        var computers = new List<Computer>();
        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        var products = doc.DocumentNode.SelectNodes("//div[contains(@class, 'catalog-product')]");

        if (products == null) return computers.Cast<Device>().ToList();

        foreach (var product in products)
        {
            try
            {
                var nameNode = product.SelectSingleNode(".//a[contains(@class, 'catalog-product__name')]");
                var priceNode = product.SelectSingleNode(".//div[contains(@class, 'product-buy__price')]");
                var imageNode = product.SelectSingleNode(".//img[contains(@class, 'catalog-product__image')]");
                var linkNode = product.SelectSingleNode(".//a[contains(@class, 'catalog-product__name')]");

                if (nameNode == null || priceNode == null) continue;

                var computer = new Computer
                {
                    Name = nameNode.InnerText.Trim(),
                    Price = ExtractPrice(priceNode.InnerText.Trim()),
                    Manufacturer = ExtractManufacturer(nameNode.InnerText.Trim()),
                    ImageUrl = imageNode?.GetAttributeValue("src", "") ?? string.Empty,
                    SourceUrl = "https://www.dns-shop.ru" + linkNode?.GetAttributeValue("href", ""),
                    Type = DeviceType.Computer
                };

                var specs = product.SelectNodes(".//div[contains(@class, 'catalog-product__properties')]//li");
                if (specs != null)
                {
                    foreach (var spec in specs)
                    {
                        var text = spec.InnerText.Trim();
                        if (text.Contains("Процессор"))
                            computer.Processor = text.Split(':').LastOrDefault()?.Trim();
                        else if (text.Contains("Память"))
                            computer.RAM = ExtractRAM(text);
                        else if (text.Contains("Видеокарта"))
                            computer.GPU = text.Split(':').LastOrDefault()?.Trim();
                    }
                }

                computers.Add(computer);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка парсинга продукта: {ex.Message}");
            }
        }

        return computers.Cast<Device>().ToList();
    }

    private async Task<List<Device>> ParseCitilinkComputers(string url)
    {
        var html = await _httpClient.GetStringAsync(url);
        var computers = new List<Computer>();
        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        var products = doc.DocumentNode.SelectNodes("//div[contains(@class, 'product_data__gtm-js')]");

        if (products == null) return computers.Cast<Device>().ToList();

        foreach (var product in products)
        {
            try
            {
                var nameNode = product.SelectSingleNode(".//a[contains(@class, 'ProductCardHorizontal__title')]");
                var priceNode = product.SelectSingleNode(".//span[contains(@class, 'ProductCardHorizontal__price_current-price')]");
                var imageNode = product.SelectSingleNode(".//img[contains(@class, 'ProductCardHorizontal__image')]");
                var linkNode = product.SelectSingleNode(".//a[contains(@class, 'ProductCardHorizontal__title')]");

                if (nameNode == null || priceNode == null) continue;

                var computer = new Computer
                {
                    Name = nameNode.InnerText.Trim(),
                    Price = ExtractPrice(priceNode.InnerText.Trim()),
                    Manufacturer = ExtractManufacturer(nameNode.InnerText.Trim()),
                    ImageUrl = imageNode?.GetAttributeValue("src", "") ?? string.Empty,
                    SourceUrl = "https://www.citilink.ru" + linkNode?.GetAttributeValue("href", ""),
                    Type = DeviceType.Computer
                };

                computers.Add(computer);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка парсинга продукта: {ex.Message}");
            }
        }

        return computers.Cast<Device>().ToList();
    }

    private async Task<List<Device>> ParseGsmArenaSmartphones(string url)
    {
        var html = await _httpClient.GetStringAsync(url);
        var smartphones = new List<Smartphone>();
        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        var products = doc.DocumentNode.SelectNodes("//div[contains(@class, 'makers')]//li");

        if (products == null) return smartphones.Cast<Device>().ToList();

        foreach (var product in products)
        {
            try
            {
                var nameNode = product.SelectSingleNode(".//strong//span");
                var imageNode = product.SelectSingleNode(".//img");
                var linkNode = product.SelectSingleNode(".//a");

                if (nameNode == null) continue;

                var smartphone = new Smartphone
                {
                    Name = nameNode.InnerText.Trim(),
                    Manufacturer = imageNode?.GetAttributeValue("title", "").Split(' ')[0] ?? "Unknown",
                    ImageUrl = imageNode?.GetAttributeValue("src", "") ?? string.Empty,
                    SourceUrl = "https://www.gsmarena.com/" + linkNode?.GetAttributeValue("href", ""),
                    Type = DeviceType.Smartphone
                };

                smartphones.Add(smartphone);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка парсинга продукта: {ex.Message}");
            }
        }

        return smartphones.Cast<Device>().ToList();
    }

    private async Task<List<Device>> ParseWildberriesSmartphones(string url)
    {
        var html = await _httpClient.GetStringAsync(url);
        var smartphones = new List<Smartphone>();
        var doc = new HtmlDocument();
        doc.LoadHtml(html);

        var products = doc.DocumentNode.SelectNodes("//article[contains(@class, 'product-card')]");

        if (products == null) return smartphones.Cast<Device>().ToList();

        foreach (var product in products)
        {
            try
            {
                var nameNode = product.SelectSingleNode(".//span[contains(@class, 'product-card__name')]");
                var priceNode = product.SelectSingleNode(".//ins[contains(@class, 'price__lower-price')]");
                var imageNode = product.SelectSingleNode(".//img[contains(@class, 'j-thumbnail')]");
                var linkNode = product.SelectSingleNode(".//a[contains(@class, 'product-card__link')]");

                if (nameNode == null || priceNode == null) continue;

                var smartphone = new Smartphone
                {
                    Name = nameNode.InnerText.Trim(),
                    Price = ExtractPrice(priceNode.InnerText.Trim()),
                    Manufacturer = ExtractManufacturer(nameNode.InnerText.Trim()),
                    ImageUrl = "https:" + (imageNode?.GetAttributeValue("src", "") ?? string.Empty),
                    SourceUrl = "https://www.wildberries.ru" + linkNode?.GetAttributeValue("href", ""),
                    Type = DeviceType.Smartphone
                };

                smartphones.Add(smartphone);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка парсинга продукта: {ex.Message}");
            }
        }

        return smartphones.Cast<Device>().ToList();
    }

    #region Helper Methods

    private decimal ExtractPrice(string priceText)
    {
        try
        {
            var digits = Regex.Replace(priceText, @"[^\d]", "");
            return decimal.Parse(digits) / (digits.Length > 2 ? 100m : 1m);
        }
        catch
        {
            return 0;
        }
    }

    private string ExtractManufacturer(string productName)
    {
        var manufacturers = new[] { "Apple", "Samsung", "Xiaomi", "Huawei", "Lenovo", "Asus", "Acer", "HP", "Dell", "MSI" };
        return manufacturers.FirstOrDefault(m => productName.Contains(m)) ?? "Other";
    }

    private int ExtractRAM(string ramText)
    {
        var match = Regex.Match(ramText, @"(\d+)\s*GB");
        return match.Success ? int.Parse(match.Groups[1].Value) : 0;
    }

    #endregion
}