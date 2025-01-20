namespace ChoosingGadgets.Models;

public struct Smartphones
{
    public int iPhone, samsungGalaxyS, samsungGalaxyA, huawei, googlePixel, androidDevice;

    public string GetBestSmartphone()
    {
        string result = "Любой средний смартфон";

        int[] values = [iPhone, samsungGalaxyS, samsungGalaxyA, huawei, googlePixel, androidDevice];
        int maxValue = values.Max();

        if (iPhone >= maxValue) { result = "линейка iPhone"; }
        else if (samsungGalaxyS >= maxValue) { result = "линейка Galaxy S от Samsung"; }
        else if (samsungGalaxyA >= maxValue) { result = "линейка Galaxy A от Samsung"; }
        else if (huawei >= maxValue) { result = "линейка Huawei смартфонов"; }
        else if (googlePixel >= maxValue) { result = "линейка Google Pixel"; }
        else if (androidDevice >= maxValue) { result = "любой недорогой Android-смартфон"; }

        return result;
    }
}