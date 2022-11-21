using System;
using Windows.UI.Xaml.Controls;
using PC_support.Models;

namespace PC_support.Views
{
    public sealed partial class NewMainPage : Page
    {
        public NewMainPage()
        {
            this.InitializeComponent();
        }
        private void SelectPage_ItemClick(object sender, ItemClickEventArgs e)
        {
            TitleModel selectedFunctionalNew = (TitleModel)e.ClickedItem;
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
                Frame.Navigate(typeof(MarketRUSPage));
            }
            else if (selectedFunctionalNew == Consoles)
            {
                Frame.Navigate(typeof(ConsolePage));
            }
            else if (selectedFunctionalNew == TipsMenu)
            {
                Frame.Navigate(typeof(DictionaryPage));
            }
        }
    }

}
