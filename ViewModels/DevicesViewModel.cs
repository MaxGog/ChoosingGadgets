using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using ChoosingGadgets.Repositories;
using ChoosingGadgets.Services;

using Device = ChoosingGadgets.Models.Device;
using DeviceType = ChoosingGadgets.Models.DeviceType;

namespace ChoosingGadgets.ViewModels;

public partial class DevicesViewModel : BaseViewModel
{
    private readonly DeviceRepository _repository;
    private readonly ParserService _parserService;
    
    public ObservableCollection<Device> Devices { get; } = new();
    public ICommand LoadDevicesCommand { get; }
    public ICommand AddDeviceCommand { get; }
    public ICommand ParseFromWebCommand { get; }
    public ICommand SearchDevicesCommand { get; }
    public ICommand DeviceSelectedCommand { get; }
    public ICommand AddManualCommand { get; }
    public ICommand SwitchDeviceTypeCommand { get; }
    
    private string _searchTerm;
    public string SearchTerm
    {
        get => _searchTerm;
        set
        {
            _searchTerm = value;
            OnPropertyChanged();
        }
    }

    private DeviceType _deviceType = DeviceType.Computer;
    public DeviceType DeviceType
    {
        get => _deviceType;
        set
        {
            _deviceType = value;
            OnPropertyChanged();
        }
    }
    
    public int DevicesCount => Devices.Count;

    public bool IsBusy { get; private set; }

    public DevicesViewModel(DeviceRepository repository, ParserService parserService)
    {
        _repository = repository;
        _parserService = parserService;

        LoadDevicesCommand = new Command(async () => await LoadDevicesAsync());
        AddDeviceCommand = new Command<Device>(async (device) => await AddDeviceAsync(device));
        ParseFromWebCommand = new Command<string>(async (url) => await ParseFromWebAsync(url));
        SearchDevicesCommand = new Command(async () => await SearchDevicesAsync());
        DeviceSelectedCommand = new Command<Device>(async (device) => await DeviceSelectedAsync(device));
        AddManualCommand = new Command(async () => await AddManualDeviceAsync());

        SwitchDeviceTypeCommand = new Command<DeviceType>((type) => 
        {
            DeviceType = type;
            LoadDevicesCommand.Execute(null);
            
            OnPropertyChanged(nameof(DeviceType));
        });
    }

    private async Task LoadDevicesAsync()
    {
        if (IsBusy) return;
        
        try
        {
            IsBusy = true;
            Devices.Clear();
            
            var devices = string.IsNullOrEmpty(SearchTerm) 
                ? await _repository.GetAllDevicesAsync() 
                : await _repository.SearchDevicesAsync(SearchTerm);
            
            foreach (var device in devices)
                Devices.Add(device);
            
            OnPropertyChanged(nameof(DevicesCount));
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Ошибка загрузки: {ex.Message}");
            await Shell.Current.DisplayAlert("Ошибка", "Не удалось загрузить устройства", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    private async Task AddDeviceAsync(Device device)
    {
        try
        {
            await _repository.AddDeviceAsync(device);
            Devices.Add(device);
            OnPropertyChanged(nameof(DevicesCount));
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Ошибка добавления: {ex.Message}");
            await Shell.Current.DisplayAlert("Ошибка", "Не удалось добавить устройство", "OK");
        }
    }

    private async Task ParseFromWebAsync(string url)
    {
        if (IsBusy) return;
        
        try
        {
            IsBusy = true;
            
            string actualUrl = url;
            if (url == "https://example.com/devices")
            {
                actualUrl = DeviceType switch
                {
                    DeviceType.Computer => "https://4pda.to/forum/",
                    DeviceType.Smartphone => "https://4pda.to/forum/",
                    _ => "https://4pda.to/forum/"
                };
            }

            var devices = await _parserService.ParseDevicesFromWeb(DeviceType, actualUrl);
            
            if (devices == null || !devices.Any())
            {
                await Shell.Current.DisplayAlert("Информация", "Не найдено устройств для добавления", "OK");
                return;
            }
            
            int addedCount = 0;
            foreach (var device in devices)
            {
                if (!await _repository.DeviceExistsAsync(device))
                {
                    if (actualUrl.Contains("4pda.to"))
                    {
                        //device.Description = $"Источник: 4PDA\n{device.Description}";
                        if (string.IsNullOrEmpty(device.Manufacturer))
                        {
                            device.Manufacturer = "4PDA Forum";
                        }
                    }
                    
                    await _repository.AddDeviceAsync(device);
                    Devices.Add(device);
                    addedCount++;
                }
            }
            
            OnPropertyChanged(nameof(DevicesCount));
            await Shell.Current.DisplayAlert("Успех", $"Добавлено {addedCount} новых устройств", "OK");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Ошибка парсинга: {ex.Message}");
            await Shell.Current.DisplayAlert("Ошибка", $"Не удалось загрузить устройства: {ex.Message}", "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }

    private async Task SearchDevicesAsync()
    {
        await LoadDevicesAsync();
    }

    private async Task DeviceSelectedAsync(Device device)
    {
        if (device == null) return;
        
        var parameters = new Dictionary<string, object>
        {
            { "Device", device }
        };
        
        await Shell.Current.GoToAsync("//DeviceDetailsPage", parameters);
    }

    private async Task AddManualDeviceAsync()
    {
        await Shell.Current.GoToAsync("//AddDevicePage");
    }
}