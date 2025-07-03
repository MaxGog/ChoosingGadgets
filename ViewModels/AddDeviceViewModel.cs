using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ChoosingGadgets.Models;
using ChoosingGadgets.Repositories;

using DeviceType = ChoosingGadgets.Models.DeviceType;
using Device = ChoosingGadgets.Models.Device;

namespace ChoosingGadgets.ViewModels;

public class AddDeviceViewModel : INotifyPropertyChanged
{
    private readonly DeviceRepository _repository;

    public event PropertyChangedEventHandler PropertyChanged;

    public List<DeviceTypeItem> DeviceTypes { get; } = new()
    {
        new DeviceTypeItem(DeviceType.Computer, "Компьютер"),
        new DeviceTypeItem(DeviceType.Smartphone, "Смартфон")
    };

    private DeviceTypeItem _selectedDeviceType;
    public DeviceTypeItem SelectedDeviceType
    {
        get => _selectedDeviceType;
        set
        {
            _selectedDeviceType = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsComputer));
            OnPropertyChanged(nameof(IsSmartphone));
        }
    }

    public bool IsComputer => SelectedDeviceType?.Type == DeviceType.Computer;
    public bool IsSmartphone => SelectedDeviceType?.Type == DeviceType.Smartphone;

    // Общие свойства для всех устройств
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public DateTime ReleaseDate { get; set; } = DateTime.Today;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public string SourceUrl { get; set; }

    // Свойства для компьютера
    public string Processor { get; set; }
    public string GPU { get; set; }
    public int RAM { get; set; } = 8;
    public string Storage { get; set; } = "512GB SSD";
    public string OS { get; set; } = "Windows 11";
    public string FormFactor { get; set; } = "Desktop";
    public bool SupportsRussianOS { get; set; }
    public bool SupportsRussianCAD { get; set; }
    public string EnergyEfficiencyClass { get; set; } = "A";
    public int PowerConsumption { get; set; } = 500;
    public int ComputerWarrantyMonths { get; set; } = 12;
    public bool OnsiteService { get; set; }
    public bool UpgradeableRAM { get; set; } = true;
    public bool UpgradeableStorage { get; set; } = true;
    public bool UpgradeableGPU { get; set; }
    public bool HasCoolingSystem { get; set; } = true;
    public string Motherboard { get; set; }
    public string PSU { get; set; } = "500W";
    public string CaseType { get; set; } = "Mid-Tower";
    public float? LaptopScreenSize { get; set; }
    public string LaptopScreenResolution { get; set; }
    public int? LaptopBatteryLife { get; set; }
    public float? LaptopWeight { get; set; }
    public bool VRReady { get; set; }
    public bool AIAcceleration { get; set; }
    public int DeliveryTimeDays { get; set; } = 0;
    public bool IsRussianProduction { get; set; }

    // Свойства для смартфона
    public float ScreenSize { get; set; } = 6.5f;
    public string Resolution { get; set; } = "1080x2340";
    public string DisplayType { get; set; } = "AMOLED";
    public int RefreshRate { get; set; } = 60;
    public string CPU { get; set; }
    public string PhoneGPU { get; set; }
    public int PhoneRAM { get; set; } = 6;
    public int PhoneStorage { get; set; } = 128;
    public bool ExpandableStorage { get; set; }
    public string MainCamera { get; set; }
    public string FrontCamera { get; set; }
    public bool HasOpticalZoom { get; set; }
    public int BatteryCapacity { get; set; } = 4000;
    public bool FastCharging { get; set; }
    public bool WirelessCharging { get; set; }
    public bool WaterResistant { get; set; }
    public bool Has5G { get; set; }
    public bool HasNFC { get; set; }
    public bool HasHeadphoneJack { get; set; }
    public string PhoneOS { get; set; } = "Android";
    public string OSVersion { get; set; } = "13";
    public int PhoneWarrantyMonths { get; set; } = 12;

    public ICommand AddDeviceCommand { get; }

    public AddDeviceViewModel(DeviceRepository repository)
    {
        _repository = repository;
        SelectedDeviceType = DeviceTypes.First();

        AddDeviceCommand = new Command(async () => await AddDeviceAsync());
    }

    private async Task AddDeviceAsync()
    {
        try
        {
            Device device;

            if (SelectedDeviceType.Type == DeviceType.Computer)
            {
                device = new Computer
                {
                    Name = Name,
                    Manufacturer = Manufacturer,
                    Model = Model,
                    ReleaseDate = ReleaseDate,
                    Price = Price,
                    ImageUrl = ImageUrl,
                    SourceUrl = SourceUrl,
                    Type = DeviceType.Computer,
                    
                    // Основные характеристики
                    Processor = Processor,
                    GPU = GPU,
                    RAM = RAM,
                    Storage = Storage,
                    OS = OS,
                    
                    // Форм-фактор
                    FormFactor = FormFactor,
                    
                    // Совместимость с российским ПО
                    SupportsRussianOS = SupportsRussianOS,
                    SupportsRussianCAD = SupportsRussianCAD,
                    
                    // Энергоэффективность
                    EnergyEfficiencyClass = EnergyEfficiencyClass,
                    PowerConsumption = PowerConsumption,
                    
                    // Гарантия и обслуживание
                    WarrantyMonths = ComputerWarrantyMonths,
                    OnsiteService = OnsiteService,
                    
                    // Возможность апгрейда
                    UpgradeableRAM = UpgradeableRAM,
                    UpgradeableStorage = UpgradeableStorage,
                    UpgradeableGPU = UpgradeableGPU,
                    
                    // Дополнительные характеристики
                    HasCoolingSystem = HasCoolingSystem,
                    Motherboard = Motherboard,
                    PSU = PSU,
                    CaseType = CaseType,
                    
                    // Для ноутбуков
                    ScreenSize = IsLaptopFormFactor() ? LaptopScreenSize : null,
                    ScreenResolution = IsLaptopFormFactor() ? LaptopScreenResolution : null,
                    BatteryLife = IsLaptopFormFactor() ? LaptopBatteryLife : null,
                    Weight = IsLaptopFormFactor() ? LaptopWeight : null,
                    
                    // Специализированные функции
                    VRReady = VRReady,
                    AIAcceleration = AIAcceleration,
                    
                    // Сроки поставки
                    DeliveryTimeDays = DeliveryTimeDays,
                    IsRussianProduction = IsRussianProduction
                };
            }
            else
            {
                device = new Smartphone
                {
                    Name = Name,
                    Manufacturer = Manufacturer,
                    Model = Model,
                    ReleaseDate = ReleaseDate,
                    Price = Price,
                    ImageUrl = ImageUrl,
                    SourceUrl = SourceUrl,
                    Type = DeviceType.Smartphone,
                    
                    // Характеристики экрана
                    ScreenSize = ScreenSize,
                    Resolution = Resolution,
                    DisplayType = DisplayType,
                    RefreshRate = RefreshRate,
                    
                    // Производительность
                    CPU = CPU,
                    GPU = PhoneGPU,
                    RAM = PhoneRAM,
                    Storage = PhoneStorage,
                    ExpandableStorage = ExpandableStorage,
                    
                    // Камеры
                    MainCamera = MainCamera,
                    FrontCamera = FrontCamera,
                    HasOpticalZoom = HasOpticalZoom,
                    
                    // Батарея
                    BatteryCapacity = BatteryCapacity,
                    FastCharging = FastCharging,
                    WirelessCharging = WirelessCharging,
                    
                    // Особенности
                    WaterResistant = WaterResistant,
                    Has5G = Has5G,
                    HasNFC = HasNFC,
                    HasHeadphoneJack = HasHeadphoneJack,
                    
                    // ПО
                    OS = PhoneOS,
                    OSVersion = OSVersion,
                    
                    // Гарантия
                    WarrantyMonths = PhoneWarrantyMonths
                };
            }

            await _repository.AddDeviceAsync(device);
            await Shell.Current.DisplayAlert("Успех", "Устройство успешно добавлено", "OK");
            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Ошибка", $"Не удалось добавить устройство: {ex.Message}", "OK");
        }
    }

    private bool IsLaptopFormFactor()
    {
        return FormFactor == "Laptop" || FormFactor == "Notebook";
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class DeviceTypeItem
{
    public DeviceType Type { get; }
    public string Name { get; }

    public DeviceTypeItem(DeviceType type, string name)
    {
        Type = type;
        Name = name;
    }
}