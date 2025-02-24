namespace ChoosingGadgets.Views;

public partial class MainPage : ContentPage
{
	NavigationService navigationService = new();
	public MainPage()
	{
		InitializeComponent();
	}

    private void LaptopsBtnClicked(object sender, EventArgs e) => navigationService.NavigateToAsync("ChooseLaptop");
	private void PhonesBtnClicked(object sender, EventArgs e) => navigationService.NavigateToAsync("ChooseSmartphone");
	private void ConsolesBtnClicked(object sender, EventArgs e) => navigationService.NavigateToAsync("ChooseConsole");
	private void SettingsBtnClicked(object sender, EventArgs e) => navigationService.NavigateToAsync("Settings");
    private void SettingsToolbarClicked(object sender, EventArgs e) => navigationService.NavigateToAsync("Settings");
}

