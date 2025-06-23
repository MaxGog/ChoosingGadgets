using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ChoosingGadgets.ViewModels;

public class SettingsViewModel : INotifyPropertyChanged
{
    private bool _isLightTheme;
    private bool _isDarkTheme;
    private bool _isSystemTheme = true;

    public bool IsLightTheme
    {
        get => _isLightTheme;
        set
        {
            if (SetProperty(ref _isLightTheme, value) && value)
            {
                IsDarkTheme = false;
                IsSystemTheme = false;
                App.SetTheme(themeName: "LightTheme");
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
                App.SetTheme(themeName: "DarkTheme");
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
                App.SetTheme(isSystemTheme: true);
            }
        }
    }

    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return false;

        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}