using PC_support.Views;
using Windows.UI.Xaml.Controls;
using Windows.UI.ViewManagement;
//using Windows.ApplicationModel.Core;

namespace PC_support
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            contentFrame.Navigate(typeof(HomePage));
            NavPan.Header = "Menu";
        }
        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem == VK)
            {
                contentFrame.Navigate(typeof(SocialPage));
                NavPan.Header = "GitHub";
            }
            else if (args.SelectedItem == PC_and_laptops)
            {
                contentFrame.Navigate(typeof(PCLaptopPage));
                NavPan.Header = "PC and laptop's";
            }
            else if (args.SelectedItem == Menu)
            {
                contentFrame.Navigate(typeof(HomePage));
                NavPan.Header = "Menu";
            }
            else if (args.SelectedItem == Phone)
            {
                contentFrame.Navigate(typeof(PhonePage));
                NavPan.Header = "Phones";
            }
            else if (args.SelectedItem == Market)
            {
                contentFrame.Navigate(typeof(MarketPage));
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
