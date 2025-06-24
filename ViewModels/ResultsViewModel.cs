using ChoosingGadgets.Models;
using ChoosingGadgets.Repositories;
using System.Collections.ObjectModel;

using DeviceType = ChoosingGadgets.Models.DeviceType;

namespace ChoosingGadgets.ViewModels;

public class ResultsViewModel
{
    public ObservableCollection<Computer> RecommendedDevices { get; } = new();
    private readonly UserPreferences _preferences;
    private readonly DeviceRepository _deviceRepository;

    public ResultsViewModel(UserPreferences preferences, DeviceRepository deviceRepository)
    {
        _preferences = preferences;
        _deviceRepository = deviceRepository;
    }

    public async Task LoadRecommendations()
    {
        var dbDevices = (await _deviceRepository.GetDevicesByTypeAsync(DeviceType.Computer))
            .Cast<Computer>()
            .ToList();

        IEnumerable<Computer> matchedDevices;

        if (dbDevices.Any())
        {
            matchedDevices = dbDevices
                .Where(d => MatchPreferences(d, _preferences))
                .OrderBy(d => d.Price)
                .Take(5);
        }
        else
        {
            matchedDevices = GetMockDevices()
                .Where(d => MatchPreferences(d, _preferences))
                .OrderBy(d => d.Price)
                .Take(5);
        }

        if (!matchedDevices.Any())
        {
            matchedDevices = GetGenericRecommendations(_preferences);
        }

        foreach (var device in matchedDevices)
        {
            RecommendedDevices.Add(device);
        }
    }

    private List<Computer> GetGenericRecommendations(UserPreferences preferences)
    {
        return new List<Computer>
        {
            new Computer
            {
                Name = "Общие рекомендации",
                Type = DeviceType.Computer,
                Manufacturer = "ChoosingGadgets",
                Model = "Generic",
                Price = 0,
                Processor = GetRecommendedProcessor(preferences),
                GPU = GetRecommendedGpu(preferences),
                RAM = GetRecommendedRam(preferences),
                Storage = GetRecommendedStorage(preferences),
                OS = GetRecommendedOs(preferences),
                ImageUrl = "generic_pc.jpg"
            }
        };
    }

    private string GetRecommendedProcessor(UserPreferences preferences)
    {
        return preferences.PrimaryUse switch
        {
            "gaming" => "Intel Core i5/i7 или AMD Ryzen 5/7",
            "design" => "Intel Core i7/i9 или AMD Ryzen 7/9",
            _ => "Intel Core i3/i5 или AMD Ryzen 3/5"
        };
    }

    private string GetRecommendedGpu(UserPreferences preferences)
    {
        return preferences.PrimaryUse switch
        {
            "gaming" => "NVIDIA RTX 3060/4060 или AMD RX 6600/7600",
            "design" => "NVIDIA RTX A-series или Quadro",
            _ => "Интегрированная графика или NVIDIA GTX 1650"
        };
    }

    private int GetRecommendedRam(UserPreferences preferences)
    {
        return preferences.PrimaryUse switch
        {
            "gaming" => 16,
            "design" => 32,
            _ => 8
        };
    }

    private string GetRecommendedStorage(UserPreferences preferences)
    {
        return preferences.PrimaryUse switch
        {
            "gaming" => "1TB SSD + 2TB HDD",
            "design" => "2TB SSD",
            _ => "512GB SSD"
        };
    }

    private string GetRecommendedOs(UserPreferences preferences)
    {
        return preferences.PrimaryUse switch
        {
            "design" => "Windows 10/11 Pro",
            _ => "Windows 10/11 Home"
        };
    }

    private bool MatchPreferences(Computer device, UserPreferences preferences)
    {
        if (preferences.Budget == 1 && device.Price > 500) return false;
        if (preferences.Budget == 2 && (device.Price < 500 || device.Price > 1000)) return false;
        if (preferences.Budget == 3 && (device.Price < 1000 || device.Price > 1500)) return false;
        if (preferences.Budget == 4 && device.Price < 1500) return false;

        if (preferences.PrimaryUse == "gaming" && !IsGoodForGaming(device)) return false;
        if (preferences.PrimaryUse == "design" && !IsGoodForDesign(device)) return false;

        return true;
    }

    private bool IsGoodForGaming(Computer device)
    {
        return device.GPU.Contains("RTX") ||
               device.GPU.Contains("GTX") ||
               device.RAM >= 16;
    }

    private bool IsGoodForDesign(Computer device)
    {
        return device.RAM >= 32 ||
               device.Processor.Contains("i7") ||
               device.Processor.Contains("i9") ||
               device.Processor.Contains("Ryzen 7") ||
               device.Processor.Contains("Ryzen 9");
    }

    private List<Computer> GetMockDevices()
    {
        return new List<Computer>
        {
            new Computer
            {
                Name = "Игровой ПК начального уровня",
                Type = DeviceType.Computer,
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
                Type = DeviceType.Computer,
                Manufacturer = "Dell",
                Model = "Precision 3650",
                Price = 1800,
                Processor = "Intel Xeon W-1250",
                GPU = "NVIDIA Quadro P2200",
                RAM = 32,
                Storage = "1TB SSD + 2TB HDD",
                OS = "Windows 10 Pro",
                ImageUrl = "pc2.jpg"
            }
        };
    }
}