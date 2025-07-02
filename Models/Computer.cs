namespace ChoosingGadgets.Models;

public class Computer : Device
{
    // Основные характеристики
    public string Processor { get; set; }
    public string GPU { get; set; }
    public int RAM { get; set; } // в ГБ
    public string Storage { get; set; }
    public string OS { get; set; }
    
    // Форм-фактор и портативность
    public string FormFactor { get; set; } // "Desktop", "Laptop", "MiniPC", "AllInOne"
    public bool IsDesktop => FormFactor == "Desktop";
    public bool IsLaptop => FormFactor == "Laptop";
    public bool IsMiniPC => FormFactor == "MiniPC";
    public bool IsAllInOne => FormFactor == "AllInOne";
    
    // Совместимость с российским ПО
    public bool SupportsRussianOS { get; set; }
    public bool SupportsRussianCAD { get; set; }
    
    // Энергоэффективность
    public string EnergyEfficiencyClass { get; set; } // "A++", "A+", "A", "B", "C"
    public int PowerConsumption { get; set; } // в ваттах
    
    // Гарантия и обслуживание
    public int WarrantyMonths { get; set; }
    public bool OnsiteService { get; set; }
    
    // Возможность апгрейда
    public bool UpgradeableRAM { get; set; }
    public bool UpgradeableStorage { get; set; }
    public bool UpgradeableGPU { get; set; }
    
    // Дополнительные характеристики
    public bool HasCoolingSystem { get; set; }
    public string Motherboard { get; set; }
    public string PSU { get; set; } // Блок питания
    public string CaseType { get; set; }
    
    // Для ноутбуков
    public float? ScreenSize { get; set; } // в дюймах
    public string? ScreenResolution { get; set; }
    public int? BatteryLife { get; set; } // в часах
    public float? Weight { get; set; } // в кг
    
    // Специализированные функции
    public bool VRReady { get; set; }
    public bool AIAcceleration { get; set; }
    
    // Сроки поставки (актуально для российского рынка)
    public int DeliveryTimeDays { get; set; } // 0 - в наличии
    public bool IsRussianProduction { get; set; }
    
    // Методы для проверки характеристик
    public bool IsGoodForGaming()
    {
        return (GPU.Contains("RTX") || GPU.Contains("RX")) && 
               RAM >= 16 && 
               (Processor.Contains("i5") || Processor.Contains("i7") || 
                Processor.Contains("Ryzen 5") || Processor.Contains("Ryzen 7"));
    }
    
    public bool IsGoodForDesign()
    {
        return RAM >= 32 && 
               (GPU.Contains("RTX") || GPU.Contains("Quadro") || GPU.Contains("Radeon Pro")) &&
               (Processor.Contains("i7") || Processor.Contains("i9") || 
                Processor.Contains("Ryzen 7") || Processor.Contains("Ryzen 9") ||
                Processor.Contains("Xeon"));
    }
    
    public bool IsEnergyEfficient()
    {
        return EnergyEfficiencyClass == "A++" || EnergyEfficiencyClass == "A+";
    }
    
    public string GetFullSpecs()
    {
        var specs = new System.Text.StringBuilder();
        specs.AppendLine($"Процессор: {Processor}");
        specs.AppendLine($"Видеокарта: {GPU}");
        specs.AppendLine($"Оперативная память: {RAM} ГБ");
        specs.AppendLine($"Накопитель: {Storage}");
        specs.AppendLine($"ОС: {OS}");
        specs.AppendLine($"Форм-фактор: {GetFormFactorName()}");
        
        if (IsLaptop)
        {
            specs.AppendLine($"Экран: {ScreenSize}\" {ScreenResolution}");
            specs.AppendLine($"Аккумулятор: до {BatteryLife} часов");
            specs.AppendLine($"Вес: {Weight} кг");
        }
        
        specs.AppendLine($"Энергопотребление: {PowerConsumption} Вт ({EnergyEfficiencyClass})");
        specs.AppendLine($"Гарантия: {WarrantyMonths / 12} лет");
        
        if (SupportsRussianOS)
            specs.AppendLine("✔ Поддержка российских ОС");
            
        if (IsRussianProduction)
            specs.AppendLine("✔ Российское производство");
            
        return specs.ToString();
    }
    
    private string GetFormFactorName()
    {
        return FormFactor switch
        {
            "Desktop" => "Настольный ПК",
            "Laptop" => "Ноутбук",
            "MiniPC" => "Мини-ПК",
            "AllInOne" => "Моноблок",
            _ => FormFactor
        };
    }
}