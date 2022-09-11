using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SupportSystemBeta.DLC
{
    public sealed partial class Appliances : Page
    {
        public Appliances()
        {
            this.InitializeComponent();
            contentFrame.Navigate(typeof(SmartHome));
        }
        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem == SmartHome_object)
            {
                contentFrame.Navigate(typeof(SmartHome));
            }
            else if (args.SelectedItem == Models_object)
            {
                contentFrame.Navigate(typeof(Eco_Systems));
            }
            else if (args.SelectedItem == VacuumCleaner_object)
            {
                contentFrame.Navigate(typeof(Vacuum_cleaner));
            }
        }
    }
}
