namespace ChoosingGadgets.Models;

public class Smartphone : Device
{
    // Экран
    public float ScreenSize { get; set; } // в дюймах
    public string Resolution { get; set; } // например "1080x2340"
    public string DisplayType { get; set; } // AMOLED, IPS LCD и т.д.
    public int RefreshRate { get; set; } // Гц
    
    // Производительность
    public string CPU { get; set; }
    public string GPU { get; set; }
    public int RAM { get; set; } // в ГБ
    public int Storage { get; set; } // в ГБ
    public bool ExpandableStorage { get; set; }
    
    // Камеры
    public string MainCamera { get; set; } // например "50MP + 12MP + 5MP"
    public string FrontCamera { get; set; }
    public bool HasOpticalZoom { get; set; }
    
    // Батарея
    public int BatteryCapacity { get; set; } // в mAh
    public bool FastCharging { get; set; }
    public bool WirelessCharging { get; set; }
    
    // Особенности
    public bool WaterResistant { get; set; }
    public bool Has5G { get; set; }
    public bool HasNFC { get; set; }
    public bool HasHeadphoneJack { get; set; }
    public string OS { get; set; }
    public string OSVersion { get; set; }
    
    // Гарантия
    public int WarrantyMonths { get; set; }
    
    // Методы для проверки характеристик
    public bool IsGoodForGaming()
    {
        return RAM >= 8 && 
               (CPU.Contains("Snapdragon 8") || CPU.Contains("Dimensity 9")) &&
               RefreshRate >= 90;
    }
    
    public bool IsGoodForPhotography()
    {
        return MainCamera.Split('+').Length >= 2 && 
               (MainCamera.Contains("MP") || MainCamera.Contains("мегапикселей"));
    }
    
    public bool IsLongBatteryLife()
    {
        return BatteryCapacity >= 5000;
    }
    
    public bool IsPremium()
    {
        return WaterResistant && Has5G && WirelessCharging;
    }
    
    public string GetFullSpecs()
    {
        var specs = new System.Text.StringBuilder();
        specs.AppendLine($"Экран: {ScreenSize}\", {Resolution}, {DisplayType}, {RefreshRate}Гц");
        specs.AppendLine($"Процессор: {CPU}");
        specs.AppendLine($"Графика: {GPU}");
        specs.AppendLine($"Память: {RAM} ГБ RAM, {Storage} ГБ хранилища");
        specs.AppendLine($"Камера: {MainCamera} (основная), {FrontCamera} (фронтальная)");
        specs.AppendLine($"Батарея: {BatteryCapacity} mAh");
        
        if (FastCharging) specs.AppendLine("✔ Быстрая зарядка");
        if (WirelessCharging) specs.AppendLine("✔ Беспроводная зарядка");
        if (WaterResistant) specs.AppendLine("✔ Водозащита");
        if (Has5G) specs.AppendLine("✔ Поддержка 5G");
        if (HasHeadphoneJack) specs.AppendLine("✔ Разъем 3.5mm");
        
        specs.AppendLine($"ОС: {OS} {OSVersion}");
        specs.AppendLine($"Гарантия: {WarrantyMonths / 12} лет");
        
        return specs.ToString();
    }
}