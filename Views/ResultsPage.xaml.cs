using ChoosingGadgets.Models;
using ChoosingGadgets.ViewModels;

namespace ChoosingGadgets.Views;

public partial class ResultsPage : ContentPage
{
    public ResultsPage(UserPreferences preferences)
    {
        InitializeComponent();
        LoadRecommendations(preferences);
    }

    private async void LoadRecommendations(UserPreferences preferences)
    {
        // Здесь должна быть логика подбора устройств
        var viewModel = new ResultsViewModel(preferences);
        await viewModel.LoadRecommendations();
        
        DevicesCollection.ItemsSource = viewModel.RecommendedDevices;
        RecommendationLabel.Text = GetRecommendationText(preferences);
    }

    private string GetRecommendationText(UserPreferences preferences)
    {
        if (preferences.PrimaryUse == "gaming")
            return "Игровые компьютеры:";
        
        if (preferences.PrimaryUse == "design")
            return "Рабочие станции для дизайна:";
        
        return "Рекомендуемые компьютеры:";
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
                $"ОС: {selectedComputer.OS}", "OK");
        }
    }
}