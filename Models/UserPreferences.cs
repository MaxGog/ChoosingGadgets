namespace ChoosingGadgets.Models;

public class UserPreferences
{
    public int Budget { get; set; } // 1: <500$, 2: 500-1000$, 3: 1000-1500$, 4: >1500$
    public string PrimaryUse { get; set; } // work, gaming, design, general
    public bool PortabilityImportant { get; set; }
    public string SoftwareRequirements { get; set; } // office, cad, video, programming
    public int PerformancePriority { get; set; } // 1-5
}