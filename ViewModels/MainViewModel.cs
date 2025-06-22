
using System.Collections.ObjectModel;
using System.Windows.Input;
using ChoosingGadgets.Models;
using ChoosingGadgets.Services;

namespace ChoosingGadgets.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly NavigationService navigationService;
    private readonly YandexMarketParser marketParser;
    
    public ObservableCollection<YandexMarketLaptop> Laptops { get; } = new();
    
    public MainViewModel(NavigationService _navigationService)
    {
        navigationService = _navigationService;
        marketParser = new YandexMarketParser();
        
        LaptopsNavigateCommand = new Command(LaptopsNavigate);
        SmartphonesNavigateCommand = new Command(PhonesNavigate);
        ConsolesNavigateCommand = new Command(ConsolesNavigate);
        SettingsNavigateCommand = new Command(SettingsNavigate);
        OpenProductUrlCommand = new Command<string>(OpenProductUrl);
        
        LoadLaptops();
    }
    
    public ICommand LaptopsNavigateCommand { get; }
    public ICommand SmartphonesNavigateCommand { get; }
    public ICommand ConsolesNavigateCommand { get; }
    public ICommand SettingsNavigateCommand { get; }
    public ICommand OpenProductUrlCommand { get; }
    
    private async void LoadLaptops()
    {
        try
        {
            var laptops = await marketParser.ParseLaptopsAsync();
            Laptops.Clear();
            foreach (var laptop in laptops)
            {
                Laptops.Add(laptop);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка загрузки ноутбуков: {ex.Message}");
        }
    }
    
    private void LaptopsNavigate() => navigationService.NavigateToAsync("ChooseLaptop");
    private void PhonesNavigate() => navigationService.NavigateToAsync("ChooseSmartphone");
    private void ConsolesNavigate() => navigationService.NavigateToAsync("ChooseConsole");
    private void SettingsNavigate() => navigationService.NavigateToAsync("Settings");
    
    private async void OpenProductUrl(string url)
    {
        if (!string.IsNullOrEmpty(url))
        {
            try
            {
                await Browser.Default.OpenAsync(new Uri(url), BrowserLaunchMode.SystemPreferred);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Не удалось открыть ссылку: {ex.Message}");
            }
        }
    }
}