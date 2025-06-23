using ChoosingGadgets.Views;

namespace ChoosingGadgets;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("Devices", typeof(DevicesPage));
		Routing.RegisterRoute("Settings", typeof(SettingsPage));
	}
}
