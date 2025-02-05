using ChoosingGadgets.Models;

namespace ChoosingGadgets.Views;

public partial class ChooseSmartphonePage : ContentPage
{
    private int purposePhone = 1, mainAccount = 1, priceCategory = 1, autonomy = 1;
    public ChooseSmartphonePage()
    {
        InitializeComponent();
    }

    private async void GetResultBtnClicked(object sender, EventArgs e)
    {
        Smartphones smartphones = new() { androidDevice = 0, iPhone = 0, googlePixel = 0, huawei = 0, samsungGalaxyA = 0, samsungGalaxyS = 0 };

        if (purposePhone == 1) { smartphones.androidDevice += 1; smartphones.huawei += 1; smartphones.samsungGalaxyA += 1; }
        else if (purposePhone == 2) { smartphones.samsungGalaxyA += 1; smartphones.iPhone += 2; }
        else if (purposePhone == 3) { smartphones.huawei += 1; smartphones.googlePixel += 1; }
        else if (purposePhone == 4) { smartphones.samsungGalaxyS += 2; smartphones.googlePixel += 1; smartphones.iPhone += 1; }

        if (mainAccount == 1) { smartphones.androidDevice += 1; smartphones.googlePixel += 2; smartphones.samsungGalaxyS += 1; 
            smartphones.samsungGalaxyA += 1; }
        else if (mainAccount == 2) { smartphones.iPhone += 2; }
        else if (mainAccount == 3) { smartphones.huawei += 1; smartphones.samsungGalaxyA += 1; smartphones.samsungGalaxyS += 1; }

        if (priceCategory == 1) { smartphones.androidDevice += 2; smartphones.huawei += 1; smartphones.samsungGalaxyA += 1; }
        else if (priceCategory == 2) { smartphones.iPhone += 1; smartphones.samsungGalaxyS += 1; smartphones.googlePixel += 1; }
        else if (priceCategory == 3) { smartphones.iPhone += 2; smartphones.samsungGalaxyS += 2; }

        if (autonomy == 1) { smartphones.iPhone += 1; smartphones.samsungGalaxyS += 1; }
        else if (autonomy == 2) { smartphones.androidDevice += 1; smartphones.huawei += 1;}


        string result = smartphones.GetBestSmartphone();
        string descriptionResult = $"Самое оптимальное, что мы смогли подобрать, это {result}";
        await DisplayAlert($"Лучший вариант для Вас: {result}",  descriptionResult, "Спасибо!");
    }

    private void PurposePhoneCheckedChanged(object sender, CheckedChangedEventArgs e) => purposePhone = Convert.ToInt32(e.Value);
    private void MainAccountCheckedChanged(object sender, CheckedChangedEventArgs e) => mainAccount = Convert.ToInt32(e.Value);
    private void PriceCategoryCheckedChanged(object sender, CheckedChangedEventArgs e) => priceCategory = Convert.ToInt32(e.Value);
    private void AutonomyCheckedChanged(object sender, CheckedChangedEventArgs e) => autonomy = Convert.ToInt32(e.Value);
}
    