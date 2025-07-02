namespace ChoosingGadgets.Models;

public class UserPreferences
{
    // 1. Бюджет (рубли)
    public int Budget { get; set; } 
    // 1: <50k ₽, 2: 50-100k ₽, 3: 100-150k ₽, 4: 150-200k ₽, 5: >200k ₽

    // 2. Основное назначение
    public string PrimaryUse { get; set; } 
    // office, gaming, design, video, programming, media, general

    // 3. Форм-фактор
    public int FormFactor { get; set; }
    // 0: Desktop, 1: Laptop, 2: MiniPC, 3: AllInOne, 4: Any

    // 4. Предпочтения по производителю
    public int BrandPreference { get; set; }
    // 0: Russian brands, 1: International, 2: Custom build, 3: Any

    // 5. Программное обеспечение
    public string SoftwareRequirements { get; set; } 
    // comma-separated: office, cad, video, programming, gaming

    // 6. Приоритет производительности
    public int PerformancePriority { get; set; } // 1-5

    // 7. Планы на апгрейд
    public int UpgradePlanned { get; set; }
    // 0: Yes, 1: Maybe, 2: No

    // 8. Поддержка российского ПО
    public bool NeedsRussianSoftware { get; set; }

    // 9. Энергоэффективность
    public bool EnergyEfficient { get; set; }

    // 10. Гарантия
    public int WarrantyRequirement { get; set; }
    // 0: 1 year, 1: 2 years, 2: 3+ years, 3: Any

    // Устаревшее свойство (оставлено для обратной совместимости)
    [Obsolete("Use FormFactor instead")]
    public bool PortabilityImportant { get; set; }
}