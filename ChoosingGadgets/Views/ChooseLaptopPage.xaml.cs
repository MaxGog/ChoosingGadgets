using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using ChoosingGadgets.Models;

namespace ChoosingGadgets.Views;

public partial class ChooseLaptopPage : ContentPage
{
    private int usageScenario, outerPeriphery, fileStorage, placeWork, ecosystem;
    private bool adobeUse = false, officeUse = false, devUse = false, specialUse = false;
    public ChooseLaptopPage()
    {
        InitializeComponent();
    }

    private async void GetResultBtnClicked(object sender, EventArgs e)
    {
        ChooseLaptopModel laptop = new();

        if (usageScenario == 1) { laptop.AddMacBookAirScore(1); laptop.AddChromebookScore(1); }
        else if (usageScenario == 2) { laptop.AddPCScore(1); laptop.AddMacBookAirScore(1); laptop.AddChromebookScore(1); }
        else if (usageScenario == 3) { laptop.AddLaptopOfficeScore(1); laptop.AddLenovoThinkPadScore(2); laptop.AddMacBookProScore(2); laptop.AddPCScore(1); laptop.AddSurfaceProScore(1); }
        else if (usageScenario == 4) { laptop.AddLaptopGamingScore(2); laptop.AddPCScore(1); }
        
        if (outerPeriphery == 1) { laptop.AddPCScore(2); laptop.AddMacBookProScore(1); laptop.AddLaptopGamingScore(1); }
        else if (outerPeriphery == 2) { laptop.AddPCScore(1);  laptop.AddMacBookProScore(1);  laptop.AddMacBookAirScore(1); laptop.AddSurfaceProScore(1);  laptop.AddLaptopOfficeScore(1); }
        else if (outerPeriphery == 3)  {  laptop.AddMacBookAirScore(1);  laptop.AddSurfaceProScore(1); laptop.AddChromebookScore(1); }

        if (fileStorage == 1) { laptop.AddPCScore(1); laptop.AddMacBookProScore(1); }
        else if (fileStorage == 2) { laptop.AddMacBookAirScore(1); laptop.AddLaptopGamingScore(1); laptop.AddLaptopOfficeScore(1); }
        else if (fileStorage == 3) {laptop.AddMacBookAirScore(1); laptop.AddSurfaceProScore(1); laptop.AddChromebookScore(1); }

        if (placeWork == 1) { laptop.AddPCScore(2); laptop.AddLaptopGamingScore(1); laptop.AddMacBookProScore(1); }
        else if (placeWork == 2) { laptop.AddLaptopOfficeScore(1); laptop.AddMacBookProScore(1); laptop.AddLenovoThinkPadScore(1); }
        else if (placeWork == 3) { laptop.AddSurfaceProScore(2); laptop.AddMacBookAirScore(1); laptop.AddChromebookScore(1); }

        if (ecosystem == 1) { laptop.AddChromebookScore(1); laptop.AddSurfaceProScore(1); laptop.AddLenovoThinkPadScore(1); }
        else if (ecosystem == 2) { laptop.AddMacBookProScore(2); laptop.AddMacBookAirScore(2); }
        else if (ecosystem == 3) { laptop.AddSurfaceProScore(1); laptop.AddLenovoThinkPadScore(1); }
        else if (ecosystem == 4) { laptop.AddLaptopGamingScore(1); laptop.AddPCScore(1); }

        if (adobeUse) { laptop.AddMacBookAirScore(1); laptop.AddMacBookProScore(1); laptop.AddLaptopGamingScore(1); laptop.AddPCScore(1); }
        if (devUse) { laptop.AddMacBookProScore(1); laptop.AddPCScore(1); laptop.AddLenovoThinkPadScore(1); laptop.AddSurfaceProScore(1); }
        if (officeUse) { laptop.AddLaptopOfficeScore(1); laptop.AddPCScore(1); laptop.AddLaptopGamingScore(1); laptop.AddLenovoThinkPadScore(1); }
        if (specialUse) { laptop.AddLenovoThinkPadScore(1); laptop.AddLaptopGamingScore(1); laptop.AddSurfaceProScore(1); }

        string result = laptop.GetBestLaptop();
        await DisplayAlert($"Лучший вариант для Вас: {result}",  $"Самое оптимальное, что мы смогли подобрать, это {result}", "Спасибо!");
    }

    private void UsageScenarioCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        RadioButton selectedRadioButton = ((RadioButton)sender);
        usageScenario = Convert.ToInt32(selectedRadioButton.Value);
    }
    
    private void OuterPeripheryCheckedChanged(object sender, CheckedChangedEventArgs e) => outerPeriphery = Convert.ToInt32(e.Value);
    private void FileStorageCheckedChanged(object sender, CheckedChangedEventArgs e) => fileStorage = Convert.ToInt32(e.Value);
    private void PlaceWorkCheckedChanged(object sender, CheckedChangedEventArgs e) => placeWork = Convert.ToInt32(e.Value);
    private void EcosystemCheckedChanged(object sender, CheckedChangedEventArgs e) => ecosystem = Convert.ToInt32(e.Value);
    private void AdobeCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e) => adobeUse = e.Value;
    private void DevCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e) => devUse = e.Value;
    private void OfficeCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e) => officeUse = e.Value;
    private void SpecialCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e) => specialUse = e.Value;
}