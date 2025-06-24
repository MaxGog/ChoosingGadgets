using ChoosingGadgets.Models;
using System.Collections.ObjectModel;

namespace ChoosingGadgets.ViewModels;

public class ResultsViewModel
{
    public ObservableCollection<Computer> RecommendedDevices { get; } = new();
    private readonly UserPreferences _preferences;

    public ResultsViewModel(UserPreferences preferences)
    {
        _preferences = preferences;
    }

    public async Task LoadRecommendations()
    {
        // В реальном приложении здесь будет запрос к базе данных или API
        // Для примера используем моковые данные
        
        var mockDevices = GetMockDevices()
            .Where(d => MatchPreferences(d, _preferences))
            .OrderBy(d => d.Price)
            .Take(5);
        
        foreach (var device in mockDevices)
        {
            RecommendedDevices.Add(device);
        }
    }

    private bool MatchPreferences(Computer device, UserPreferences preferences)
    {
        // Простая логика соответствия - можно усложнить
        if (preferences.Budget == 1 && device.Price > 500) return false;
        if (preferences.Budget == 2 && (device.Price < 500 || device.Price > 1000)) return false;
        if (preferences.Budget == 3 && (device.Price < 1000 || device.Price > 1500)) return false;
        if (preferences.Budget == 4 && device.Price < 1500) return false;
        
        if (preferences.PrimaryUse == "gaming" && device.GPU.Contains("GTX 1650")) return false;
        if (preferences.PrimaryUse == "design" && device.RAM < 16) return false;
        
        return true;
    }

    private List<Computer> GetMockDevices()
    {
        return new List<Computer>
        {
            new Computer
            {
                Name = "Игровой ПК начального уровня",
                Type = Models.DeviceType.Computer,
                Manufacturer = "Custom Build",
                Model = "Gamer Basic",
                Price = 700,
                Processor = "Intel Core i5-11400F",
                GPU = "NVIDIA GTX 1660 Super",
                RAM = 16,
                Storage = "512GB SSD",
                OS = "Windows 11",
                ImageUrl = "pc1.jpg"
            },
            new Computer
            {
                Name = "Профессиональная рабочая станция",
                Type = Models.DeviceType.Computer,
                Manufacturer = "Dell",
                Model = "Precision 3650",
                Price = 1800,
                Processor = "Intel Xeon W-1250",
                GPU = "NVIDIA Quadro P2200",
                RAM = 32,
                Storage = "1TB SSD + 2TB HDD",
                OS = "Windows 10 Pro",
                ImageUrl = "pc2.jpg"
            },
            // Добавьте больше устройств по аналогии
        };
    }
}