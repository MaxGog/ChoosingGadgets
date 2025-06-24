using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using ChoosingGadgets.Models;
using HtmlAgilityPack;

using Device = ChoosingGadgets.Models.Device;
using DeviceType = ChoosingGadgets.Models.DeviceType;

namespace ChoosingGadgets.Services;

public class ParserService
{
    private readonly HttpClient _httpClient;
    private readonly Random _random;

    public ParserService()
    {
        _httpClient = new HttpClient(new HttpClientHandler
        {
            AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
        });
        
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
        _httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
        _httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
        _httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
        
        _random = new Random();
    }

    public async Task<List<Device>> ParseDevicesFromWeb(DeviceType deviceType, string sourceUrl)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(sourceUrl))
                return [];

            await Task.Delay(_random.Next(1000, 3000));

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
        try
        {
            var html = await _httpClient.GetStringAsync(url);
            var computers = new List<Computer>();
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var products = doc.DocumentNode.SelectNodes("//div[contains(@class, 'catalog-product') and contains(@class, 'ui-col')]");

            if (products == null) 
            {
                Debug.WriteLine("Не найдены продукты на странице DNS Shop");
                return computers.Cast<Device>().ToList();
            }

            foreach (var product in products)
            {
                try
                {
                    var nameNode = product.SelectSingleNode(".//a[contains(@class, 'catalog-product__name')]");
                    var priceNode = product.SelectSingleNode(".//div[contains(@class, 'product-buy__price')]");
                    var imageNode = product.SelectSingleNode(".//img[contains(@class, 'catalog-product__image')]");
                    var linkNode = product.SelectSingleNode(".//a[contains(@class, 'catalog-product__name')]");

                    if (nameNode == null || priceNode == null) 
                    {
                        Debug.WriteLine("Не найдены название или цена продукта");
                        continue;
                    }

                    var computer = new Computer
                    {
                        Name = HtmlEntity.DeEntitize(nameNode.InnerText).Trim(),
                        Price = ExtractPrice(priceNode.InnerText.Trim()),
                        Manufacturer = ExtractManufacturer(nameNode.InnerText.Trim()),
                        ImageUrl = imageNode?.GetAttributeValue("src", "") ?? string.Empty,
                        SourceUrl = "https://www.dns-shop.ru" + (linkNode?.GetAttributeValue("href", "") ?? string.Empty),
                        Type = DeviceType.Computer
                    };

                    var specs = product.SelectNodes(".//div[contains(@class, 'catalog-product__properties')]//li");
                    if (specs != null)
                    {
                        foreach (var spec in specs)
                        {
                            var text = HtmlEntity.DeEntitize(spec.InnerText).Trim();
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
                    Debug.WriteLine($"Ошибка парсинга продукта DNS Shop: {ex.Message}");
                }
            }

            return computers.Cast<Device>().ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Ошибка парсинга DNS Shop: {ex.Message}");
            return new List<Device>();
        }
    }

    private async Task<List<Device>> ParseCitilinkComputers(string url)
    {
        try
        {
            var html = await _httpClient.GetStringAsync(url);
            var computers = new List<Computer>();
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var products = doc.DocumentNode.SelectNodes("//article[contains(@class, 'ProductCard')]");

            if (products == null) 
            {
                Debug.WriteLine("Не найдены продукты на странице Citilink");
                return computers.Cast<Device>().ToList();
            }

            foreach (var product in products)
            {
                try
                {
                    var nameNode = product.SelectSingleNode(".//a[contains(@class, 'ProductCard__name')]");
                    var priceNode = product.SelectSingleNode(".//span[contains(@class, 'ProductCard__price_current-price')]");
                    var imageNode = product.SelectSingleNode(".//img[contains(@class, 'ProductCard__image')]");
                    var linkNode = product.SelectSingleNode(".//a[contains(@class, 'ProductCard__name')]");

                    if (nameNode == null || priceNode == null) 
                    {
                        Debug.WriteLine("Не найдены название или цена продукта");
                        continue;
                    }

                    var computer = new Computer
                    {
                        Name = HtmlEntity.DeEntitize(nameNode.InnerText).Trim(),
                        Price = ExtractPrice(priceNode.InnerText.Trim()),
                        Manufacturer = ExtractManufacturer(nameNode.InnerText.Trim()),
                        ImageUrl = imageNode?.GetAttributeValue("src", "") ?? string.Empty,
                        SourceUrl = "https://www.citilink.ru" + (linkNode?.GetAttributeValue("href", "") ?? string.Empty),
                        Type = DeviceType.Computer
                    };

                    computers.Add(computer);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Ошибка парсинга продукта Citilink: {ex.Message}");
                }
            }

            return computers.Cast<Device>().ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Ошибка парсинга Citilink: {ex.Message}");
            return new List<Device>();
        }
    }

    private async Task<List<Device>> ParseGsmArenaSmartphones(string url)
    {
        try
        {
            var html = await _httpClient.GetStringAsync(url);
            var smartphones = new List<Smartphone>();
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var products = doc.DocumentNode.SelectNodes("//div[contains(@class, 'makers')]//li");

            if (products == null) 
            {
                Debug.WriteLine("Не найдены продукты на странице GSMArena");
                return smartphones.Cast<Device>().ToList();
            }

            foreach (var product in products)
            {
                try
                {
                    var nameNode = product.SelectSingleNode(".//strong//span");
                    var imageNode = product.SelectSingleNode(".//img");
                    var linkNode = product.SelectSingleNode(".//a");

                    if (nameNode == null) 
                    {
                        Debug.WriteLine("Не найдено название продукта");
                        continue;
                    }

                    var smartphone = new Smartphone
                    {
                        Name = HtmlEntity.DeEntitize(nameNode.InnerText).Trim(),
                        Manufacturer = imageNode?.GetAttributeValue("title", "").Split(' ')[0] ?? "Unknown",
                        ImageUrl = imageNode?.GetAttributeValue("src", "") ?? string.Empty,
                        SourceUrl = "https://www.gsmarena.com/" + (linkNode?.GetAttributeValue("href", "") ?? string.Empty),
                        Type = DeviceType.Smartphone
                    };

                    smartphones.Add(smartphone);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Ошибка парсинга продукта GSMArena: {ex.Message}");
                }
            }

            return smartphones.Cast<Device>().ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Ошибка парсинга GSMArena: {ex.Message}");
            return new List<Device>();
        }
    }

    private async Task<List<Device>> ParseWildberriesSmartphones(string url)
    {
        try
        {
            var html = await _httpClient.GetStringAsync(url);
            var smartphones = new List<Smartphone>();
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var products = doc.DocumentNode.SelectNodes("//article[contains(@class, 'product-card') and @data-nm-id]");

            if (products == null) 
            {
                Debug.WriteLine("Не найдены продукты на странице Wildberries");
                return smartphones.Cast<Device>().ToList();
            }

            foreach (var product in products)
            {
                try
                {
                    var nameNode = product.SelectSingleNode(".//span[contains(@class, 'product-card__name')]");
                    var priceNode = product.SelectSingleNode(".//ins[contains(@class, 'price__lower-price')] | .//span[contains(@class, 'price__lower-price')]");
                    var imageNode = product.SelectSingleNode(".//img[contains(@class, 'j-thumbnail')]");
                    var linkNode = product.SelectSingleNode(".//a[contains(@class, 'product-card__link')]");

                    if (nameNode == null || priceNode == null) 
                    {
                        Debug.WriteLine("Не найдены название или цена продукта");
                        continue;
                    }

                    var smartphone = new Smartphone
                    {
                        Name = HtmlEntity.DeEntitize(nameNode.InnerText).Trim(),
                        Price = ExtractPrice(priceNode.InnerText.Trim()),
                        Manufacturer = ExtractManufacturer(nameNode.InnerText.Trim()),
                        ImageUrl = "https:" + (imageNode?.GetAttributeValue("src", "") ?? string.Empty),
                        SourceUrl = "https://www.wildberries.ru" + (linkNode?.GetAttributeValue("href", "") ?? string.Empty),
                        Type = DeviceType.Smartphone
                    };

                    smartphones.Add(smartphone);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Ошибка парсинга продукта Wildberries: {ex.Message}");
                }
            }

            return smartphones.Cast<Device>().ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Ошибка парсинга Wildberries: {ex.Message}");
            return new List<Device>();
        }
    }

    #region Helper Methods

    private decimal ExtractPrice(string priceText)
    {
        try
        {
            var match = Regex.Match(priceText, @"[\d\s]+(?:\.[\d\s]+)?");
            if (match.Success)
            {
                var digits = Regex.Replace(match.Value, @"[^\d]", "");
                return decimal.Parse(digits) / (digits.Length > 2 ? 100m : 1m);
            }
            return 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Ошибка извлечения цены: {ex.Message}");
            return 0;
        }
    }

    private string ExtractManufacturer(string productName)
    {
        try
        {
            var manufacturers = new[] { "Apple", "Samsung", "Xiaomi", "Huawei", "Honor", "Lenovo", "Asus", "Acer", "HP", "Dell", "MSI", "Realme", "OPPO", "Vivo", "OnePlus", "Google", "Nokia", "Sony" };
            return manufacturers.FirstOrDefault(m => productName.StartsWith(m, StringComparison.OrdinalIgnoreCase) || productName.Contains(m)) ?? "Other";
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Ошибка извлечения производителя: {ex.Message}");
            return "Unknown";
        }
    }

    private int ExtractRAM(string ramText)
    {
        try
        {
            var match = Regex.Match(ramText, @"(\d+)\s*(GB|ГБ)", RegexOptions.IgnoreCase);
            return match.Success ? int.Parse(match.Groups[1].Value) : 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Ошибка извлечения RAM: {ex.Message}");
            return 0;
        }
    }

    #endregion
}