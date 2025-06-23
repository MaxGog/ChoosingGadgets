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

    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public DateTime ReleaseDate { get; set; } = DateTime.Today;
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public string SourceUrl { get; set; }

    public string Processor { get; set; }
    public string GPU { get; set; }
    public int RAM { get; set; }
    public string Storage { get; set; }
    public string OS { get; set; }

    public string ScreenSize { get; set; }
    public string Resolution { get; set; }
    public string CPU { get; set; }
    public int PhoneStorage { get; set; }
    public string Camera { get; set; }
    public string Battery { get; set; }

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
                    Processor = Processor,
                    GPU = GPU,
                    RAM = RAM,
                    Storage = Storage,
                    OS = OS,
                    Type = DeviceType.Computer
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
                    ScreenSize = ScreenSize,
                    Resolution = Resolution,
                    CPU = CPU,
                    RAM = RAM,
                    Storage = PhoneStorage,
                    Camera = Camera,
                    Battery = Battery,
                    Type = DeviceType.Smartphone
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