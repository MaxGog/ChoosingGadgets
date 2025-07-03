using ChoosingGadgets.Views;

namespace ChoosingGadgets;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("Questionnaire", typeof(QuestionnairePage));
		Routing.RegisterRoute("QuestionnairePhone", typeof(QuestionnairePhonePage));
		
		Routing.RegisterRoute("Results", typeof(ResultsPage));
		Routing.RegisterRoute("ResultsPhone", typeof(ResultsPhonePage));

		Routing.RegisterRoute("Devices", typeof(DevicesPage));
		Routing.RegisterRoute("AddDevice", typeof(AddDevicePage));
		Routing.RegisterRoute("Settings", typeof(SettingsPage));
	}
}
