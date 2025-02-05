using System.Linq;

namespace ChoosingGadgets.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
	}

    /*private void SwitchThemeBtnClicked(object sender, EventArgs e)
    {
        var mergedDictionaries = Application.Current.Resources.MergedDictionaries;

        
        
        if (mergedDictionaries[0] is ResourceDictionary lightTheme)
        {
            // Переключаемся на темную тему
            mergedDictionaries.Clear();
            mergedDictionaries.Add(new DarkTheme());
        }
        else
        {
            // Переключаемся на светлую тему
            mergedDictionaries.Clear();
            mergedDictionaries.Add(new LightTheme());
        }
    }*/
}

