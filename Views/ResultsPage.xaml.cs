using ChoosingGadgets.Models;
using ChoosingGadgets.Repositories;
using ChoosingGadgets.ViewModels;
using Microsoft.Extensions.Logging;

namespace ChoosingGadgets.Views;

public partial class ResultsPage : ContentPage
{
    private readonly UserPreferences _preferences;
    private readonly DeviceRepository _deviceRepository;
    private readonly ILogger<ResultsPage> _logger;
    private readonly bool _useDatabase;

    public ResultsPage(UserPreferences preferences,
                     DeviceRepository deviceRepository,
                     ILogger<ResultsPage> logger,
                     bool useDatabase = true)
    {
        InitializeComponent();
        _preferences = preferences;
        _deviceRepository = deviceRepository;
        _logger = logger;
        _useDatabase = useDatabase;

        LoadRecommendations();
    }

    private async void LoadRecommendations()
    {
        try
        {
            IsBusy = true;
            DevicesCollection.IsVisible = false;
            LoadingIndicator.IsRunning = true;

            var viewModel = new ResultsViewModel(_preferences, _deviceRepository, _useDatabase);
            await viewModel.LoadRecommendations();

            if (viewModel.RecommendedDevices.Count == 0)
            {
                RecommendationLabel.Text = "Не найдено компьютеров, соответствующих вашим критериям. " +
                                        "Вот общие рекомендации:";

                var genericViewModel = new ResultsViewModel(_preferences, _deviceRepository, false);
                await genericViewModel.LoadRecommendations();
                DevicesCollection.ItemsSource = genericViewModel.RecommendedDevices;
            }
            else
            {
                RecommendationLabel.Text = GetRecommendationText(_preferences);
                DevicesCollection.ItemsSource = viewModel.RecommendedDevices;
            }

            DevicesCollection.IsVisible = true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при загрузке рекомендаций");
            await DisplayAlert("Ошибка",
                "Произошла ошибка при загрузке данных. Показаны общие рекомендации.",
                "OK");

            var genericViewModel = new ResultsViewModel(_preferences, _deviceRepository, false);
            await genericViewModel.LoadRecommendations();
            DevicesCollection.ItemsSource = genericViewModel.RecommendedDevices;
            DevicesCollection.IsVisible = true;
        }
        finally
        {
            LoadingIndicator.IsRunning = false;
            IsBusy = false;
        }
    }

    private string GetRecommendationText(UserPreferences preferences)
    {
        string baseText = preferences.PrimaryUse switch
        {
            "gaming" => "Игровые компьютеры",
            "design" => "Рабочие станции для дизайна",
            "video" => "Системы для видеомонтажа",
            "programming" => "Компьютеры для разработки",
            "office" => "Офисные компьютеры",
            _ => "Рекомендуемые компьютеры"
        };

        string formFactor = preferences.FormFactor switch
        {
            0 => " (настольные ПК)",
            1 => " (ноутбуки)",
            2 => " (мини-ПК)",
            3 => " (моноблоки)",
            _ => ""
        };

        return $"{baseText}{formFactor} для вашего бюджета:";
    }

    private async void OnDeviceSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Computer selectedComputer)
        {
            var message = new System.Text.StringBuilder();
            message.AppendLine($"**{selectedComputer.Name}**");
            message.AppendLine($"Производитель: {selectedComputer.Manufacturer}");
            message.AppendLine($"Модель: {selectedComputer.Model}");
            message.AppendLine($"Цена: {selectedComputer.Price:N0} ₽");
            message.AppendLine();
            message.AppendLine("**Характеристики:**");
            message.AppendLine($"- Процессор: {selectedComputer.Processor}");
            message.AppendLine($"- Видеокарта: {selectedComputer.GPU}");
            message.AppendLine($"- Оперативная память: {selectedComputer.RAM} GB");
            message.AppendLine($"- Накопитель: {selectedComputer.Storage}");
            message.AppendLine($"- ОС: {selectedComputer.OS}");

            if (!string.IsNullOrEmpty(selectedComputer.FormFactor))
                message.AppendLine($"- Форм-фактор: {selectedComputer.FormFactor}");

            await DisplayAlert("Подробная информация", message.ToString(), "OK");
        }

        if (sender is CollectionView collectionView)
            collectionView.SelectedItem = null;
    }
    
    private async void OnDnsClicked(object sender, EventArgs e)
    {
        await OpenStoreWithFilters("DNS");
    }

    private async void OnMVideoClicked(object sender, EventArgs e)
    {
        await OpenStoreWithFilters("MVideo");
    }

    private async void OnEldoradoClicked(object sender, EventArgs e)
    {
        await OpenStoreWithFilters("Eldorado");
    }

    private async Task OpenStoreWithFilters(string store)
    {
        try
        {
            var filters = BuildStoreFilters(_preferences);
            string url = store switch
            {
                "DNS" => BuildDnsUrl(filters),
                "MVideo" => BuildMVideoUrl(filters),
                "Eldorado" => BuildEldoradoUrl(filters),
                _ => throw new ArgumentException("Unknown store")
            };

            await Launcher.OpenAsync(new Uri(url));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Ошибка при открытии магазина {store}");
            await DisplayAlert("Ошибка", $"Не удалось открыть магазин {store}", "OK");
        }
    }

    private Dictionary<string, string> BuildStoreFilters(UserPreferences preferences)
    {
        var filters = new Dictionary<string, string>();

        filters["min_price"] = preferences.Budget switch
        {
            1 => "0",
            2 => "50000",
            3 => "100000",
            4 => "150000",
            5 => "200000",
            _ => "0"
        };

        filters["max_price"] = preferences.Budget switch
        {
            1 => "50000",
            2 => "100000",
            3 => "150000",
            4 => "200000",
            5 => "300000",
            _ => "100000"
        };

        filters["type"] = preferences.FormFactor switch
        {
            0 => "desktop",
            1 => "laptop",
            2 => "mini",
            3 => "allinone",
            _ => "desktop"
        };

        filters["ram"] = preferences.PrimaryUse switch
        {
            "gaming" => "32",
            "design" or "video" => "64",
            "programming" => "32",
            _ => "16"
        };

        filters["cpu"] = preferences.PrimaryUse switch
        {
            "gaming" => "i5|i7|ryzen5|ryzen7",
            "design" or "video" => "i7|i9|ryzen7|ryzen9",
            _ => "i3|i5|ryzen3|ryzen5"
        };

        if (preferences.PrimaryUse == "gaming" || 
            preferences.PrimaryUse == "design" || 
            preferences.PrimaryUse == "video")
        {
            filters["gpu"] = "dedicated";
        }

        return filters;
    }

    private string BuildDnsUrl(Dictionary<string, string> filters)
    {
        string baseUrl = filters["type"] switch
        {
            "desktop" => "https://www.dns-shop.ru/catalog/17a899cd16404e77/kompyutery/",
            "laptop" => "https://www.dns-shop.ru/catalog/17a892f816404e77/noutbuki/",
            "allinone" => "https://www.dns-shop.ru/catalog/17a89c3416404e77/monobloki/",
            "mini" => "https://www.dns-shop.ru/catalog/17a89c0f16404e77/mini-pk/",
            _ => "https://www.dns-shop.ru/catalog/17a899cd16404e77/kompyutery/"
        };

        var queryParams = new List<string>
        {
            $"price={filters["min_price"]}-{filters["max_price"]}",
            $"f[svobnaya-operativka]={filters["ram"]}gb-999gb"
        };

        if (filters.ContainsKey("cpu"))
        {
            queryParams.Add($"f[proczessor]={Uri.EscapeDataString(filters["cpu"])}");
        }

        if (filters.ContainsKey("gpu"))
        {
            queryParams.Add("f[videokarta]=discretnaya");
        }

        return $"{baseUrl}?{string.Join("&", queryParams)}";
    }

    private string BuildMVideoUrl(Dictionary<string, string> filters)
    {
        string category = filters["type"] switch
        {
            "desktop" => "kompiutery",
            "laptop" => "noutbuki",
            "allinone" => "monobloki",
            "mini" => "nettopy-mini-pk",
            _ => "kompiutery"
        };

        var queryParams = new List<string>
        {
            $"price={filters["min_price"]}-{filters["max_price"]}",
            $"ram={filters["ram"]}_gb_i_bolee"
        };

        if (filters.ContainsKey("cpu"))
        {
            queryParams.Add($"cpu={Uri.EscapeDataString(filters["cpu"])}");
        }

        if (filters.ContainsKey("gpu"))
        {
            queryParams.Add("videokarta=discretnaya");
        }

        return $"https://www.mvideo.ru/{category}?{string.Join("&", queryParams)}";
    }

    private string BuildEldoradoUrl(Dictionary<string, string> filters)
    {
        string category = filters["type"] switch
        {
            "desktop" => "pc",
            "laptop" => "notebooks",
            "allinone" => "monoblocks",
            "mini" => "mini-pc",
            _ => "pc"
        };

        var queryParams = new List<string>
        {
            $"priceFrom={filters["min_price"]}",
            $"priceTo={filters["max_price"]}",
            $"ramFrom={filters["ram"]}"
        };

        if (filters.ContainsKey("cpu"))
        {
            queryParams.Add($"cpu={Uri.EscapeDataString(filters["cpu"])}");
        }

        if (filters.ContainsKey("gpu"))
        {
            queryParams.Add("videoCardType=discrete");
        }

        return $"https://www.eldorado.ru/c/{category}/?{string.Join("&", queryParams)}";
    }

}