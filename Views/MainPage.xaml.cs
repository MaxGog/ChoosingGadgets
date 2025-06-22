using ChoosingGadgets.ViewModels;

namespace ChoosingGadgets.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainViewModel(new NavigationService());
	}
}

