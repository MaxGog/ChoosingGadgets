namespace ChoosingGadgets;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		SetTheme();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new AppShell());
	}

	public static void SetTheme(bool isSystemTheme = false, string themeName = null)
    {
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
            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            mergedDictionaries.Clear();
            
            mergedDictionaries.Add(themeDict);
            
            foreach (var resource in themeDict)
            {
                Application.Current.Resources[resource.Key] = resource.Value;
            }
        }
    }
}