namespace ChoosingGadgets.Models;

public struct Consoles
{
    public int xboxOne, xboxSeriesX, xboxSeriesS;
    public int psFive, psFour;
    public int nintendoSwitch;
    public int steamDeck;

    public string GetBestConsole()
    {
        string result = "Любая консоль";

        int[] values = [xboxOne, xboxSeriesS, xboxSeriesX, psFive, psFour, nintendoSwitch, steamDeck];
        int maxValue = values.Max();

        if (xboxOne >= maxValue) { result = "Xbox One (S или X)"; }
        else if (xboxSeriesS >= maxValue) { result = "Xbox Series S"; }
        else if (xboxSeriesX >= maxValue) { result = "Xbox Series X"; }
        else if (psFive >= maxValue) { result = "Sony Playstation 5"; }
        else if (psFour >= maxValue) { result = "Sony Playstation 4"; }
        else if (nintendoSwitch >= maxValue) { result = "Nintendo Switch"; }
        else if (steamDeck >= maxValue) { result = "Steam Deck"; }

        return result;
    }
}