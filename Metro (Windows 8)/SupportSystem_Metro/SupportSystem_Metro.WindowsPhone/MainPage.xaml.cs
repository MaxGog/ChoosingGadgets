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
using Windows.UI.Xaml.Media.Imaging;

namespace SupportSystem_Metro
{
    public sealed partial class MainPage : Page
    {
        public string OS, type = "PC or Laptop", model = "Surface", СPU_model = "Intel", image = @"Surface_model.png";
        public string typeCPU = "x64", VideoCard_model = "Invidia", typeRAM = "DDR4";
        private int RAM = 4, ROM = 64, kernels = 8, VideoCard = 2;
        private double CPU = 1.5;
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }
        private void Assembly_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    if (OS == "MacOS or Windows")
                        model = "MacBook";
                    else
                        model = "Samsung";
                }
                else
                {
                    model = "Acer";
                }
            }
        }

        private void Ecosystem_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                model = "Lenovo or Acer";
                if (toggleSwitch.IsOn == true)
                {
                    model = "Surface or Samsung or MacBook";
                }
                else
                {
                    model = "Lenovo or Acer";
                }
            }
        }

        private void Games_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                model = "Everything with Gaming";
                if (toggleSwitch.IsOn == true)
                {
                    RAM += 12;
                    ROM += 512;
                    CPU += 1.5;
                }
                else
                {
                    RAM -= 8;
                    ROM -= 128;
                    CPU += 1;
                }
            }
        }
        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
            if (ROM <= 64)
                ROM = 64;
            if (RAM <= 4)
                RAM = 4;
            if (OS == "MacOS or Windows" || OS == "Windows or Chrome OS" && type == "PC or Laptop" || model == "MacBook")
                type = "Laptop";
            if (ROM >= 65 && ROM <= 128)
                ROM = 128;
            else if (ROM >= 129 && ROM <= 512)
                ROM = 512;
            else if (ROM >= 513 && ROM <= 1024)
                ROM = 1024;
            else if (ROM >= 1025)
                ROM = 2048;
            Picture();
            //Final_Result();
            Res.Text = resourceLoader.GetString("Model_str") + model + "\n" +
                            resourceLoader.GetString("OS") + OS + "\n" +
                            resourceLoader.GetString("TypeDevice") + type + "\n" +
                            resourceLoader.GetString("RAM") + RAM + " (" + typeRAM + ")" + "\n" + resourceLoader.GetString("ROM") + ROM + "\n" +
                            "CPU: " + СPU_model + resourceLoader.GetString("CPU") + CPU + resourceLoader.GetString("Processor_architecture") + typeCPU + "\n" +
                            resourceLoader.GetString("VideoCard") + VideoCard_model + ", " + resourceLoader.GetString("ROMvideo") + VideoCard;

        }
        /*public async void Final_Result()
        {
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
            Result = new ()
            {
                Title = resourceLoader.GetString("Result"),
                Content = resourceLoader.GetString("Model_str") + model + "\n" +
                            resourceLoader.GetString("OS") + OS + "\n" +
                            resourceLoader.GetString("TypeDevice") + type + "\n" +
                            resourceLoader.GetString("RAM") + RAM + " (" + typeRAM + ")" + "\n" + resourceLoader.GetString("ROM") + ROM + "\n" +
                            "CPU: " + СPU_model + resourceLoader.GetString("CPU") + CPU + resourceLoader.GetString("Processor_architecture") + typeCPU + "\n" +
                            resourceLoader.GetString("VideoCard") + VideoCard_model + ", " + resourceLoader.GetString("ROMvideo") + VideoCard,
                PrimaryButtonText = resourceLoader.GetString("Okay"),
            };
            ContentDialogResult result = await Result.ShowAsync();
        }*/
        private void Picture()
        {
            if (type == "PC")
                Image_PC.Source = new BitmapImage(new Uri("ms-appx:///Assets/PC.png"));
            else if (type == "Laptop")
                Image_PC.Source = new BitmapImage(new Uri("ms-appx:///Assets/Surface.png"));
            else if (type == "Tablet")
                Image_PC.Source = new BitmapImage(new Uri("ms-appx:///Assets/Tablet.png"));
            else if (type == "PC or laptop")
                Image_PC.Source = new BitmapImage(new Uri("ms-appx:///Assets/Surface.png"));
            if (model == "Everything with Gaming")
                Image_PC.Source = new BitmapImage(new Uri("ms-appx:///Assets/PC.png"));

        }
        private void Purpose_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    OS = "MacOS and Windows or Linux";
                    CPU = 1.5;
                    kernels = 2;
                    RAM = 4;

                }
                else
                {
                    OS = "MacOS and Windows and Chrome OS";
                    CPU = 1;
                    kernels = 2;
                    RAM = 2;
                }
            }
        }

        private void Mobile_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    type = "Tablet";
                    if (OS == "MacOS and Windows and Chrome OS")
                        OS = "Windows or Chrome OS";
                    else
                        OS = "Windows or Linux or Chrome OS";
                }
                else
                {
                    type = "PC or laptop";
                }
            }
        }

        private void pro_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    if (OS == "Windows or Linux or Chrome OS")
                        OS = "Windows or Linux";
                    else
                        OS = "MacOS or Windows";
                    CPU += 1;
                    kernels += 1;
                    ROM *= 2;
                    RAM += 6;
                    VideoCard = 4;
                    model = "MacBook or Surface";
                }
                else
                {
                    CPU -= 1;
                    kernels -= 1;
                    ROM /= 2;
                    if (ROM <= 128)
                        ROM = 128;
                    RAM -= 6;
                    if (RAM <= 4)
                        RAM = 4;
                    VideoCard -= 2;
                    model = "Lenovo or Acer";
                }
            }
        }
        private void bigROM_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    if (ROM >= 500)
                        ROM += 500;
                    else
                        ROM += 1000;
                }
                else
                {
                    if (ROM <= 500)
                        ROM -= 500;
                    else
                        ROM -= 1000;
                }
            }
        }

        private void Sync_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                    OS = "MacOS or Windows";
            }
        }

        private void Phone_sync_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                    OS = "Windows or Chrome OS";
                else
                    OS = "MacOS or Linux";
            }
        }
    }
}
