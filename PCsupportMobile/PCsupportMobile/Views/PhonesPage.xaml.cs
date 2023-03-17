using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCsupportMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhonesPage : ContentPage
    {
        private int RAM = 0, ROM = 0;
        private string model, pay = "Any", result;
        private double CPU = 0.5;
        int iphone = 0, android = 0;
        public bool home, work, gaming, apps, software, material, rom, cloud, adobe;
        public PhonesPage()
        {
            InitializeComponent();
        }
        private async void FinishButton_Clicked(object sender, EventArgs e)
        {
            RAM = 1; ROM = 8; iphone = 0; android = 1;
            if (software == true)
            {
                RAM += 4; iphone = 1; ROM += 32; android = 0;
            }
            if (rom == true)
            {
                android = 1; ROM += 16;
            }
            if (cloud == true)
            {
                if (rom == false)
                    iphone = 1;
                else
                    android = 1;
                CPU += 1.0;
            }
            if (apps == true)
            {
                ROM += 32;
            }
            if (gaming == true)
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

            result = "Модель: " + model + "\n" +
                           "Оперативная память: " + RAM + "\n" +
                           "Внутренняя память: " + ROM + "\n" +
                           "Платёжная система: " + pay;
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
        private void Cloud_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            cloud = true;
        }
        private void Offline_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            cloud = false;
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
        private void MaterialYes_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            material = true;
        }
        private void MaterialNo_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            material = false;
        }
        private void AdobeYes_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            adobe = true;
        }
        private void AdobeNo_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            adobe = false;
        }
        private void AppsYes_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            adobe = true;
        }
        private void AppsNo_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            adobe = false;
        }
    }
}