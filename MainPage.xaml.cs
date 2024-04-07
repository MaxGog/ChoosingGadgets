using Windows.UI.Xaml.Controls;

using PC_support.Models;
using PC_support.Views;
using Windows.UI.ViewManagement;

namespace PC_support
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
            ApplicationView.GetForCurrentView().Title = resourceLoader.GetString("TitleMain"); ;
        }
        private void SelectPage_ItemClick(object sender, ItemClickEventArgs e)
        {
            MenuTiles selectedFunctionalNew = (MenuTiles)e.ClickedItem;
            if (selectedFunctionalNew == PCLaptopMenu)
            {
                Frame.Navigate(typeof(PCLaptopPage));
            }
            else if (selectedFunctionalNew == PhonesMenu)
            {
                Frame.Navigate(typeof(PhonePage));
            }
            else if (selectedFunctionalNew == MarketMenu)
            {
                Frame.Navigate(typeof(MarketPage));
            }
            else if (selectedFunctionalNew == Consoles)
            {
                Frame.Navigate(typeof(ConsolePage));
            }
            else if (selectedFunctionalNew == Settings)
            {
                Frame.Navigate(typeof(SettingsPage));
            }
            else if (selectedFunctionalNew == TipsMenu)
            {
                Frame.Navigate(typeof(DictionaryPage));
            }
            else if (selectedFunctionalNew == TipsMenu2)
            {
                Frame.Navigate(typeof(TipsPage));
            }
            else if (selectedFunctionalNew == Community)
            {
                Frame.Navigate(typeof(SocialPage));
            }
        }
    }
}
