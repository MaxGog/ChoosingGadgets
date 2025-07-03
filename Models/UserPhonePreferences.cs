namespace ChoosingGadgets.Models;

public class UserPhonePreferences
{
    public int Budget { get; set; } // 1-5
    public string PrimaryUse { get; set; } // daily, gaming, photo, business, premium
    public int BrandPreference { get; set; } // 0-4
    public string Features { get; set; } // comma-separated features
    public int PerformancePriority { get; set; } // 1-5
    public int ScreenSizePreference { get; set; } // 0-4
    public bool NeedsRussianSoftware { get; set; }
    public bool Needs5G { get; set; }
    public int WarrantyRequirement { get; set; } // 0-3
}