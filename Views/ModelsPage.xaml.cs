using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace PC_support.Views
{
    public sealed partial class ModelsPage : Page
    {
        private TextBlock namePC = new TextBlock();
        private Image image = new Image();
        private TextBlock model = new TextBlock();
        private TextBlock characters = new TextBlock();
        private ProgressRing status = new ProgressRing();
        private int tmp = 0;
        public ModelsPage()
        {
            this.InitializeComponent();
            InfoPC.Margin = new Thickness(10, 10, 10, 10);
            image.Margin = new Thickness(10, 10, 10, 10);
            status.IsActive = true;
            image.Width = 400;
            namePC.FontSize = 30;
            model.SelectionHighlightColor = new SolidColorBrush(Windows.UI.Colors.Gray);
            model.FontSize = 10;
            characters.TextWrapping = TextWrapping.WrapWholeWords;
            characters.Width = 400;
        }
        private void SelectPage_ItemClick(object sender, ItemClickEventArgs e)
        {
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
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
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualPictures/PC/MacBook_Air.png"));
                namePC.Text = "MacBook Air";
                model.Text = "MacBook Air 13'";
                characters.Text = resourceLoader.GetString("MacBook_air");
            }
            else if (selectedModels == Surface_Pro)
            {
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/VisualPictures/PC/Surface.png"));
                namePC.Text = "Surface Pro";
                model.Text = "Microsoft Surface Pro";
                characters.Text = resourceLoader.GetString("Surface_pro7");
            }
        }
    }
}
