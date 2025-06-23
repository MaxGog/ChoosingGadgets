
using System.Collections.ObjectModel;
using System.Windows.Input;
using ChoosingGadgets.Services;

namespace ChoosingGadgets.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly NavigationService navigationService;

    
    public MainViewModel(NavigationService _navigationService)
    {
        navigationService = _navigationService;
        
        LaptopsNavigateCommand = new Command(LaptopsNavigate);
        SmartphonesNavigateCommand = new Command(PhonesNavigate);
        ConsolesNavigateCommand = new Command(ConsolesNavigate);
        SettingsNavigateCommand = new Command(SettingsNavigate);
        OpenProductUrlCommand = new Command<string>(OpenProductUrl);
        
    }
    
    public ICommand LaptopsNavigateCommand { get; }
    public ICommand SmartphonesNavigateCommand { get; }
    public ICommand ConsolesNavigateCommand { get; }
    public ICommand SettingsNavigateCommand { get; }
    public ICommand OpenProductUrlCommand { get; }
    
    
    private void LaptopsNavigate() => NavigationService.NavigateToAsync("ChooseLaptop");
    private void PhonesNavigate() => NavigationService.NavigateToAsync("ChooseSmartphone");
    private void ConsolesNavigate() => NavigationService.NavigateToAsync("ChooseConsole");
    private void SettingsNavigate() => NavigationService.NavigateToAsync("Settings");
    
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