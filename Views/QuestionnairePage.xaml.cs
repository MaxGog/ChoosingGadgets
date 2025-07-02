using ChoosingGadgets.Models;
using ChoosingGadgets.Repositories;
using ChoosingGadgets.ViewModels;
using Microsoft.Extensions.Logging;

namespace ChoosingGadgets.Views;

public partial class QuestionnairePage : ContentPage
{
    private readonly DeviceRepository _deviceRepository;
    private readonly ILogger<ResultsPage> _logger;

    public QuestionnairePage(DeviceRepository deviceRepository, ILogger<ResultsPage> logger)
    {
        InitializeComponent();
        _deviceRepository = deviceRepository;
        _logger = logger;
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        var preferences = new UserPreferences
        {
            Budget = BudgetPicker.SelectedIndex + 1,
            PrimaryUse = GetPrimaryUse(UsagePicker.SelectedIndex),
            FormFactor = FormFactorPicker.SelectedIndex,
            BrandPreference = BrandPicker.SelectedIndex,
            SoftwareRequirements = GetSoftwareRequirements(),
            PerformancePriority = (int)PerformanceSlider.Value,
            UpgradePlanned = UpgradePicker.SelectedIndex,
            NeedsRussianSoftware = RussianSoftwareSwitch.IsToggled,
            EnergyEfficient = EnergyEfficiencySwitch.IsToggled,
            WarrantyRequirement = WarrantyPicker.SelectedIndex
        };

        Preferences.Set("UserBudget", preferences.Budget);
        Preferences.Set("UserPrimaryUse", preferences.PrimaryUse);

        await Navigation.PushAsync(new ResultsPage(
            preferences, 
            _deviceRepository, 
            _logger));
    }

    private string GetPrimaryUse(int index)
    {
        return index switch
        {
            0 => "office",
            1 => "gaming",
            2 => "design",
            3 => "video",
            4 => "programming",
            5 => "media",
            _ => "general"
        };
    }

    private string GetSoftwareRequirements()
    {
        var software = new List<string>();
        
        if (OfficeCheckBox.IsChecked) software.Add("office");
        if (CadCheckBox.IsChecked) software.Add("cad");
        if (VideoCheckBox.IsChecked) software.Add("video");
        if (IdeCheckBox.IsChecked) software.Add("programming");
        if (GamingCheckBox.IsChecked) software.Add("gaming");
        
        return string.Join(",", software);
    }
}