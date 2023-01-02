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
        }
        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem == VK)
            {
                contentFrame.Navigate(typeof(SocialPage));
            }
            else if (args.SelectedItem == PC_and_laptops)
            {
                contentFrame.Navigate(typeof(PCLaptopPage));
            }
            else if (args.SelectedItem == Menu)
            {
                contentFrame.Navigate(typeof(HomePage));
            }
            else if (args.SelectedItem == Phone)
            {
                contentFrame.Navigate(typeof(PhonePage));
            }
            else if (args.SelectedItem == Market)
            {
                contentFrame.Navigate(typeof(MarketPage));
            }
            else if (args.SelectedItem == GamingConsole)
            {
                contentFrame.Navigate(typeof(ConsolePage));
            }
            else if (args.SelectedItem == Tips)
            {
                contentFrame.Navigate(typeof(DictionaryPage));
            }
            if (args.IsSettingsSelected == true)
            {
                contentFrame.Navigate(typeof(SettingsPage));
            }
        }
    }
}
