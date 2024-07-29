using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace ChoosingGadgets.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PCLaptopsPage : ContentPage
    {
        public string type = "PC or Laptop", model = "Surface", СPU_model = "Intel", ROM_str, OS_str;
        private int WinOS = 0, MacOS = 0, UnixOS = 0, ChromeOS = 0;
        public string typeCPU = "x64", VideoCard_model = "Invidia", typeRAM = "DDR4", result;
        public bool home, work, gaming, mobile, software, android, iphone, material, rom, draw, adobe;
        private int OS = 0, RAM = 0, ROM = 0, kernels = 0, VideoCard = 0;
        private double CPU = 1.5;
        public PCLaptopsPage()
        {
            InitializeComponent();
        }
        private void FinishButton_Clicked(object sender, EventArgs e)
        {
            OS = 0; WinOS = 0; MacOS = 0; UnixOS = 0; ChromeOS = 0;
            RAM = 0; ROM = 0; kernels = 0; VideoCard = 0;
            if (mobile == true)
            {
                type = "Laptop or Tablet";
                WinOS += 1;
                ChromeOS += 1;
            }
            else
            {
                type = "PC or Laptop";
            }
            if (software == true)
            {
                RAM += 4;
                ROM += 100;
                kernels += 2;
                OS = 12;
                MacOS += 1;
                WinOS += 1;
                СPU_model = "Intel Core i5";
                if (adobe == true)
                {
                    VideoCard += 2;
                    kernels += 1;
                    MacOS += 2;
                    WinOS += 1;
                }
            }
            if (rom == true)
            {
                ROM += 1024;
            }
            if (material == true)
            {
                MacOS += 1;
                WinOS += 1;
                ChromeOS += 1;
            }
            if (android == true)
            {
                WinOS += 1;
                ChromeOS += 1;
                MacOS -= 1;
            }
            if (iphone == true)
            {
                WinOS += 1;
                MacOS += 2;
            }
            if (draw == true)
            {
                WinOS += 1;
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
            }
            else if (OS == 2)
            {
                if (type == "Laptop" || type == "Laptop or Tablet")
                {
                    model = "MacBook Pro";
                    type = "Laptop";
                }
                else if (home == true && mobile == false && type == "PC or Laptop")
                {
                    model = "iMac";
                    type = "PC";
                    ROM = 8;
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
                OS_str = "Chrome OS";
                model = "ChromeBook";
            }
            else if (OS == 4)
            {
                OS_str = "Linux";
            }
            else
            {
                OS_str = "Windows";
                OS = 1;
            }
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
            if (gaming == true)
            {
                RAM = 16;
                ROM = 1524;
                CPU = 4.0;
                kernels = 8;
                VideoCard = 6;
                VideoCard_model = "Invidia GeForce RTX"; СPU_model = "Intel Core i9";
                if (mobile == true)
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
            }
            Final_Result();
        }
        public async void Final_Result()
        {
            result = "Модель: " + model + "\n" +
                            //"Рекомандованные для Вас характеристики ПК:" + "\n" +
                            "ОС: " + OS_str + "\n" +
                            "Тип: " + type + "\n" +
                            "Оперативная память: " + RAM + " GB (" + typeRAM + ")" + "\n" + "Внутренняя память: " + ROM + " GB" + "\n" +
                            "Процессор: " + СPU_model + ", частота процессора: " + CPU + ", архитектура процессора: " + typeCPU; //+ "\n"
                                                                                                                                 //"Графический процессор: " + VideoCard_model + ", " + " Видеопамять: " + VideoCard + " GB";
            await DisplayAlert("Результат", result, "OK");
        }
        private void Home_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            home = true;
            work = false;
            gaming = false;

        }
        private void Work_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            home = false;
            work = true;
            gaming = false;

        }
        private void Gaming_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            home = false;
            work = false;
            gaming = true;

        }
        private void MobileYes_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            mobile = true;
        }
        private void MobileNo_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            mobile = false;
        }
        private void SoftwareYes_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            software = true;
        }
        private void SoftwareNo_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            software = false;
        }
        private void ROMYes_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            rom = true;
        }
        private void ROMNo_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            rom = false;
        }
        private void Android_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            android = true;
            iphone = false;
        }
        private void iPhone_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            android = false;
            iphone = true;
        }
        private void MaterialYes_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            material = true;
        }
        private void MaterialNo_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            material = false;
        }
        private void DrawYes_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            draw = true;
        }
        private void DrawNo_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            draw = false;
        }
        private void AdobeYes_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            adobe = true;
        }
        private void AdobeNo_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            adobe = false;
        }
    }
}