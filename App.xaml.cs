namespace ChoosingGadgets;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		var useSystemTheme = Preferences.Get("UseSystemTheme", true);
        var appTheme = Preferences.Get("AppTheme", "LightTheme");
        
        SetTheme(useSystemTheme, useSystemTheme ? null : appTheme);
	}

	protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = new Window(new AppShell());
        
        window.Created += (s, e) => {
            Application.Current.RequestedThemeChanged += (s, e) => {
                if (Preferences.Get("UseSystemTheme", true))
                {
                    SetTheme(true);
                }
            };
        };
        
        return window;
    }

	public static void SetTheme(bool isSystemTheme = false, string themeName = null)
    {
        Preferences.Set("UseSystemTheme", isSystemTheme);
        if (!isSystemTheme)
        {
            Preferences.Set("AppTheme", themeName);
        }

        if (isSystemTheme)
        {
            var currentTheme = Application.Current.RequestedTheme == AppTheme.Dark 
                ? "DarkTheme" 
                : "LightTheme";
            ApplyTheme(currentTheme);
        }
        else if (!string.IsNullOrEmpty(themeName))
        {
            ApplyTheme(themeName);
        }
    }

    private static void ApplyTheme(string themeKey)
    {
        if (Application.Current.Resources.TryGetValue(themeKey, out var newTheme) && 
            newTheme is ResourceDictionary themeDict)
        {
            foreach (var resource in themeDict)
            {
                if (resource.Key is string key)
                {
                    Application.Current.Resources[key] = resource.Value;
                }
            }
        }
    }
}