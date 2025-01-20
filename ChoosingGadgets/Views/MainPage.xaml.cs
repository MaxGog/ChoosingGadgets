namespace ChoosingGadgets.Views;

public partial class MainPage : ContentPage
{
	NavigationService navigationService = new();
	public MainPage()
	{
		InitializeComponent();
	}

	/*private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}*/

    private void LaptopsBtnClicked(object sender, EventArgs e) => navigationService.NavigateToAsync("ChooseLaptop");

	private void PhonesBtnClicked(object sender, EventArgs e) => navigationService.NavigateToAsync("ChooseSmartphone");

	private void ConsolesBtnClicked(object sender, EventArgs e) => navigationService.NavigateToAsync("ChooseConsole");
}

