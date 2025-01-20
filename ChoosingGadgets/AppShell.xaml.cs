using ChoosingGadgets.Views;

namespace ChoosingGadgets;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("ChooseLaptop", typeof(ChooseLaptopPage));
		Routing.RegisterRoute("ChooseSmartphone", typeof(ChooseSmartphonePage));
		Routing.RegisterRoute("ChooseConsole", typeof(ChooseConsolePage));
	}
}
