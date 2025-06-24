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

    public ResultsPage(UserPreferences preferences, 
                     DeviceRepository deviceRepository,
                     ILogger<ResultsPage> logger)
    {
        InitializeComponent();
        _preferences = preferences;
        _deviceRepository = deviceRepository;
        _logger = logger;
        
        LoadRecommendations();
    }

    private async void LoadRecommendations()
    {
        try
        {
            IsBusy = true;
            DevicesCollection.IsVisible = false;
            LoadingIndicator.IsRunning = true;
            
            var allComputers = (await _deviceRepository.GetDevicesByTypeAsync(Models.DeviceType.Computer))
                .Cast<Computer>()
                .ToList();

            if (allComputers.Count == 0)
            {
                await DisplayAlert("Информация", 
                    "База данных компьютеров пока не загружена. Пожалуйста, попробуйте позже.", 
                    "OK");
                await Navigation.PopAsync();
                return;
            }

            var filteredComputers = FilterComputers(allComputers, _preferences)
                .OrderByDescending(c => MatchScore(c, _preferences))
                .Take(3)
                .ToList();

            if (filteredComputers.Count == 0)
            {
                RecommendationLabel.Text = "Не найдено компьютеров, соответствующих вашим критериям.";
                filteredComputers = allComputers
                    .OrderByDescending(c => c.Price)
                    .Take(3)
                    .ToList();
            }
            else
            {
                RecommendationLabel.Text = GetRecommendationText(_preferences);
            }

            DevicesCollection.ItemsSource = filteredComputers;
            DevicesCollection.IsVisible = true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ошибка при загрузке рекомендаций");
            await DisplayAlert("Ошибка", 
                "Произошла ошибка при загрузке данных. Пожалуйста, попробуйте позже.", 
                "OK");
            await Navigation.PopAsync();
        }
        finally
        {
            LoadingIndicator.IsRunning = false;
            IsBusy = false;
        }
    }

    private List<Computer> FilterComputers(List<Computer> computers, UserPreferences preferences)
    {
        return computers.Where(c => 
        {
            if (preferences.Budget == 1 && c.Price > 500) return false;
            if (preferences.Budget == 2 && (c.Price < 500 || c.Price > 1000)) return false;
            if (preferences.Budget == 3 && (c.Price < 1000 || c.Price > 1500)) return false;
            if (preferences.Budget == 4 && c.Price < 1500) return false;
            
            if (preferences.PrimaryUse == "gaming" && !IsGoodForGaming(c)) return false;
            if (preferences.PrimaryUse == "design" && !IsGoodForDesign(c)) return false;
            
            return true;
        }).ToList();
    }

    private double MatchScore(Computer computer, UserPreferences preferences)
	{
		double score = 0;
		
		double price = (double)computer.Price;
		
		if (preferences.Budget == 1) score += 1 - Math.Min(price / 500, 1);
		else if (preferences.Budget == 2) score += 1 - Math.Abs(price - 750) / 250;
		else if (preferences.Budget == 3) score += 1 - Math.Abs(price - 1250) / 250;
		else if (preferences.Budget == 4) score += Math.Min(price / 2000, 1);
		
		score += (computer.RAM / 32.0) * 0.3;
		score += (preferences.PerformancePriority / 5.0) * 0.2;
		
		if (preferences.PrimaryUse == "gaming" && IsGoodForGaming(computer)) score += 0.5;
		if (preferences.PrimaryUse == "design" && IsGoodForDesign(computer)) score += 0.5;
		
		return score;
	}

    private bool IsGoodForGaming(Computer computer)
    {
        return computer.GPU.Contains("RTX") || 
               computer.GPU.Contains("GTX") || 
               computer.RAM >= 16;
    }

    private bool IsGoodForDesign(Computer computer)
    {
        return computer.RAM >= 32 || 
               computer.Processor.Contains("i7") || 
               computer.Processor.Contains("i9") ||
               computer.Processor.Contains("Ryzen 7") ||
               computer.Processor.Contains("Ryzen 9");
    }

    private string GetRecommendationText(UserPreferences preferences)
    {
        return preferences.PrimaryUse switch
        {
            "gaming" => "Лучшие игровые компьютеры для вас:",
            "design" => "Рабочие станции для профессионального дизайна:",
            "work" => "Оптимальные компьютеры для офисной работы:",
            _ => "Рекомендуемые компьютеры:"
        };
    }

    private async void OnDeviceSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Computer selectedComputer)
        {
            await DisplayAlert(selectedComputer.Name, 
                $"Процессор: {selectedComputer.Processor}\n" +
                $"Видеокарта: {selectedComputer.GPU}\n" +
                $"Оперативная память: {selectedComputer.RAM}GB\n" +
                $"Хранение: {selectedComputer.Storage}\n" +
                $"ОС: {selectedComputer.OS}\n\n" +
                $"Цена: {selectedComputer.Price:C}", "OK");
        }
        
        if (sender is CollectionView collectionView)
            collectionView.SelectedItem = null;
    }
}