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
    public sealed partial class Vacuum_cleaner : Page
    {
        private static bool cl_smart = false;
        private static int сapacity = 0;
        //private static bool water = false;
        private static string str_smart;
        public Vacuum_cleaner()
        {
            this.InitializeComponent();
        }
        private async void Finish_Click(object sender, RoutedEventArgs e)
        {
            if (cl_smart == true)
                str_smart = "Yes";
            else
                str_smart = "No";

            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
            ContentDialog Result = new ContentDialog()
            {
                Title = resourceLoader.GetString("Result"),
                Content = "Умный пылесос: " + str_smart + "\n" + "Вместимость: " + сapacity,
                PrimaryButtonText = resourceLoader.GetString("Okay"),
            };

            ContentDialogResult result = await Result.ShowAsync();
        }

        private void Smart_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    cl_smart = true;
                }
                else
                {
                    cl_smart = false;
                }
            }
        }

        private void Dimensions_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    сapacity += 20;
                }
                else
                {
                    сapacity -= 20;
                }
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
