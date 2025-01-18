namespace ChoosingGadgets.Models;

public class ChooseLaptopModel
{
    private int macbookairScore = 0, macbookproScore = 0, surfaceproScore = 0, chromebookScore = 0, pcScore = 0,
        laptopofficeScore = 0, lenovothinkpadScore = 0, laptopgamingScore = 0;

    public void AddMacBookAirScore(int score) => macbookairScore += score;
    public void AddMacBookProScore(int score) => macbookproScore += score;
    public void AddChromebookScore(int score) => chromebookScore += score;
    public void AddPCScore(int score) => pcScore += score;
    public void AddSurfaceProScore(int score) => surfaceproScore += score;
    public void AddLaptopOfficeScore(int score) => laptopofficeScore += score;
    public void AddLenovoThinkPadScore(int score) => lenovothinkpadScore += score;
    public void AddLaptopGamingScore(int score) => laptopgamingScore += score;
    public string GetBestLaptop()
    {
        string nameLaptop = "любой компьютер или ноутбук";
        int[] values = { macbookairScore, macbookproScore, surfaceproScore, chromebookScore, laptopgamingScore, laptopofficeScore, pcScore, lenovothinkpadScore};
        int maxScore = values.Max();

        if (laptopofficeScore == maxScore) { nameLaptop = "линейка офисных ноутбуков (HP или Acer)"; }
        else if (pcScore == maxScore) { nameLaptop = "сборочные стационарные компьютеры"; }
        else if (macbookairScore == maxScore) { nameLaptop = "линейка MacBook Air"; }
        else if (macbookproScore == maxScore) { nameLaptop = "линейка MacBook Pro"; }
        else if (surfaceproScore == maxScore) { nameLaptop = "линейка планшетов Surface Pro"; }
        else if (chromebookScore == maxScore) { nameLaptop = "линейка ноутбуков Chromebook"; }
        else if (laptopgamingScore == maxScore) { nameLaptop = "линейка игровых ноутбуков"; }
        else if (laptopofficeScore == maxScore) { nameLaptop = "линейка офисных ноутбуков (HP или Acer)"; }
        else if (lenovothinkpadScore == maxScore) { nameLaptop = "линейка ноутбуков Lenovo ThinkPad"; }

        return nameLaptop;
    }
}