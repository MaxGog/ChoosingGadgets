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
            PortabilityImportant = PortabilitySwitch.IsToggled,
            SoftwareRequirements = GetSoftwareRequirements(),
            PerformancePriority = (int)PerformanceSlider.Value
        };

        Preferences.Set("UserBudget", preferences.Budget);
        Preferences.Set("UserPrimaryUse", preferences.PrimaryUse);
        Preferences.Set("UserPortability", preferences.PortabilityImportant);
        Preferences.Set("UserSoftware", preferences.SoftwareRequirements);
        Preferences.Set("UserPerformance", preferences.PerformancePriority);

        await Navigation.PushAsync(new ResultsPage(
            preferences, 
            _deviceRepository, 
            _logger));
    }

    private string GetPrimaryUse(int index)
    {
        return index switch
        {
            0 => "work",
            1 => "gaming",
            2 => "design",
            3 => "general",
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
        
        return string.Join(",", software);
    }
}