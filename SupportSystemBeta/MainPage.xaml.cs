using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SupportSystemBeta.DLC;

namespace SupportSystemBeta
{
    public class Functionality
    {
        public string Icon { get; set; }
        public string Name_str { get; set; }
    }
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem == PC_and_laptops)
            {
                contentFrame.Navigate(typeof(PCLaptop));
            }
            else if (args.SelectedItem == Phone)
            {
                contentFrame.Navigate(typeof(Phone));
            }
            else if (args.SelectedItem == Appliances)
            {
                contentFrame.Navigate(typeof(Appliances));
            }
        }
        private void SelectPage_ItemClick(object sender, ItemClickEventArgs e)
        {
            Functionality selectedFunctional = (Functionality)e.ClickedItem;
            if (selectedFunctional == PCLaptop)
            {
                contentFrame.Navigate(typeof(PCLaptop));
                NavPan.SelectedItem = PCLaptop;
            }
            else if (selectedFunctional == Phones)
            {
                contentFrame.Navigate(typeof(Phone));
                NavPan.SelectedItem = Phone;
            }
        }
    }
}
