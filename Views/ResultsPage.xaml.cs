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
}