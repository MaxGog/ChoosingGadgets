using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using ChoosingGadgets.Models;

namespace ChoosingGadgets.Views;

public partial class ChooseConsolePage : ContentPage
{
    private int purposeGaming = 1, graphicsGames = 1, shootersGames = 1, placeGaming = 1;
    private bool hasSteamLibrary = false, hasXboxLibrary = false, hasPSLibrary = false, hasNintendoLibrary = false;
    public ChooseConsolePage()
    {
        InitializeComponent();
    }

    private async void GetResultBtnClicked(object sender, EventArgs e)
    {
        Consoles consoles = new() {xboxOne = 0, xboxSeriesS = 0, xboxSeriesX = 0, psFive = 0, psFour = 0, nintendoSwitch = 0, steamDeck = 0};

        if (purposeGaming == 1) { consoles.nintendoSwitch += 1; consoles.steamDeck += 1; consoles.xboxSeriesS += 1; }
        else if (purposeGaming == 2) { consoles.xboxSeriesX += 2; consoles.psFive += 2; 
            consoles.nintendoSwitch += 1; consoles.steamDeck += 1; }
        else if (purposeGaming == 3) { consoles.steamDeck += 1; consoles.xboxSeriesS += 1; }
        else if (purposeGaming == 4) { consoles.xboxOne += 1; consoles.psFour += 1; consoles.xboxSeriesS += 1; }

        if (graphicsGames == 1) { consoles.xboxSeriesX += 1; consoles.psFive += 1; consoles.steamDeck += 1; }
        else if (graphicsGames == 2) { consoles.xboxSeriesS += 1; consoles.xboxOne += 1; 
            consoles.psFour += 1; consoles.nintendoSwitch += 1; }

        if (shootersGames == 1) { consoles.xboxSeriesX += 1; consoles.psFive += 1; consoles.steamDeck += 1; 
            consoles.xboxSeriesS += 1; }
        else if (shootersGames == 2) { consoles.xboxOne += 1;  consoles.psFour += 1; consoles.nintendoSwitch += 1; }
        
        if (placeGaming == 2) { consoles.xboxSeriesX += 1; consoles.psFive += 1; }
        else if (placeGaming == 1) { consoles.xboxSeriesS += 1; consoles.nintendoSwitch += 1; consoles.steamDeck += 1; }

        if (hasSteamLibrary) { consoles.steamDeck += 2; }
        if (hasXboxLibrary) { consoles.xboxSeriesS += 2; consoles.xboxSeriesX += 2; consoles.xboxOne += 1; }
        if (hasPSLibrary) { consoles.psFive += 2; consoles.psFour += 2; }
        if (hasNintendoLibrary) { consoles.nintendoSwitch += 2; }

        string result = consoles.GetBestConsole();
        string descriptionResult = $"Самое оптимальное, что мы смогли подобрать, это {result}";
        await DisplayAlert($"Лучший вариант для Вас: {result}",  descriptionResult, "Спасибо!");
    }

    private void PurposeGamingCheckedChanged(object sender, CheckedChangedEventArgs e) => purposeGaming = Convert.ToInt32(e.Value);
    private void GraphicsGamesCheckedChanged(object sender, CheckedChangedEventArgs e) => graphicsGames = Convert.ToInt32(e.Value);
    private void ShootersGamesCheckedChanged(object sender, CheckedChangedEventArgs e) => shootersGames = Convert.ToInt32(e.Value);
    private void PlaceGamingCheckedChanged(object sender, CheckedChangedEventArgs e) => placeGaming = Convert.ToInt32(e.Value);
    private void SteamCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e) => hasSteamLibrary = e.Value;
    private void XboxCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e) => hasXboxLibrary = e.Value;
    private void PsCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e) => hasPSLibrary = e.Value;
    private void NintendoCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e) => hasNintendoLibrary = e.Value;
}