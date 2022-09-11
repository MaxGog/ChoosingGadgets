using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Microsoft.UI.Xaml.Media.Imaging;

namespace ChoosingGadgets
{
    public sealed partial class PhonePage : Page
    {
        private int RAM = 0, ROM = 0;
        private string model, pay = "Any";
        private double CPU = 0.5;
        int iphone = 0, android = 0;
        public PhonePage()
        {
            this.InitializeComponent();
        }
        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse();
            RAM = 1; ROM = 8; iphone = 0; android = 1;
            if (ProMobile.IsOn == true)
            {
                RAM += 4; iphone = 1; ROM += 32; android = 0;
            }
            if (File.IsOn == true)
            {
                android = 1; ROM += 16;
            }
            if (Cloud.IsOn == true)
            {
                if (File.IsOn == false)
                    iphone = 1;
                else
                    android = 1;
                CPU += 1.0;
            }
            if (Apps.IsOn == true)
            {
                ROM += 32;
            }
            if (Game.IsOn == true)
            {
                RAM += 4; ROM += 32; android = 1;
            }
            else if (android == 1)
            {
                if (RAM >= 6 && CPU >= 1 && ROM >= 32)
                {
                    model = "Google Pixel or Samsung Galaxy";
                    pay = "Google Pay or Samsung Pay";
                }
                else
                {
                    model = RAM <= 6 && CPU <= 1 && ROM <= 32 ? "Xiaomi or Huawei with Android Go" : "Nokia or Honor";
                }

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
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse();
            ContentDialog Result = new ContentDialog();
            Result.Title = resourceLoader.GetString("Result");
            Result.Content = resourceLoader.GetString("SmartModel") + model + "\n" +
                           resourceLoader.GetString("RAM") + RAM + "\n" +
                           resourceLoader.GetString("ROM") + ROM + "\n" +
                           resourceLoader.GetString("Payment") + pay;
            Result.PrimaryButtonText = resourceLoader.GetString("Okay");
            Result.XamlRoot = FullPage.XamlRoot;
            ContentDialogResult result = await Result.ShowAsync();
        }
        private void Picture()
        {
            if (model == "Windows Phone")
                Image_Phone.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualPictures/Phones/WinPhone.png"));
            else if (model == "Android" || model == "Google Pixel or Samsung Galaxy")
                Image_Phone.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualPictures/Phones/Samsung.png"));
            else if (model == "iPhone")
                Image_Phone.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualPictures/Phones/IPhone.png"));
            else if (model == "Windows Phone, but if you have a many money, you can buy iPhone" || model == "Windows Phone, if you use Google, you can buy Android phone")
                Image_Phone.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualPictures/Phones/Samsung.png"));
            else if (model == "Nokia or Honor")
                Image_Phone.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualPictures/Phones/Honor.png"));
        }
    }
}
