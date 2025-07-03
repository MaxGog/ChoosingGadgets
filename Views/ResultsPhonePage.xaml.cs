using ChoosingGadgets.Models;
using ChoosingGadgets.Repositories;
using ChoosingGadgets.ViewModels;
using Microsoft.Extensions.Logging;

namespace ChoosingGadgets.Views;

public partial class ResultsPhonePage : ContentPage
{
    private readonly UserPhonePreferences _preferences;
    private readonly DeviceRepository _deviceRepository;
    private readonly ILogger<ResultsPhonePage> _logger;
    private readonly bool _useDatabase;

    public ResultsPhonePage(UserPhonePreferences preferences, 
                     DeviceRepository deviceRepository,
                     ILogger<ResultsPhonePage> logger,
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
            
            var viewModel = new ResultsPhoneViewModel(_preferences, _deviceRepository, _useDatabase);
            await viewModel.LoadRecommendations();

            if (viewModel.RecommendedDevices.Count == 0)
            {
                RecommendationLabel.Text = "Не найдено смартфонов, соответствующих вашим критериям. " + 
                                        "Вот общие рекомендации:";
                
                var genericViewModel = new ResultsPhoneViewModel(_preferences, _deviceRepository, false);
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
            
            var genericViewModel = new ResultsPhoneViewModel(_preferences, _deviceRepository, false);
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

    private string GetRecommendationText(UserPhonePreferences preferences)
    {
        string baseText = preferences.PrimaryUse switch
        {
            "gaming" => "Игровые смартфоны",
            "photo" => "Смартфоны для фотосъемки",
            "business" => "Бизнес-смартфоны",
            "premium" => "Премиум смартфоны",
            _ => "Рекомендуемые смартфоны"
        };

        string sizeText = preferences.ScreenSizePreference switch
        {
            0 => " (компактные)",
            1 => " (стандартного размера)",
            2 => " (большие)",
            3 => " (очень большие)",
            _ => ""
        };

        return $"{baseText}{sizeText} для вашего бюджета:";
    }

    private async void OnDeviceSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Smartphone selectedPhone)
        {
            await DisplayAlert("Подробная информация", selectedPhone.GetFullSpecs(), "OK");
        }
        
        if (sender is CollectionView collectionView)
            collectionView.SelectedItem = null;
    }
}