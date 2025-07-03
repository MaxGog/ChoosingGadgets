using ChoosingGadgets.Models;
using ChoosingGadgets.Repositories;
using ChoosingGadgets.ViewModels;
using Microsoft.Extensions.Logging;

namespace ChoosingGadgets.Views;

public partial class QuestionnairePhonePage : ContentPage
{
    private readonly DeviceRepository _deviceRepository;
    private readonly ILogger<ResultsPhonePage> _logger;

    public QuestionnairePhonePage(DeviceRepository deviceRepository, ILogger<ResultsPhonePage> logger)
    {
        InitializeComponent();
        _deviceRepository = deviceRepository;
        _logger = logger;
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        var preferences = new UserPhonePreferences
        {
            Budget = BudgetPicker.SelectedIndex + 1,
            PrimaryUse = GetPrimaryUse(UsagePicker.SelectedIndex),
            BrandPreference = BrandPicker.SelectedIndex,
            Features = GetFeatures(),
            PerformancePriority = (int)PerformanceSlider.Value,
            ScreenSizePreference = ScreenSizePicker.SelectedIndex,
            NeedsRussianSoftware = RussianSoftwareSwitch.IsToggled,
            Needs5G = FiveGSupportSwitch.IsToggled,
            WarrantyRequirement = WarrantyPicker.SelectedIndex
        };

        await Navigation.PushAsync(new ResultsPhonePage(
            preferences, 
            _deviceRepository, 
            _logger));
    }

    private string GetPrimaryUse(int index)
    {
        return index switch
        {
            0 => "daily",
            1 => "gaming",
            2 => "photo",
            3 => "business",
            4 => "premium",
            _ => "general"
        };
    }

    private string GetFeatures()
    {
        var features = new List<string>();
        
        if (GoodCameraCheckBox.IsChecked) features.Add("good_camera");
        if (LongBatteryCheckBox.IsChecked) features.Add("long_battery");
        if (FastChargeCheckBox.IsChecked) features.Add("fast_charge");
        if (WaterResistantCheckBox.IsChecked) features.Add("water_resistant");
        if (HeadphoneJackCheckBox.IsChecked) features.Add("headphone_jack");
        
        return string.Join(",", features);
    }
}