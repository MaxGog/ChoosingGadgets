using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using ChoosingGadgets.UWP.Models;
using ChoosingGadgets.UWP.Views;

namespace ChoosingGadgets.UWP
{
    public sealed partial class MainPage
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
