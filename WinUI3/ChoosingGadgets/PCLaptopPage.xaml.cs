using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using Microsoft.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml;

namespace ChoosingGadgets
{
    public sealed partial class PCLaptopPage : Page
    {
        private string type = "PC or Laptop", model = "Surface", СPU_model = "Intel", OS_str;
        private string typeCPU = "x64", VideoCard_model = "Invidia", typeRAM = "DDR4";
        private int OS, RAM, ROM, kernels, VideoCard;

        private void Home_purpose_Checked(object sender, RoutedEventArgs e)
        {
            FisrtTip.IsOpen = true;
        }

        private double CPU = 1.5;
        public PCLaptopPage()
        {
            this.InitializeComponent();
        }
        private void Pro_ver_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PCLaptopPage_pro));
        }
        private void pro_Toggled(object sender, RoutedEventArgs e)
        {
            if (pro.IsOn == true)
            {
                pro_adobe.IsEnabled = true;
                pro_vr.IsEnabled = true;
            }
            else
            {
                pro_adobe.IsEnabled = false;
                pro_adobe.IsOn = false;
                pro_vr.IsEnabled = false;
                pro_vr.IsOn = false;
            }
        }
        private void Sync_Toggled(object sender, RoutedEventArgs e)
        {
            if (Sync.IsOn == true)
                Phone_sync.IsEnabled = true;
            else
                Phone_sync.IsEnabled = false;
        }
        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            OS = 0; RAM = 0; ROM = 0; kernels = 0; VideoCard = 0;
            if (Mobile.IsOn == true)
                type = "Laptop or Tablet";
            else
                type = "PC or Laptop";
            if (pro.IsOn == true)
            {
                RAM += 4; ROM += 100; kernels += 2; OS = 12;
                СPU_model = "Intel Core i5";
                if (pro_adobe.IsOn == true)
                {
                    VideoCard += 2; kernels += 1;
                    //VideoCard_model = "Invidia GeForce GTX";
                }
                if (pro_vr.IsOn == true)
                {
                    VideoCard += 2; kernels += 2; CPU += 1.5; RAM += 2;
                    //VideoCard_model = "Invidia GeForce GTX";
                }
                if (Develop_purpose.IsChecked == true)
                {
                    OS = 124;
                    RAM += 2; kernels += 2;
                    typeCPU = "x64";
                }
            }
            if (bigROM.IsOn == true)
            {
                ROM += 1024;
            }
            /*if (Assembly.IsOn == true)
            {
                if (Purpose.IsOn == false)
                {
                    OS = 2;
                }
                else
                    OS = 1;
            }*/
            if (Ecosystem.IsOn == true)
            {
                if (Work_purpose.IsChecked == true)
                {
                    if (Develop_purpose.IsChecked == true)
                        OS = 1;
                    else
                        OS = 12;
                }

                else if (Work_purpose.IsChecked == true && pro_adobe.IsOn == true)
                    OS = 2;
                else
                    OS = 123;
            }
            if (Assembly.IsOn == true)
            {
                if (OS == 1 || OS == 134 || OS == 123 && Mobile.IsOn == true)
                    model = "Surface";
                else if (OS == 1 || OS == 134 || OS == 123 && Mobile.IsOn == false)
                    model = "Lenovo";
                else if (OS == 2 || OS == 124 && Work_purpose.IsChecked == true)
                    model = "MacBook Pro";
                else if (OS == 2 || OS == 124 && Work_purpose.IsChecked == false)
                    model = "MacBook Air";
            }
            if (Gaming_purpose.IsChecked == true)
            {
                OS = 1; RAM = 16; ROM = 1524; CPU = 4.0; kernels = 8; VideoCard = 6;
                VideoCard_model = "Invidia GeForce RTX"; СPU_model = "Intel Core i9";
                if (Mobile.IsOn == true)
                    type = "Laptop";
                else
                    type = "PC";
                Image_Logo.Source = new BitmapImage(new Uri("ms-appx:///Assets/LogoManufacture/Windows8.png"));
                Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualPictures/PC/GamingPC.png"));
            }
            if (OS == 1 || OS == 12 && Home_purpose.IsEnabled == true && pro_vr.IsOn == true)
            {
                OS_str = "Windows"; OS = 1;
            }
            else if (OS == 12 && pro_adobe.IsOn == true && Work_purpose.IsEnabled == true)
            {
                OS_str = "MacOS"; OS = 2;
            }
            else if (OS == 123 || OS == 134 && Home_purpose.IsEnabled == true && Work_purpose.IsEnabled == false && pro_adobe.IsOn == true)
            {
                OS_str = "Chrome OS"; OS = 3;
            }
            else if (OS == 123 || OS == 134 || OS == 124 && Gaming_purpose.IsEnabled == false && pro_adobe.IsOn == false)
            {
                OS_str = "Linux"; OS = 4;
            }
            if (OS == 2)
            {
                if (type == "Laptop" || type == "Laptop or Tablet")
                {
                    model = "MacBook Pro";
                    type = "Laptop";
                }
                else if (Home_purpose.IsEnabled == true && Mobile.IsOn == false && type == "PC or Laptop")
                {
                    model = "iMac";
                    type = "PC";
                }
                else
                {
                    model = "MacBook Air";
                    type = "Laptop";
                }
                OS_str = "MacOS";
                СPU_model = "Apple M1";
                typeCPU = "ARM";

            }
            else if (OS == 3)
            {
                model = "ChromeBook";
            }
            if (Accuracy.IsChecked == false)
            {
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
                else if (ROM >= 1025)
                    ROM = 2048;
            }
            if (VideoCard == 0)
                VideoCard = 1;
            Final_Result();
            Picture();
        }
        public async void Final_Result()
        {
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse();
            ContentDialog Result = new ContentDialog();
            Result.Title = resourceLoader.GetString("Result");
            Result.Content = resourceLoader.GetString("Model_str") + model + "\n" +
                            "Рекомандованные для Вас характеристики ПК:" + "\n" +
                            resourceLoader.GetString("OS") + OS_str + "\n" +
                            resourceLoader.GetString("TypeDevice") + type + "\n" +
                            resourceLoader.GetString("RAM") + RAM + " GB (" + typeRAM + ")" + "\n" + resourceLoader.GetString("ROM") + ROM + " GB" + "\n" +
                            "CPU: " + СPU_model + "(NOT WORKED)" + resourceLoader.GetString("CPU") + CPU + resourceLoader.GetString("Processor_architecture") + typeCPU + "\n" +
                            resourceLoader.GetString("VideoCard") + VideoCard_model + " (NOT WORKED), " + resourceLoader.GetString("ROMvideo") + VideoCard + " GB";
            Result.CloseButtonText = resourceLoader.GetString("Okay");
            Result.XamlRoot = FullPage.XamlRoot;
            ContentDialogResult result = await Result.ShowAsync();
        }
        private void Picture()
        {
            if (OS == 2 || model == "MacBook Pro" || model == "MacBook Air")
            {
                Image_Logo.Source = new BitmapImage(new Uri("ms-appx:///Assets/LogoManufacture/Apple.png"));
                Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualPictures/PC/MacBook_Air.png"));
            }
            else if (model == "Surface")
            {
                Image_Logo.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualPictures/PC/Surface.png"));
            }
            else if (type == "PC or laptop" || type == "Tablet")
            {
                Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/LogoManufacture/Surface.png"));
            }
            else if (model == "Lenovo")
            {
                Image_Logo.Source = new BitmapImage(new Uri("ms-appx:///Assets/LogoManufacture/Lenovo.png"));
                if (Work_purpose.IsEnabled == true && Gaming_purpose.IsEnabled == false)
                    Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualPictures/PC/LenovoThinkPad.png"));
                else
                    Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualPictures/PC/LenovoIdeaPad.png"));

            }
            if (model == "Everything with Gaming")
                Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualPictures/PC/GamingPC.png"));

        }
    }
}
