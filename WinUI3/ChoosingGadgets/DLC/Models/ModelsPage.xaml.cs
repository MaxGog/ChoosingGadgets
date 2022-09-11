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
using Microsoft.UI.Xaml.Media.Imaging;


namespace ChoosingGadgets.DLC.Models
{
    public class ModelsList
    {
        public ImageSource ViewImage { get; set; }
        public string Name_str { get; set; }
        //public string Model_str { get; set; }
    }
    public sealed partial class ModelsPage : Page
    {
        TextBlock namePC = new TextBlock();
        Image image = new Image();
        TextBlock model = new TextBlock();
        TextBlock characters = new TextBlock();
        ProgressRing status = new ProgressRing();
        int tmp = 0;
        public ModelsPage()
        {
            this.InitializeComponent();

            InfoPC.Margin = new Thickness(10, 10, 10, 10);
            image.Margin = new Thickness(10, 10, 10, 10);
            status.IsActive = true;
            image.Width = 400;
            namePC.FontSize = 30;
            model.SelectionHighlightColor = new SolidColorBrush(Microsoft.UI.Colors.Gray);
            model.FontSize = 10;
            characters.TextWrapping = TextWrapping.WrapWholeWords;
            characters.Width = 400;
        }
        private void SelectPage_ItemClick(object sender, ItemClickEventArgs e)
        {
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse();
            if (tmp == 0)
            {
                InfoPC.Children.Add(image);
                InfoPC.Children.Add(namePC);
                InfoPC.Children.Add(model);
                InfoPC.Children.Add(characters);
                tmp++;
            }
            ModelsList selectedModels = (ModelsList)e.ClickedItem;
            if (selectedModels == MacBook_Air)
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/PicturesVisual/PC/MacBook_Air.png"));
                namePC.Text = "MacBook Air";
                model.Text = "MacBook Air 13'";
                characters.Text = resourceLoader.GetString("MacBook_air");
            }
            else if (selectedModels == Surface_Pro)
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/PicturesVisual/PC/Surface.png"));
                namePC.Text = "Surface Pro";
                model.Text = "Microsoft Surface Pro";
                characters.Text = resourceLoader.GetString("Surface_pro7");
            }
        }
    }
}
