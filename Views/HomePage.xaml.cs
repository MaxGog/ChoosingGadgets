using System;
using Windows.UI.Xaml.Controls;
using PC_support.Views;
using PC_support.Models;

namespace PC_support
{
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
        }
        private void SelectPage_ItemClick(object sender, ItemClickEventArgs e)
        {
            Functionality selectedFunctionalNew = (Functionality)e.ClickedItem;
            if (selectedFunctionalNew == PCLaptopMenu)
            {
                Frame.Navigate(typeof(PCLaptopPage));
                //NavPan.SelectedItem = PC_and_laptops;
            }
            else if (selectedFunctionalNew == PhonesMenu)
            {
                Frame.Navigate(typeof(PhonePage));
                //NavPan.SelectedItem = Phone;
            }
            else if (selectedFunctionalNew == MarketMenu)
            {
                Frame.Navigate(typeof(MarketPage));
                //NavPan.SelectedItem = Market;
            }
            else if (selectedFunctionalNew == Consoles)
            {
                Frame.Navigate(typeof(ConsolePage));
                //NavPan.SelectedItem = GamingConsole;
            }
            /*else if (selectedFunctional == Settings)
            {
                contentFrame.Navigate(typeof(SettingsPage));
            }
            else if (selectedFunctional == TipsMenu)
            {
                contentFrame.Navigate(typeof(MainTipsPage));
                NavPan.SelectedItem = Tips;
            }*/
        }
    }

}
