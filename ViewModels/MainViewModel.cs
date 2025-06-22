using System.Windows.Input;

namespace ChoosingGadgets.ViewModels;

internal class MainViewModel
{
    private readonly NavigationService navigationService;
    public MainViewModel(NavigationService _navigationService)
    {
        navigationService = _navigationService;
        LaptopsNavigateCommand = new Command(LaptopsNavigate);
        SmartphonesNavigateCommand = new Command(PhonesNavigate);
        ConsolesNavigateCommand = new Command(ConsolesNavigate);
        SettingsNavigateCommand = new Command(SettingsNavigate);
    }

    public ICommand LaptopsNavigateCommand { get; }
    public ICommand SmartphonesNavigateCommand { get; }
    public ICommand ConsolesNavigateCommand { get; }
    public ICommand SettingsNavigateCommand { get; }

    private void LaptopsNavigate() => navigationService.NavigateToAsync("ChooseLaptop");
	private void PhonesNavigate() => navigationService.NavigateToAsync("ChooseSmartphone");
	private void ConsolesNavigate() => navigationService.NavigateToAsync("ChooseConsole");
	private void SettingsNavigate() => navigationService.NavigateToAsync("Settings");
}