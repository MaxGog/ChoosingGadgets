using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace ChoosingGadgets.SettingsApp
{
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
        }

        private void NavPanEdit_Toggled(object sender, RoutedEventArgs e)
        {
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse();
            if (NavPanEdit.IsOn == true)
            {
                //Settings
            }
        }

        //private void ThemeWindow(object sender, RoutedEventArgs e)
        //{
        //    RadioButton radioButton = sender as RadioButton;
        //    if (radioButton.Content.ToString() == "Light")
        //    {
        //        SwitchTheme(bd, ElementTheme.Light);
        //        //App.Current.RequestedTheme = ApplicationTheme.Dark;
        //        //Application.RequestedTheme = ElementTheme.Dark;
        //    }
        //    else
        //    {
        //        SwitchTheme(bd, ElementTheme.Default);
        //        //App.Current.RequestedTheme = ApplicationTheme.Light;
        //        //Application.RequestedTheme = ElementTheme.Light;
        //    }
        //}
        //private void SwitchTheme(FrameworkElement root, ElementTheme theme)
        //{
        //    if (root == null)
        //        return;
        //    foreach (var item in FindLogicChildren<TextBlock>(root))
        //        item.RequestedTheme = theme;
        //    foreach (var item in FindLogicChildren<RadioButton>(root))
        //        item.RequestedTheme = theme;
        //}
        //public IEnumerable<FrameworkElement> FindLogicChildren<T>(FrameworkElement root) where T : FrameworkElement
        //{
        //    var children = LogicalTree.FindChildren<T>(root);
        //    foreach(var child in children)
        //    {
        //        if (LogicalTree.FindChild<T>(child) != null)
        //        {
        //            FindLogicChildren<T>(child);
        //        }
        //        else
        //            yield return (T)child;
        //    }
        //}
    }
}
