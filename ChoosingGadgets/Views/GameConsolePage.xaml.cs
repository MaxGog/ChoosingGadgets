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
    public partial class GameConsolePage : ContentPage
    {
        public bool home, work, gaming, apps, software, material, rom, cloud, adobe;
        public GameConsolePage()
        {
            InitializeComponent();
        }
        private void FinishButton_Clicked(object sender, EventArgs e)
        {
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