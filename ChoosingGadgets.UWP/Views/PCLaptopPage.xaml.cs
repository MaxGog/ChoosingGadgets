using System;

using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace ChoosingGadgets.UWP.Views
{
    public sealed partial class PCLaptopPage : Page
    {
        public string type = "PC or Laptop", model = "Surface", СPU_model = "Intel", image = @"Surface_model.png", ROM_str, OS_str;
        public string typeCPU = "x64", VideoCard_model = "Invidia", typeRAM = "DDR4";
        private int OS = 0, RAM = 0, ROM = 0, kernels = 0, VideoCard = 0;
        private int WinOS = 0, MacOS = 0, UnixOS = 0, ChromeOS = 0;
        private double CPU = 1.5;
        public PCLaptopPage()
        {
            this.InitializeComponent();
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
            ApplicationView.GetForCurrentView().Title = resourceLoader.GetString("TitleChooseLaptop");
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
            OS = 0; RAM = 0; ROM = 0; kernels = 0;
            VideoCard = 0; WinOS = 0; MacOS = 0; UnixOS = 0; ChromeOS = 0;
            type = Mobile.IsOn == true ? "Laptop or Tablet" : "PC or Laptop";
            if (pro.IsOn == true)
            {
                RAM += 4;
                ROM += 100;
                kernels += 2;
                WinOS += 2;
                MacOS += 1;
                СPU_model = "Intel Core i5";
                if (pro_adobe.IsOn == true)
                {
                    VideoCard += 2;
                    kernels += 1;
                    WinOS += 1;
                    MacOS += 2;
                    //VideoCard_model = "Invidia GeForce GTX";
                }
                if (pro_vr.IsOn == true)
                {
                    VideoCard += 2;
                    kernels += 2;
                    CPU += 1.5;
                    RAM += 2;
                    WinOS += 1;
                    //VideoCard_model = "Invidia GeForce GTX";
                }
                if (Develop_purpose.IsChecked == true)
                {
                    RAM += 2;
                    kernels += 2;
                    typeCPU = "x64";
                    WinOS += 2;
                    UnixOS += 2;
                    MacOS += 1;
                }
            }
            if (bigROM.IsOn == true)
            {
                ROM += 1024;
            }
            if (Ecosystem.IsOn == true)
            {
                if (Work_purpose.IsChecked == true)
                {
                    if (Develop_purpose.IsChecked == true)
                        WinOS += 2;
                    else
                    {
                        WinOS += 1;
                        MacOS += 1;
                    }
                }

                else if (Work_purpose.IsChecked == true && pro_adobe.IsOn == true)
                    MacOS += 1;
                else
                {
                    WinOS += 1;
                    MacOS += 1;
                    ChromeOS += 1;
                }
            }
            if (Phone_sync.IsOn == true)
            {
                WinOS += 2;
            }
            else
            {
                MacOS += 2;
            }

            if (WinOS > MacOS || WinOS > UnixOS || WinOS > ChromeOS)
            {
                OS = 1;
            }
            if (WinOS < MacOS || MacOS > UnixOS || MacOS > ChromeOS)
            {
                OS = 2;
            }
            if (ChromeOS > MacOS || ChromeOS > UnixOS || WinOS < ChromeOS)
            {
                OS = 3;
            }
            if (UnixOS > MacOS || WinOS < UnixOS || UnixOS < ChromeOS)
            {
                OS = 4;
            }

            if (OS == 1)
            {
                OS_str = "Windows";
                OS = 1;
                Image_Logo.Source = new BitmapImage(new Uri("ms-appx:///Assets/Windows.png"));
                Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/Surface.png"));
            }
            else if (OS == 2 && StorePrice.Value >= 50)
            {
                Image_Logo.Source = new BitmapImage(new Uri("ms-appx:///Assets/Apple.png"));
                Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/MacBook_Air.png"));
                OS = 2;
                if (type == "Laptop" || type == "Laptop or Tablet")
                {
                    model = "MacBook Pro";
                    type = "Laptop";
                    Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/MacBook_Air.png"));
                }
                else if (Home_purpose.IsEnabled == true || Mobile.IsOn == false || type == "PC or Laptop" && StorePrice.Value >= 70)
                {
                    model = "iMac";
                    type = "PC";
                    ROM = 16;
                    //Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/iMac.png"));
                }
                else
                {
                    model = "MacBook Air";
                    type = "Laptop";
                    Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/MacBook_Air.png"));
                }
                OS_str = "MacOS";
                СPU_model = "Apple M1";
                typeCPU = "ARM";
            }
            else if (OS == 3)
            {
                OS = 3;
                OS_str = "Chrome OS";
                model = "ChromeBook";
                Image_Logo.Source = new BitmapImage(new Uri("ms-appx:///Assets/ChromeOS.png"));
                Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/MonoPC.png"));
            }
            else if (OS == 4)
            {
                OS_str = "Linux";
                OS = 4;
                Image_Logo.Source = new BitmapImage(new Uri("ms-appx:///Assets/Linux.png"));
                Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/MonoPC.png"));
            }
            else
            {
                OS_str = "Windows";
                OS = 1;
                type = "Laptop";
                Image_Logo.Source = new BitmapImage(new Uri("ms-appx:///Assets/Windows.png"));
                Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/Lenovo.png"));
            }
            if (Accuracy.IsChecked == false)
            {
                if (ROM <= 64)
                    ROM = 64;
                if (RAM <= 4)
                    RAM = 4;
                if (ROM >= 65 && ROM <= 128)
                    ROM = 128;
                else if (ROM >= 129 && ROM <= 512 && StorePrice.Value >= 50)
                    ROM = 512;
                else if (ROM >= 513 && ROM <= 1024 && StorePrice.Value >= 50)
                    ROM = 1024;
                else if (ROM >= 1025 && StorePrice.Value >= 50)
                    ROM = 2048;
                else if (StorePrice.Value <= 50)
                    ROM = 128;
            }
            if (VideoCard == 0 && StorePrice.Value >= 40)
                VideoCard = 1;
            if (model == "Lenovo")
            {
                Image_Logo.Source = new BitmapImage(new Uri("ms-appx:///Assets/Lenovo.png"));
                if (Work_purpose.IsEnabled == true && Gaming_purpose.IsEnabled == false)
                    Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/LenovoThinkPad.png"));
                else
                    Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/LenovoIdeaPad.png"));

            }
            else
                Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/PCLaptop.png"));
            if (Gaming_purpose.IsChecked == true)
            {
                RAM = 16;
                ROM = 1524;
                CPU = 4.0;
                kernels = 8;
                VideoCard = 6;
                VideoCard_model = "Invidia GeForce RTX"; СPU_model = "Intel Core i9";
                if (Mobile.IsOn == true)
                {
                    type = "Laptop";
                    model = "Gaming laptop";
                }
                else
                {
                    type = "PC";
                    model = "Gaming PC";
                }
                OS_str = "Windows";
                Image_Logo.Source = new BitmapImage(new Uri("ms-appx:///Assets/Windows.png"));
                Image_Model.Source = new BitmapImage(new Uri("ms-appx:///Assets/GamingPC.png"));
            }
            Final_Result();
        }
        public async void Final_Result()
        {
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
            ContentDialog Result = new ContentDialog()
            {
                Title = resourceLoader.GetString("Result"),
                Content = //resourceLoader.GetString("Model_str") + model + "\n" +
                          //"Рекомандованные для Вас характеристики ПК:" + "\n" +
                            resourceLoader.GetString("OS") + OS_str + "\n" +
                            resourceLoader.GetString("TypeDevice") + type + "\n" +
                            resourceLoader.GetString("RAM") + RAM + " GB (" + typeRAM + ")" + "\n" + resourceLoader.GetString("ROM") + ROM + " GB" + "\n" +
                            "CPU: " + СPU_model + resourceLoader.GetString("CPU") + CPU + resourceLoader.GetString("Processor_architecture") + typeCPU + "\n" +
                            resourceLoader.GetString("VideoCard") + VideoCard_model + ", " + resourceLoader.GetString("ROMvideo") + VideoCard + " GB",
                PrimaryButtonText = resourceLoader.GetString("Okay"),
            };
            ContentDialogResult result = await Result.ShowAsync();
        }
    }
}
