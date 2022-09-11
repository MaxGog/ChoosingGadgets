using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace SupportSystemBeta
{
    public sealed partial class Phone : Page
    {
        private int RAM = 1, ROM = 16, file = 0;
        private string model, pay = "Any";
        private double CPU = 0.5;
        int winphone = 0, iphone = 0, android = 0;
        public Phone()
        {
            this.InitializeComponent();
        }
        private void ProMobile_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    iphone = 1;
                    android = 1;
                    RAM = 12;
                }
                else
                {
                    iphone = 1;
                    winphone = 1;
                    RAM -= 6;
                }
            }
        }
        private void Purpose_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    winphone = 1;
                    iphone = 1;
                }
                else
                {
                    iphone = 1;
                    android = 1;
                }
            }
        }
        private void File_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    android = 1; iphone = 0; winphone = 1;
                    ROM += 32; file = 1;
                }
                else
                {
                    iphone = 1;
                    if (ROM >= 32)
                        ROM = 16;
                    file = 0;
                }
            }
        }

        private void Cloud_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    RAM += 2;
                    winphone = 0;
                    iphone = 1;
                    if (file == 1)
                        iphone = 0;
                }
                else
                {
                    ROM += 32;
                }
            }
        }
        private void Apps_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    ROM += 64;
                    winphone = 0;
                }
            }
        }
        private void Game_Toggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                if (toggleSwitch.IsOn == true)
                {
                    iphone = 0;
                    android = 1;
                    winphone = 0;
                }
                else
                {
                    iphone = 1;
                    android = 1;
                    winphone = 1;
                }
            }
        }
        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
            if (winphone == 1)
                model = "Windows Phone";
            else if (android == 1)
            {
                if (RAM >= 6 && CPU >= 1 && ROM >= 32)
                {
                    model = "Google Pixel or Samsung Galaxy";
                    pay = "Google Pay or Samsung Pay";
                }
                else if (RAM <= 6 && CPU <= 1 && ROM <= 32)
                    model = "Xiaomi or Huawei with Android Go";
                else
                    model = "Nokia or Honor";
                pay = "Google Pay";
            }
            else if (iphone == 1)
            {
                model = "iPhone"; pay = "Apple Pay";
            }
            else if (iphone == 1 && android == 1)
            {
                if (RAM >= 4)
                {
                    model = "Google Pixel or Samsung Galaxy";
                    pay = "Google Pay";
                }
                else
                {
                    model = "iPhone";
                    pay = "Apple Pay";
                }

            }
            else if (iphone == 1 && winphone == 1)
                model = "Windows Phone, but if you have a many money, you can buy iPhone";
            else if (winphone == 1 && android == 1)
                model = "Windows Phone, if you use Google, you can buy Android phone";
            else
                model = "Any";
            if (ROM <= 64)
                ROM = 64;
            if (RAM <= 4)
                RAM = 4;
            if (ROM >= 65 && ROM <= 128)
                ROM = 128;
            else if (ROM >= 129 && ROM <= 512)
                ROM = 512;
            else if (ROM >= 513 && ROM <= 1024)
                ROM = 1024;
            Picture();
            Final_Result();
        }
        public async void Final_Result()
        {
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
            ContentDialog Result = new ContentDialog()
            {

                Title = resourceLoader.GetString("Result"),
                Content = resourceLoader.GetString("SmartModel") + model + "\n" +
                           resourceLoader.GetString("RAM") + RAM + "\n" +
                           resourceLoader.GetString("ROM") + ROM + "\n" +
                           resourceLoader.GetString("Payment") + pay,
                PrimaryButtonText = resourceLoader.GetString("Okay"),
            };
            ContentDialogResult result = await Result.ShowAsync();
        }
        private void Picture()
        {
            if (model == "Windows Phone")
                Image_Phone.Source = new BitmapImage(new Uri("ms-appx:///Assets/WinPhone.png"));
            else if (model == "Android" || model == "Google Pixel or Samsung Galaxy")
                Image_Phone.Source = new BitmapImage(new Uri("ms-appx:///Assets/Samsung.png"));
            else if (model == "iPhone")
                Image_Phone.Source = new BitmapImage(new Uri("ms-appx:///Assets/IPhone.png"));
            else if (model == "Windows Phone, but if you have a many money, you can buy iPhone" || model == "Windows Phone, if you use Google, you can buy Android phone")
                Image_Phone.Source = new BitmapImage(new Uri("ms-appx:///Assets/Samsung.png"));
        }
    }
}
