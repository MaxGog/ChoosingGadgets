//using ChoosingGadgets.DLC.Models;
using ChoosingGadgets.WebPages;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using ChoosingGadgets.DLC.Models;
using ChoosingGadgets.SettingsApp;

namespace ChoosingGadgets
{
    public class Functionality
    {
        public string Icon { get; set; }
        public string Name_str { get; set; }
    }
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            Head.Text = "Menu";
        }
        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem == VK)
            {
                contentFrame.Navigate(typeof(DisVKPage));
                Head.Text = "VK";
            }
            else if (args.SelectedItem == PC_and_laptops)
            {
                contentFrame.Navigate(typeof(PCLaptopPage));
                Head.Text = "PC and laptops";
            }
            else if (args.SelectedItem == Phone)
            {
                contentFrame.Navigate(typeof(PhonePage));
                Head.Text = "Phones";
            }
            else if (args.SelectedItem == Market)
            {
                contentFrame.Navigate(typeof(MarketPage));
                Head.Text = "Market";
            }
            /*else if (args.SelectedItem == Tips)
            {
                contentFrame.Navigate(typeof(MainTipsPage));
                Head.Text = "Tips";
            }*/
            else if (args.SelectedItem == Models)
            {
                contentFrame.Navigate(typeof(ModelsPage));
                Head.Text = "Models";
            }
            if (args.IsSettingsSelected == true)
            {
                contentFrame.Navigate(typeof(SettingsPage));
                Head.Text = "Settings";
            }
        }
        private void SelectPage_ItemClick(object sender, ItemClickEventArgs e)
        {
            Functionality selectedFunctional = (Functionality)e.ClickedItem;
            if (selectedFunctional == PCLaptopMenu)
            {
                contentFrame.Navigate(typeof(PCLaptopPage));
                NavPan.SelectedItem = PC_and_laptops;
            }
            else if (selectedFunctional == PhonesMenu)
            {
                contentFrame.Navigate(typeof(PhonePage));
                NavPan.SelectedItem = Phone;
            }
            else if (selectedFunctional == MarketMenu)
            {
                contentFrame.Navigate(typeof(MarketPage));
                NavPan.SelectedItem = Market;
            }
            else if (selectedFunctional == Settings)
            {
                contentFrame.Navigate(typeof(SettingsPage));
            }
            //else if (selectedFunctional == TipsMenu)
            //{
            //    contentFrame.Navigate(typeof(MainTipsPage));
            //    NavPan.SelectedItem = Tips;
            //}
        }
    }
}
