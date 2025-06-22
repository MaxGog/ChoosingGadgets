using ChoosingGadgets.Models;
using HtmlAgilityPack;
using System.Net;

namespace ChoosingGadgets.Services;
public class YandexMarketParser
{
    public async Task<List<YandexMarketLaptop>> ParseLaptopsAsync()
    {
        var laptops = new List<YandexMarketLaptop>();

        try
        {
            var url = "https://market.yandex.ru/catalog--noutbuki/54544/list?hid=91013&allowCollapsing=1";
            var web = new HtmlWeb();
            var doc = await web.LoadFromWebAsync(url);

            var productNodes = doc.DocumentNode.SelectNodes("//article[contains(@data-autotest-id, 'product-snippet')]");

            if (productNodes != null)
            {
                foreach (var node in productNodes.Take(10))
                {
                    var laptop = new YandexMarketLaptop();

                    var titleNode = node.SelectSingleNode(".//h3[contains(@data-zone-name, 'title')]");
                    laptop.Title = titleNode?.InnerText.Trim() ?? "Название не указано";

                    var priceNode = node.SelectSingleNode(".//span[contains(@data-zone-name, 'price')]//span[1]");
                    laptop.Price = priceNode?.InnerText.Trim() ?? "Цена не указана";

                    var imageNode = node.SelectSingleNode(".//img[contains(@data-zone-name, 'picture')]");
                    laptop.ImageUrl = imageNode?.GetAttributeValue("src", "") ?? "";

                    var linkNode = node.SelectSingleNode(".//a[contains(@data-zone-name, 'title')]");
                    laptop.ProductUrl = linkNode?.GetAttributeValue("href", "") ?? "";
                    if (!string.IsNullOrEmpty(laptop.ProductUrl) && !laptop.ProductUrl.StartsWith("http"))
                    {
                        laptop.ProductUrl = "https://market.yandex.ru" + laptop.ProductUrl;
                    }

                    var ratingNode = node.SelectSingleNode(".//div[contains(@data-zone-name, 'rating')]//span");
                    laptop.Rating = ratingNode?.InnerText.Trim() ?? "Рейтинг не указан";

                    laptops.Add(laptop);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка парсинга: {ex.Message}");
        }

        return laptops;
    }
}