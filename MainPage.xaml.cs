using PC_support.Views;
using Windows.UI.Xaml.Controls;
using Windows.UI.ViewManagement;
using PC_support.Models;
using System;

namespace PC_support
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void SelectPage_ItemClick(object sender, ItemClickEventArgs e)
        {
            Functionality selectedFunctionalNew = (Functionality)e.ClickedItem;
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
            else if (selectedFunctionalNew == Community)
            {
                Frame.Navigate(typeof(SocialPage));
            }
        }
    }
}
