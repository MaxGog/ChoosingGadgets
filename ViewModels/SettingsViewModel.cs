using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Windows.ApplicationModel;
using Windows.UI.Xaml;

using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

using PC_support.Services;

namespace PC_support.ViewModels
{
    public class SettingsViewModel : ObservableObject
    {
        public SettingsViewModel()
        {
        }

        private ElementTheme _elementTheme = ThemeSelectorService.Theme;
        public ElementTheme ElementTheme
        {
            get => _elementTheme;

            set => SetProperty(ref _elementTheme, value);
        }
        private ICommand _switchThemeCommand;
        public ICommand SwitchThemeCommand
        {
            get
            {
                if (_switchThemeCommand == null)
                {
                    _switchThemeCommand = new RelayCommand<ElementTheme>(
                        async (param) =>
                        {
                            ElementTheme = param;
                            await ThemeSelectorService.SetThemeAsync(param);
                        });
                }

                return _switchThemeCommand;
            }
        }
        private string GetVersionDescription()
        {
            var appName = "Choosing Gadgets";
            var package = Package.Current;
            var packageId = package.Id;
            var version = packageId.Version;

            return $"{appName} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
        }

        private string _versionDescription;
        public string VersionDescription
        {
            get => _versionDescription;

            set => SetProperty(ref _versionDescription, value);
        }
        public Task InitializeAsync()
        {
            VersionDescription = GetVersionDescription();
            return Task.CompletedTask;
        }
    }
}
