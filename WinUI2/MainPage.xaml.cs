using PC_support.WebPages;
using Windows.UI.Xaml.Controls;
using PC_support.DLC;
using Windows.UI.ViewManagement;
using PC_support.UserExperience;
//using Windows.ApplicationModel.Core;

namespace PC_support
{
    
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
            ApplicationView.GetForCurrentView().Title = resourceLoader.GetString("AppTitle");
            NavPan.IsSettingsVisible = false;
            NavPan.PaneTitle = resourceLoader.GetString("AppTitle");
            contentFrame.Navigate(typeof(NewMainPage));
            //CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = false;
            //NavPan.Header = "Choosing gadgets";
            //NavPan.BackRequested MainPage_BackRequested;
            //SystemNavigationManager.GetForCurrentView().BackRequested +=
            NavPan.Header = "Menu";
        }
        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem == VK)
            {
                contentFrame.Navigate(typeof(DisVKPage));
                NavPan.Header = "GitHub";
            }
            else if (args.SelectedItem == PC_and_laptops)
            {
                contentFrame.Navigate(typeof(PCLaptopPage));
                NavPan.Header = "PC and laptop's";
            }
            else if (args.SelectedItem == Menu)
            {
                contentFrame.Navigate(typeof(NewMainPage));
                NavPan.Header = "Menu";
            }
            else if (args.SelectedItem == Phone)
            {
                contentFrame.Navigate(typeof(PhonePage));
                NavPan.Header = "Phones";
            }
            else if (args.SelectedItem == Market)
            {
                contentFrame.Navigate(typeof(MarketRUSPage));
                NavPan.Header = "Yandex.Market";
            }
            else if (args.SelectedItem == GamingConsole)
            {
                contentFrame.Navigate(typeof(ConsolePage));
                NavPan.Header = "Gaming console";
            }
            else if (args.SelectedItem == Tips)
            {
                contentFrame.Navigate(typeof(MainTipsPage));
                NavPan.Header = "Tips";
            }
            else if (args.SelectedItem == Models)
            {
                contentFrame.Navigate(typeof(ModelsPage));
                NavPan.Header = "Models";
            }
            if (args.IsSettingsSelected == true)
            {
                contentFrame.Navigate(typeof(SettingsPage));
            }
        }
        
    }
}
