using System.Globalization;
using ChoosingGadgets.Models;
using DeviceType = ChoosingGadgets.Models.DeviceType;

namespace ChoosingGadgets.Converters;

public class DeviceTypeToUrlConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is DeviceType deviceType)
        {
            return deviceType == DeviceType.Computer 
                ? "https://www.dns-shop.ru/catalog/17a892f816404e77/noutbuki/" 
                : "https://www.gsmarena.com/samsung-phones-9.php";
        }
        return "https://example.com/devices";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}