using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChoosingGadgets.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhonesPage : ContentPage
    {
        private int RAM = 0, ROM = 0;
        private int Huawei = 0, Samsung = 0, Xiaomi = 0, iphone = 0;
        private string model, pay = "Any", result;
        private double CPU = 0.5;
        public bool home, work, gaming, apps, software, material, rom, cloud, adobe, limitedPrice;
        public PhonesPage()
        {
            InitializeComponent();
        }
        private async void FinishButton_Clicked(object sender, EventArgs e)
        {
            RAM = 1; ROM = 8; iphone = 0;
            Huawei = 0; Samsung = 0; Xiaomi = 0;

            if (software == true)
            {
                RAM += 4; iphone = 1; ROM += 32;
            }
            if (rom == true)
            {
                ROM += 16;
            }
            if (cloud == true)
            {
                CPU += 1.0;
            }
            if (apps == true)
            {
                ROM += 32; Samsung += 1;
            }
            if (gaming == true)
            {
                RAM += 4; ROM += 32; Xiaomi += 1; Samsung += 1;
            }
            else if (work == true)
            {
                iphone += 1; Samsung += 1;
            }
            else if (home == true)
            {
                Huawei += 1;
            }
            if (limitedPrice == true)
            {
                Huawei += 1;
                Xiaomi += 2;
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

            if (iphone > Samsung && iphone > Xiaomi && iphone > Huawei)
            {
                model = "iPhone";
            }
            else if (Samsung > iphone && Samsung > Xiaomi && Samsung > Huawei)
            {
                model = "Samsung";
            }
            else if (Huawei > iphone && Huawei > Xiaomi && Samsung < Huawei)
            {
                model = "Huawei";
            }
            else if (Xiaomi > iphone && Samsung < Xiaomi && Xiaomi > Huawei || limitedPrice == true)
            {
                model = "Xiaomi";
            }
            else
            {
                model = "Samsung";
            }
            result = "На 2023-2024 год:" + "\n" +
                "Бренд смартфона: " + model + "\n" +
                           "Оперативная память: " + RAM + "\n" +
                           "Внутренняя память: " + ROM + "\n";
            await DisplayAlert("Результат", result, "OK");
        }
        private void Home_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            home = true;
            work = false;
            gaming = false;

        }

        private void LimitedPriceYes_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            limitedPrice = true;
        }

        private void LimitedPriceNo_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            limitedPrice = false;
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