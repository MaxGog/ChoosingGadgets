using System;
using Windows.UI.Xaml.Controls;
using PC_support.Views;

namespace PC_support
{
    public class FunctionalityNew
    {
        public string Icon { get; set; }
        public string Name_str { get; set; }
    }
    public sealed partial class NewMainPage : Page
    {
        public NewMainPage()
        {
            this.InitializeComponent();
        }
        /*private async void InfoPage()
        {
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
            await new Windows.UI.Popups.MessageDialog(resourceLoader.GetString("About")).ShowAsync();
        }*/
        private void SelectPage_ItemClick(object sender, ItemClickEventArgs e)
        {
            FunctionalityNew selectedFunctionalNew = (FunctionalityNew)e.ClickedItem;
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
                Frame.Navigate(typeof(MarketRUSPage));
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

        /*private void ToggleSwitch_Toggled(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (NavPanPane.IsOn == true)
            {
                NavPan.PaneDisplayMode = NavigationViewPaneDisplayMode.Left;
            }
            else
            {
                NavPan.PaneDisplayMode = NavigationViewPaneDisplayMode.Top;
            }
        }*/

        /*private void ThemeWindow_Toggled(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (ThemeWindow.IsOn == true)
            {
                
            }
            else
            {
                NavPan.PaneDisplayMode = NavigationViewPaneDisplayMode.Top;
            }
        }*/

        /*private void Search_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {

        }*/

        /*private void NaPan_Toggled(object sender, RoutedEventArgs e)
        {
            if (NaPan.IsOn)
            {
                NavPan.PaneDisplayMode = NavigationViewPaneDisplayMode.Top;
                //App.Current.RequestedTheme = (ApplicationTheme)ElementTheme.Dark;
            }
            else
            {
                NavPan.PaneDisplayMode = NavigationViewPaneDisplayMode.Left;
                //App.Current.RequestedTheme = (ApplicationTheme)ElementTheme.Light;
            }
        }*/
    }

}
