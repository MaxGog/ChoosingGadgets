namespace ChoosingGadgets;

public partial class App : Application
{
	public App()
    {
        InitializeComponent();
        
        var useSystemTheme = Preferences.Get("UseSystemTheme", true);
        var appTheme = Preferences.Get("AppTheme", "LightTheme");
        
        SetTheme(useSystemTheme, useSystemTheme ? null : appTheme);
        
        MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = base.CreateWindow(activationState);
        
        window.Created += (s, e) => 
        {
            Application.Current.RequestedThemeChanged += OnRequestedThemeChanged;
        };
        
        window.Destroying += (s, e) => 
        {
            Application.Current.RequestedThemeChanged -= OnRequestedThemeChanged;
        };
        
        return window;
    }

    private void OnRequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
    {
        if (Preferences.Get("UseSystemTheme", true))
        {
            SetTheme(true);
        }
    }

    public static void SetTheme(bool isSystemTheme = false, string themeName = null)
    {
        Preferences.Set("UseSystemTheme", isSystemTheme);
        
        if (!isSystemTheme && !string.IsNullOrEmpty(themeName))
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
        if (Application.Current.Resources.TryGetValue(themeKey, out var themeDictObj) && 
            themeDictObj is ResourceDictionary themeDict)
        {
            var resourcesToUpdate = themeDict.Keys.ToList();
            
            foreach (var key in resourcesToUpdate)
            {
                if (themeDict.TryGetValue(key, out var value))
                {
                    Application.Current.Resources[key] = value;
                }
            }
            
            UpdateDynamicResources();
        }
    }

    [Obsolete]
    private static void UpdateDynamicResources()
    {
        var app = Application.Current;
        if (app?.MainPage != null)
        {
            var existingMainPage = app.MainPage;
            app.MainPage = new ContentPage();
            app.MainPage = existingMainPage;
        }
    }
}