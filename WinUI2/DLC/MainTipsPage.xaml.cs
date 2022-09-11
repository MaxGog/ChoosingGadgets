using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace PC_support.DLC
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainTipsPage : Page
    {
        public MainTipsPage()
        {
            this.InitializeComponent();
            contentFrame.Navigate(typeof(DictionaryPage));
        }
        private void NavPanTips_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem == Dictionary)
            {
                contentFrame.Navigate(typeof(DictionaryPage));
            }
        }
    }
}
