using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace PC_support.DLC
{
    public sealed partial class PCLaptopPage_pro : Page
    {
        public string type = "PC or Laptop", model = "Surface", СPU_model = "Intel", image = @"Surface_model.png", ROM_str, OS_str;
        public string typeCPU = "x64", VideoCard_model = "Invidia", typeRAM = "DDR4", display_min;
        private int OS = 0, RAM = 0, ROM = 0, kernels = 0, VideoCard = 0;
        private double CPU = 1.5;
        public PCLaptopPage_pro()
        {
            this.InitializeComponent();
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            OS = 0;
            RAM = 0;
            ROM = 0;
            kernels = 0;
            VideoCard = 0;
            CPU = 0;
            if (Render_purpose.IsChecked == true)
            {
                OS = 12;
                RAM += 8;
                display_min = "FullHD";
                ROM += 128;
                kernels = 4;
                VideoCard += 2;
                VideoCard_model = "Invidia GeForce RTX";
            }
            if (Photo_purpose.IsChecked == true)
            {
                if (Render_purpose.IsChecked == true)
                    RAM += 2;
                else
                    RAM += 4;
                VideoCard += 2;
                VideoCard_model = "Invidia GeForce RTX";
                OS = 12;
                display_min = "2K";
            }
            if (TheeD_purpose.IsChecked == true)
            {
                if (OS != 12)
                    OS = 124;
                VideoCard += 1;
                if (RAM <= 8)
                    RAM += 4;
            }
            if (Developer_purpose.IsChecked == true)
            {
                kernels += 2;
                if (OS != 12)
                    OS = 124;
                CPU += 2.0;
                RAM += 2;
            }
            if (Gaming_purpose.IsChecked == true)
            {
                kernels = 3;
                OS = 1;
                RAM = 16;
                ROM += 500;
                CPU += 1.5;
                if (display_min != "2K")
                    display_min = "FullHD";
                VideoCard += 2;
                VideoCard_model = "Invidia GeForce RTX";
            }
            if (Work_online_purpose.IsChecked == true)
            {
                if (OS != 1 && Render_purpose.IsChecked == true)
                    OS = 2;
                if (display_min != "2K")
                    display_min = "FullHD";
            }
            if (Work_physic_purpose.IsChecked == true)
            {
                OS = 1;
                if (display_min != "2K")
                    display_min = "FullHD";
                if (RAM <= 12)
                    RAM = 8;
                kernels = 4;
                ROM += 128;
            }
            if (Mobile.IsOn == true)
            {
                type = "Laptop";
            }
            else
            {
                type = "PC";
            }
            if (bigROM.IsOn == true)
            {
                ROM += 500;
            }

            if (OS == 1)
            {
                OS_str = "Windows";
                OS = 1;
            }
            else if (OS == 12)
            {
                OS = 2;
                if (type == "Laptop")
                {
                    model = "MacBook Pro";
                    type = "Laptop";
                }
                else if (type == "PC")
                {
                    model = "iMac";
                    type = "PC";
                    ROM = 8;
                }
                OS_str = "MacOS";
                СPU_model = "Apple M1";
                typeCPU = "ARM";
            }
            else if (OS == 124 && Developer_purpose.IsChecked == true)
            {
                OS_str = "Linux";
                OS = 4;
            }
            else
            {
                OS_str = "Windows";
                OS = 1;
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
        }
        public async void Final_Result()
        {
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
            ContentDialog Result = new ContentDialog()
            {
                Title = resourceLoader.GetString("Result"),
                Content = //"Рекомандованные для Вас характеристики ПК:" + "\n" +
                            resourceLoader.GetString("OS") + OS_str + "\n" +
                            resourceLoader.GetString("TypeDevice") + type + "\n" +
                            resourceLoader.GetString("RAM") + RAM + " GB (" + typeRAM + ")" + "\n" + resourceLoader.GetString("ROM") + ROM + " GB" + "\n" +
                            "CPU: " + СPU_model + resourceLoader.GetString("CPU") + CPU + resourceLoader.GetString("Processor_architecture") + typeCPU + "\n" +
                            resourceLoader.GetString("VideoCard") + VideoCard_model + ", " + resourceLoader.GetString("ROMvideo") + VideoCard + " GB" + "\n" +
                            "Display: " + display_min,
                PrimaryButtonText = resourceLoader.GetString("Okay"),
            };
            ContentDialogResult result = await Result.ShowAsync();
        }
    }
}
