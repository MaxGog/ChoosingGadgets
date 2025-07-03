using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Text;
using ChoosingGadgets.Models;

namespace ChoosingGadgets.ViewModels;

public class SettingsViewModel : INotifyPropertyChanged
{
    private bool _isLightTheme;
    private bool _isDarkTheme;
    private bool _isSystemTheme = true;
    private string _accentColor = "#0078D7";

    private DeviceInfoModel _deviceInfo;
    public DeviceInfoModel DeviceInfo
    {
        get => _deviceInfo;
        set => SetProperty(ref _deviceInfo, value);
    }

    public ICommand ShowFullDeviceInfoCommand { get; }

    public SettingsViewModel()
    {
        var useSystemTheme = Preferences.Get("UseSystemTheme", true);
        var appTheme = Preferences.Get("AppTheme", "LightTheme");
        _accentColor = Preferences.Get("AccentColor", "#0078D7");

        if (useSystemTheme)
        {
            _isSystemTheme = true;
        }
        else
        {
            _isLightTheme = appTheme == "LightTheme";
            _isDarkTheme = appTheme == "DarkTheme";
        }

        DeviceInfo = new DeviceInfoModel
        {
            Manufacturer = Microsoft.Maui.Devices.DeviceInfo.Manufacturer,
            Model = Microsoft.Maui.Devices.DeviceInfo.Model,
            DeviceType = GetDeviceTypeString(Microsoft.Maui.Devices.DeviceInfo.DeviceType),
            Platform = Microsoft.Maui.Devices.DeviceInfo.Platform.ToString(),
            Version = Microsoft.Maui.Devices.DeviceInfo.VersionString
        };

        ShowFullDeviceInfoCommand = new Command(async () => await ShowFullDeviceInfo());
    }

    public bool IsLightTheme
    {
        get => _isLightTheme;
        set
        {
            if (SetProperty(ref _isLightTheme, value) && value)
            {
                IsDarkTheme = false;
                IsSystemTheme = false;
                Preferences.Set("AppTheme", "LightTheme");
                Preferences.Set("UseSystemTheme", false);
                App.SetTheme(false, "LightTheme");
            }
        }
    }

    public bool IsDarkTheme
    {
        get => _isDarkTheme;
        set
        {
            if (SetProperty(ref _isDarkTheme, value) && value)
            {
                IsLightTheme = false;
                IsSystemTheme = false;
                Preferences.Set("AppTheme", "DarkTheme");
                Preferences.Set("UseSystemTheme", false);
                App.SetTheme(false, "DarkTheme");
            }
        }
    }

    public bool IsSystemTheme
    {
        get => _isSystemTheme;
        set
        {
            if (SetProperty(ref _isSystemTheme, value) && value)
            {
                IsLightTheme = false;
                IsDarkTheme = false;
                Preferences.Set("UseSystemTheme", true);
                App.SetTheme(true);
            }
        }
    }

    public string AccentColor
    {
        get => _accentColor;
        set
        {
            if (SetProperty(ref _accentColor, value))
            {
                Preferences.Set("AccentColor", value);
                ApplyAccentColor(value);
            }
        }
    }

    private string GetDeviceTypeString(Microsoft.Maui.Devices.DeviceType deviceType)
    {
        return deviceType switch
        {
            Microsoft.Maui.Devices.DeviceType.Physical => "Физическое устройство",
            Microsoft.Maui.Devices.DeviceType.Virtual => "Эмулятор/виртуальное устройство",
            _ => "Неизвестно"
        };
    }

    private async Task ShowFullDeviceInfo()
    {
        var fullInfo = new StringBuilder();
        fullInfo.AppendLine($"Производитель: {DeviceInfo.Manufacturer}");
        fullInfo.AppendLine($"Модель: {DeviceInfo.Model}");
        fullInfo.AppendLine($"Тип устройства: {DeviceInfo.DeviceType}");
        fullInfo.AppendLine($"Платформа: {DeviceInfo.Platform}");
        fullInfo.AppendLine($"Версия ОС: {DeviceInfo.Version}");
        fullInfo.AppendLine($"ID устройства: {Microsoft.Maui.Devices.DeviceInfo.Idiom}");
        fullInfo.AppendLine($"Имя устройства: {Microsoft.Maui.Devices.DeviceInfo.Name}");

        await Shell.Current.DisplayAlert("Полная информация об устройстве", fullInfo.ToString(), "OK");
    }

    private void ApplyAccentColor(string color)
    {
        if (Color.TryParse(color, out var newColor))
        {
            Application.Current.Resources["SystemAccentColor"] = newColor;
        }
    }

    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return false;

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}