using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Storage;
using Windows.UI.Xaml;

namespace PC_support
{
    internal class AppSettings
    {
        public const ElementTheme DEFAULTTHEME = ElementTheme.Light;
        public const ElementTheme NONDEFLTHEME = ElementTheme.Dark;

        const string KEY_THEME = "appColourMode";
        public static ApplicationDataContainer LOCALSETTINGS = ApplicationData.Current.LocalSettings;

        public static ElementTheme Theme
        {
            get
            {
                if (LOCALSETTINGS.Values[KEY_THEME] == null)
                {
                    LOCALSETTINGS.Values[KEY_THEME] = (int)DEFAULTTHEME;
                    return DEFAULTTHEME;
                }
                else if ((int)LOCALSETTINGS.Values[KEY_THEME] == (int)DEFAULTTHEME)
                    return DEFAULTTHEME;
                else
                    return NONDEFLTHEME;
            }
            set
            {
                if (value == ElementTheme.Default)
                    throw new Exception("Only set the theme to light or dark mode!");
                else if (LOCALSETTINGS.Values[KEY_THEME] == null)
                    LOCALSETTINGS.Values[KEY_THEME] = (int)value;
                else if ((int)value == (int)LOCALSETTINGS.Values[KEY_THEME])
                    return;
                else
                    LOCALSETTINGS.Values[KEY_THEME] = (int)value;
            }
        }
    }
}
