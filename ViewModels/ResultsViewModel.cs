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
    private readonly bool _useDatabase;

    public ResultsViewModel(UserPreferences preferences,
                          DeviceRepository deviceRepository,
                          bool useDatabase = true)
    {
        _preferences = preferences;
        _deviceRepository = deviceRepository;
        _useDatabase = useDatabase;
    }

    public async Task LoadRecommendations()
    {
        IEnumerable<Computer> matchedDevices;

        if (_useDatabase)
        {
            try
            {
                var dbDevices = (await _deviceRepository.GetDevicesByTypeAsync(DeviceType.Computer))
                    .Cast<Computer>()
                    .ToList();

                if (dbDevices.Any())
                {
                    matchedDevices = dbDevices
                        .Where(d => MatchPreferences(d, _preferences))
                        .OrderByDescending(d => MatchScore(d, _preferences))
                        .Take(5);
                }
                else
                {
                    matchedDevices = GetGenericRecommendations(_preferences);
                }
            }
            catch
            {
                matchedDevices = GetGenericRecommendations(_preferences);
            }
        }
        else
        {
            matchedDevices = GetGenericRecommendations(_preferences);
        }

        foreach (var device in matchedDevices)
        {
            RecommendedDevices.Add(device);
        }
    }

    private double MatchScore(Computer computer, UserPreferences preferences)
    {
        double score = 0;

        double price = (double)computer.Price;
        if (preferences.Budget == 1) score += 1 - Math.Min(price / 50000, 1); // До 50k
        else if (preferences.Budget == 2) score += 1 - Math.Abs(price - 75000) / 25000; // 50-100k
        else if (preferences.Budget == 3) score += 1 - Math.Abs(price - 125000) / 25000; // 100-150k
        else if (preferences.Budget == 4) score += 1 - Math.Abs(price - 175000) / 25000; // 150-200k
        else if (preferences.Budget == 5) score += Math.Min(price / 300000, 1); // >200k

        score += (computer.RAM / 64.0) * 0.3; // Нормализовано до 64GB
        score += (preferences.PerformancePriority / 5.0) * 0.2;

        if (preferences.PrimaryUse == "gaming" && IsGoodForGaming(computer)) score += 0.5;
        if (preferences.PrimaryUse == "design" && IsGoodForDesign(computer)) score += 0.5;
        if (preferences.PrimaryUse == "video" && IsGoodForVideoEditing(computer)) score += 0.5;

        if (preferences.FormFactor == 0 && computer.IsDesktop) score += 0.3;
        if (preferences.FormFactor == 1 && computer.IsLaptop) score += 0.3;

        if (preferences.NeedsRussianSoftware && computer.SupportsRussianOS) score += 0.2;

        return score;
    }

    private List<Computer> GetGenericRecommendations(UserPreferences preferences)
    {
        var recommendations = new List<Computer>
        {
            new Computer
            {
                Name = "Рекомендуемая конфигурация",
                Type = DeviceType.Computer,
                Manufacturer = "ChoosingGadgets",
                Model = "OptimalConfig",
                Price = GetRecommendedPrice(preferences),
                Processor = GetRecommendedProcessor(preferences),
                GPU = GetRecommendedGpu(preferences),
                RAM = GetRecommendedRam(preferences),
                Storage = GetRecommendedStorage(preferences),
                OS = GetRecommendedOs(preferences),
                FormFactor = GetRecommendedFormFactor(preferences),
                SupportsRussianOS = preferences.NeedsRussianSoftware,
                ImageUrl = "recommended_pc.jpg"
            }
        };

        if (preferences.PrimaryUse == "gaming")
        {
            recommendations.Add(GetAlternativeGamingConfig(preferences));
        }

        return recommendations;
    }

    private int GetRecommendedPrice(UserPreferences preferences)
    {
        return preferences.Budget switch
        {
            1 => 40000,
            2 => 75000,
            3 => 125000,
            4 => 175000,
            5 => 250000,
            _ => 100000
        };
    }

    private string GetRecommendedProcessor(UserPreferences preferences)
    {
        if (preferences.NeedsRussianSoftware)
            return "Эльбрус-8СВ / Байкал-M";

        return preferences.PrimaryUse switch
        {
            "gaming" => "Intel Core i5-13600K или AMD Ryzen 7 7700X",
            "design" or "video" => "Intel Core i7-13700K или AMD Ryzen 9 7900X",
            "programming" => "Intel Core i5-13400 или AMD Ryzen 5 7600",
            _ => "Intel Core i3-13100 или AMD Ryzen 3 7300X"
        };
    }

    private string GetRecommendedGpu(UserPreferences preferences)
    {
        return preferences.PrimaryUse switch
        {
            "gaming" => "NVIDIA RTX 4060 Ti или AMD RX 7700 XT",
            "design" or "video" => "NVIDIA RTX 4070 или AMD RX 7900 XT",
            _ => "Интегрированная графика или NVIDIA GTX 1650"
        };
    }

    private int GetRecommendedRam(UserPreferences preferences)
    {
        return preferences.PrimaryUse switch
        {
            "gaming" => 32,
            "design" or "video" => 64,
            "programming" => 32,
            _ => 16
        };
    }

    private string GetRecommendedStorage(UserPreferences preferences)
    {
        return preferences.PrimaryUse switch
        {
            "gaming" => "1TB NVMe SSD + 2TB HDD",
            "design" or "video" => "2TB NVMe SSD",
            _ => "512GB NVMe SSD"
        };
    }

    private string GetRecommendedOs(UserPreferences preferences)
    {
        if (preferences.NeedsRussianSoftware)
            return "Альт Линукс / РЕД ОС";

        return preferences.PrimaryUse switch
        {
            "design" or "video" => "Windows 11 Pro",
            _ => "Windows 11 Home"
        };
    }

    private string GetRecommendedFormFactor(UserPreferences preferences)
    {
        return preferences.FormFactor switch
        {
            0 => "Настольный ПК",
            1 => "Ноутбук",
            2 => "Мини-ПК",
            3 => "Моноблок",
            _ => "Настольный ПК"
        };
    }

    private Computer GetAlternativeGamingConfig(UserPreferences preferences)
    {
        return new Computer
        {
            Name = "Альтернативная игровая конфигурация",
            Type = DeviceType.Computer,
            Manufacturer = "ChoosingGadgets",
            Model = "GamingAlt",
            Price = (decimal)(GetRecommendedPrice(preferences) * 0.9),
            Processor = "Intel Core i5-13400F или AMD Ryzen 5 7600X",
            GPU = "NVIDIA RTX 3060 Ti или AMD RX 6700 XT",
            RAM = 16,
            Storage = "1TB SSD",
            OS = "Windows 11 Home",
            FormFactor = GetRecommendedFormFactor(preferences),
            ImageUrl = "gaming_pc.jpg"
        };
    }

    private bool MatchPreferences(Computer device, UserPreferences preferences)
    {
        if (preferences.Budget == 1 && device.Price > 50000) return false;
        if (preferences.Budget == 2 && (device.Price < 50000 || device.Price > 100000)) return false;
        if (preferences.Budget == 3 && (device.Price < 100000 || device.Price > 150000)) return false;
        if (preferences.Budget == 4 && (device.Price < 150000 || device.Price > 200000)) return false;
        if (preferences.Budget == 5 && device.Price < 200000) return false;

        if (preferences.PrimaryUse == "gaming" && !IsGoodForGaming(device)) return false;
        if (preferences.PrimaryUse == "design" && !IsGoodForDesign(device)) return false;
        if (preferences.PrimaryUse == "video" && !IsGoodForVideoEditing(device)) return false;

        if (preferences.FormFactor == 0 && !device.IsDesktop) return false;
        if (preferences.FormFactor == 1 && !device.IsLaptop) return false;

        if (preferences.NeedsRussianSoftware && !device.SupportsRussianOS) return false;

        return true;
    }

    private bool IsGoodForGaming(Computer device)
    {
        return device.GPU.Contains("RTX") ||
               device.GPU.Contains("RX") ||
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

    private bool IsGoodForVideoEditing(Computer device)
    {
        return device.RAM >= 32 &&
              (device.GPU.Contains("RTX") || device.GPU.Contains("RX")) &&
              device.Storage.Contains("NVMe");
    }
}