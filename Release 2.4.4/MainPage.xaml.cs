using Windows.UI.Xaml.Controls;
//using Windows.UI.ViewManagement;

using PC_support.Views;
using Windows.UI.Xaml;
//using Windows.ApplicationModel.Core;

namespace PC_support
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            NavPan.IsSettingsVisible = false;
            contentFrame.Navigate(typeof(NewMainPage));
            NavPan.SelectedItem = Menu;
        }
        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem == VK)
            {
                contentFrame.Navigate(typeof(DisVKPage));
            }
            else if (args.SelectedItem == PC_and_laptops)
            {
                contentFrame.Navigate(typeof(PCLaptopPage));
            }
            else if (args.SelectedItem == Menu)
            {
                contentFrame.Navigate(typeof(NewMainPage));
            }
            else if (args.SelectedItem == Phone)
            {
                contentFrame.Navigate(typeof(PhonePage));
            }
            else if (args.SelectedItem == Market)
            {
                contentFrame.Navigate(typeof(MarketRUSPage));
            }
            else if (args.SelectedItem == GamingConsole)
            {
                contentFrame.Navigate(typeof(ConsolePage));
            }
            else if (args.SelectedItem == Tips)
            {
                contentFrame.Navigate(typeof(DictionaryPage));
            }
            else if (args.SelectedItem == History)
            {
                contentFrame.Navigate(typeof(HistoryPage));
            }
            /*else if (args.SelectedItem == Models)
            {
                contentFrame.Navigate(typeof(ModelsPage));
                NavPan.Header = "Models";
            }*/
            if (args.IsSettingsSelected == true)
            {
                contentFrame.Navigate(typeof(SettingsPage));
            }
        }

        private void NavPan_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            App.TryGoBack();
        }
        //private void SelectPage_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    Functionality selectedFunctional = (Functionality)e.ClickedItem;
        //    if (selectedFunctional == PCLaptopMenu)
        //    {
        //        Frame.Navigate(typeof(PCLaptopPage));
        //        //NavPan.SelectedItem = PC_and_laptops;
        //    }
        //    else if (selectedFunctional == PhonesMenu)
        //    {
        //        Frame.Navigate(typeof(PhonePage));
        //        //NavPan.SelectedItem = Phone;
        //    }
        //    else if (selectedFunctional == MarketMenu)
        //    {
        //        Frame.Navigate(typeof(MarketRUSPage));
        //        //NavPan.SelectedItem = Market;
        //    }
        //    else if (selectedFunctional == Consoles)
        //    {
        //        Frame.Navigate(typeof(ConsolePage));
        //        //NavPan.SelectedItem = GamingConsole;
        //    }
        //    /*else if (selectedFunctional == Settings)
        //    {
        //        contentFrame.Navigate(typeof(SettingsPage));
        //    }
        //    else if (selectedFunctional == TipsMenu)
        //    {
        //        contentFrame.Navigate(typeof(MainTipsPage));
        //        NavPan.SelectedItem = Tips;
        //    }*/
        //}

    }
}
