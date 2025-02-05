using ChoosingGadgets.Models;

namespace ChoosingGadgets.Views;

public partial class ChooseLaptopPage : ContentPage
{
    private int usageScenario = 1, outerPeriphery = 1, fileStorage = 1, placeWork = 1, ecosystem = 1;
    private bool adobeUse = false, officeUse = false, devUse = false, specialUse = false, threedUse = false;
    public ChooseLaptopPage()
    {
        InitializeComponent();
    }

    private async void GetResultBtnClicked(object sender, EventArgs e)
    {
        ChooseLaptopModel laptop = new();
        SpecificationsModel specifications = new() { cpuClock = 1.6f, RAM = 8, ROM = 128 };

        if (usageScenario == 1) { laptop.AddMacBookAirScore(1); laptop.AddChromebookScore(1); specifications.RAM = 8; }
        else if (usageScenario == 2) { laptop.AddPCScore(1); 
            laptop.AddMacBookAirScore(1); laptop.AddChromebookScore(1); specifications.RAM = 8; }
        else if (usageScenario == 3) { laptop.AddLaptopOfficeScore(3); laptop.AddLenovoThinkPadScore(2); 
            laptop.AddMacBookProScore(2); laptop.AddPCScore(1); laptop.AddSurfaceProScore(2); specifications.RAM = 16;}
        else if (usageScenario == 4) { laptop.AddLaptopGamingScore(3); laptop.AddPCScore(1); specifications.RAM = 16; 
            specifications.cpuClock = 2.4f; }
        
        if (outerPeriphery == 1) { laptop.AddPCScore(2); laptop.AddMacBookProScore(1); laptop.AddLaptopGamingScore(2); }
        else if (outerPeriphery == 2) { laptop.AddPCScore(1);  laptop.AddMacBookProScore(2);  
            laptop.AddMacBookAirScore(1); laptop.AddSurfaceProScore(1);  laptop.AddLaptopOfficeScore(2); }
        else if (outerPeriphery == 3)  {  laptop.AddMacBookAirScore(1);  laptop.AddSurfaceProScore(2);
            laptop.AddChromebookScore(1); }

        if (fileStorage == 1) { specifications.ROM = 1024; }
        else if (fileStorage == 2) { laptop.AddMacBookAirScore(1); laptop.AddLaptopGamingScore(1); 
            laptop.AddLaptopOfficeScore(2); specifications.ROM = 512; }
        else if (fileStorage == 3) {laptop.AddMacBookAirScore(1); laptop.AddSurfaceProScore(2); laptop.AddChromebookScore(1); 
            specifications.ROM = 256; }

        if (placeWork == 1) { laptop.AddPCScore(2); laptop.AddLaptopGamingScore(2); laptop.AddMacBookProScore(1); }
        else if (placeWork == 2) { laptop.AddLaptopOfficeScore(1); 
            laptop.AddMacBookProScore(1); laptop.AddLenovoThinkPadScore(1); }
        else if (placeWork == 3) { laptop.AddSurfaceProScore(1); laptop.AddMacBookAirScore(1); 
            laptop.AddChromebookScore(2); laptop.AddLaptopOfficeScore(2); laptop.SetPCScore(0);}

        if (ecosystem == 1) { laptop.AddChromebookScore(1); laptop.AddSurfaceProScore(1); laptop.AddLenovoThinkPadScore(2); }
        else if (ecosystem == 2) { laptop.AddMacBookProScore(4); laptop.AddMacBookAirScore(4); }
        else if (ecosystem == 3) { laptop.AddSurfaceProScore(2); laptop.AddLenovoThinkPadScore(1); }
        else if (ecosystem == 4) { laptop.AddLaptopGamingScore(2); laptop.AddPCScore(1); }

        if (adobeUse) { laptop.AddMacBookAirScore(1); laptop.AddMacBookProScore(1); 
            laptop.AddLaptopGamingScore(2); laptop.AddPCScore(1); specifications.RAM += 4; specifications.ROM += 128; }
        if (devUse) { laptop.AddMacBookProScore(2); laptop.AddPCScore(1); 
            laptop.AddLenovoThinkPadScore(1); laptop.AddSurfaceProScore(1); 
            specifications.RAM += 4; specifications.cpuClock = 2.4f;}
        if (officeUse) { laptop.AddLaptopOfficeScore(2); laptop.AddPCScore(1); 
            laptop.AddLaptopGamingScore(1); laptop.AddLenovoThinkPadScore(2); }
        if (specialUse) { laptop.AddLenovoThinkPadScore(2); laptop.AddLaptopGamingScore(1); laptop.AddSurfaceProScore(1); }
        if (threedUse) { specifications.RAM += 8; specifications.ROM += 128; 
            specifications.cpuClock = 2.4f; laptop.AddPCScore(1); laptop.AddLaptopGamingScore(1); }

        if (specifications.RAM >= 32) { specifications.RAM = 32; }
        else if (specifications.RAM >= 32 && (usageScenario == 1 || usageScenario == 2)) { specifications.RAM = 16; }
        
        if (specifications.ROM >= 1024) { specifications.ROM = 1024; }

        string result = laptop.GetBestLaptop();
        string descriptionResult = $"Самое оптимальное, что мы смогли подобрать, это {result}" + 
            $"\nОперативная память: минимум {specifications.RAM} ГБ" +
            $"\nПостоянной памяти: минимум {specifications.ROM} ГБ" +
            $"\nЧастота процессора: минимум {specifications.cpuClock} ГГц";
        await DisplayAlert($"Лучший вариант для Вас: {result}",  descriptionResult, "Спасибо!");
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
    private void ThreedCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e) => threedUse = e.Value;
}