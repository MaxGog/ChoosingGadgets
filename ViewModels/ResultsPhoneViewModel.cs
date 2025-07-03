using ChoosingGadgets.Models;
using ChoosingGadgets.Repositories;
using System.Collections.ObjectModel;

using DeviceType = ChoosingGadgets.Models.DeviceType;

namespace ChoosingGadgets.ViewModels;

public class ResultsPhoneViewModel
{
    public ObservableCollection<Smartphone> RecommendedDevices { get; } = new();
    private readonly UserPhonePreferences _preferences;
    private readonly DeviceRepository _deviceRepository;
    private readonly bool _useDatabase;

    public ResultsPhoneViewModel(UserPhonePreferences preferences,
                              DeviceRepository deviceRepository,
                              bool useDatabase = true)
    {
        _preferences = preferences;
        _deviceRepository = deviceRepository;
        _useDatabase = useDatabase;
    }

    public async Task LoadRecommendations()
    {
        IEnumerable<Smartphone> matchedDevices;

        if (_useDatabase)
        {
            try
            {
                var dbDevices = (await _deviceRepository.GetDevicesByTypeAsync(DeviceType.Smartphone))
                    .Cast<Smartphone>()
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

    private double MatchScore(Smartphone phone, UserPhonePreferences preferences)
    {
        double score = 0;

        // Бюджет
        double price = (double)phone.Price;
        if (preferences.Budget == 1) score += 1 - Math.Min(price / 10000, 1); // До 10k
        else if (preferences.Budget == 2) score += 1 - Math.Abs(price - 15000) / 5000; // 10-20k
        else if (preferences.Budget == 3) score += 1 - Math.Abs(price - 30000) / 10000; // 20-40k
        else if (preferences.Budget == 4) score += 1 - Math.Abs(price - 50000) / 10000; // 40-60k
        else if (preferences.Budget == 5) score += Math.Min(price / 80000, 1); // >60k

        // Производительность
        score += (phone.RAM / 12.0) * 0.3; // Нормализовано до 12GB
        score += (preferences.PerformancePriority / 5.0) * 0.2;

        // Основное использование
        if (preferences.PrimaryUse == "gaming" && phone.IsGoodForGaming()) score += 0.5;
        if (preferences.PrimaryUse == "photo" && phone.IsGoodForPhotography()) score += 0.5;
        if (preferences.PrimaryUse == "premium" && phone.IsPremium()) score += 0.5;

        // Размер экрана
        if (preferences.ScreenSizePreference == 0 && phone.ScreenSize < 5.5) score += 0.3;
        if (preferences.ScreenSizePreference == 1 && phone.ScreenSize >= 5.5 && phone.ScreenSize <= 6.2) score += 0.3;
        if (preferences.ScreenSizePreference == 2 && phone.ScreenSize > 6.2 && phone.ScreenSize <= 6.7) score += 0.3;
        if (preferences.ScreenSizePreference == 3 && phone.ScreenSize > 6.7) score += 0.3;

        // Дополнительные функции
        var features = preferences.Features.Split(',');
        if (features.Contains("good_camera") && phone.IsGoodForPhotography()) score += 0.2;
        if (features.Contains("long_battery") && phone.IsLongBatteryLife()) score += 0.2;
        if (features.Contains("fast_charge") && phone.FastCharging) score += 0.1;
        if (features.Contains("water_resistant") && phone.WaterResistant) score += 0.1;
        if (features.Contains("headphone_jack") && phone.HasHeadphoneJack) score += 0.1;

        // 5G
        if (preferences.Needs5G && phone.Has5G) score += 0.2;

        return score;
    }

    private List<Smartphone> GetGenericRecommendations(UserPhonePreferences preferences)
    {
        var recommendations = new List<Smartphone>
        {
            new Smartphone
            {
                Name = "Рекомендуемая модель",
                Type = DeviceType.Smartphone,
                Manufacturer = GetRecommendedBrand(preferences),
                Model = "OptimalConfig",
                Price = GetRecommendedPrice(preferences),
                CPU = GetRecommendedCpu(preferences),
                GPU = GetRecommendedGpu(preferences),
                RAM = GetRecommendedRam(preferences),
                Storage = GetRecommendedStorage(preferences),
                ScreenSize = GetRecommendedScreenSize(preferences),
                BatteryCapacity = GetRecommendedBattery(preferences),
                OS = GetRecommendedOs(preferences),
                ImageUrl = "recommended_phone.jpg"
            }
        };

        if (preferences.PrimaryUse == "gaming")
        {
            recommendations.Add(GetAlternativeGamingConfig(preferences));
        }

        return recommendations;
    }

    private int GetRecommendedPrice(UserPhonePreferences preferences)
    {
        return preferences.Budget switch
        {
            1 => 8000,
            2 => 15000,
            3 => 30000,
            4 => 50000,
            5 => 70000,
            _ => 25000
        };
    }

    private string GetRecommendedCpu(UserPhonePreferences preferences)
    {
        return preferences.PrimaryUse switch
        {
            "gaming" => "Snapdragon 8 Gen 2 или Dimensity 9200",
            "photo" => "Snapdragon 7+ Gen 2 или Exynos 2200",
            "business" => "Snapdragon 778G или Apple A15",
            "premium" => "Apple A16 или Snapdragon 8 Gen 2",
            _ => "Snapdragon 695 или Helio G99"
        };
    }

    private string GetRecommendedGpu(UserPhonePreferences preferences)
    {
        return preferences.PrimaryUse switch
        {
            "gaming" => "Adreno 740 или Mali-G715",
            _ => "Интегрированная графика"
        };
    }

    private int GetRecommendedRam(UserPhonePreferences preferences)
    {
        return preferences.PrimaryUse switch
        {
            "gaming" => 12,
            "photo" => 8,
            "business" => 8,
            "premium" => 8,
            _ => 6
        };
    }

    private int GetRecommendedStorage(UserPhonePreferences preferences)
    {
        return preferences.PrimaryUse switch
        {
            "gaming" => 256,
            "photo" => 256,
            "business" => 128,
            "premium" => 256,
            _ => 128
        };
    }

    private float GetRecommendedScreenSize(UserPhonePreferences preferences)
    {
        return preferences.ScreenSizePreference switch
        {
            0 => 5.2f,
            1 => 6.1f,
            2 => 6.5f,
            3 => 6.8f,
            _ => 6.1f
        };
    }

    private int GetRecommendedBattery(UserPhonePreferences preferences)
    {
        return preferences.PrimaryUse switch
        {
            "gaming" => 5000,
            "photo" => 4500,
            "business" => 4000,
            "premium" => 4500,
            _ => 4000
        };
    }

    private string GetRecommendedOs(UserPhonePreferences preferences)
    {
        if (preferences.NeedsRussianSoftware)
            return "Astra Linux / РОСА";

        return preferences.BrandPreference switch
        {
            3 => "iOS",
            _ => "Android"
        };
    }

    private string GetRecommendedBrand(UserPhonePreferences preferences)
    {
        return preferences.BrandPreference switch
        {
            0 => "BQ",
            1 => "Xiaomi",
            2 => "Samsung",
            3 => "Apple",
            _ => "Стандартный бренд"
        };
    }

    private Smartphone GetAlternativeGamingConfig(UserPhonePreferences preferences)
    {
        return new Smartphone
        {
            Name = "Альтернативная игровая модель",
            Type = DeviceType.Smartphone,
            Manufacturer = "ASUS",
            Model = "ROG Phone 7",
            Price = (decimal)(GetRecommendedPrice(preferences) * 0.9),
            CPU = "Snapdragon 8+ Gen 1",
            GPU = "Adreno 730",
            RAM = 12,
            Storage = 256,
            ScreenSize = 6.78f,
            BatteryCapacity = 6000,
            OS = "Android",
            ImageUrl = "gaming_phone.jpg"
        };
    }

    private bool MatchPreferences(Smartphone device, UserPhonePreferences preferences)
    {
        // Проверка бюджета
        if (preferences.Budget == 1 && device.Price > 10000) return false;
        if (preferences.Budget == 2 && (device.Price < 10000 || device.Price > 20000)) return false;
        if (preferences.Budget == 3 && (device.Price < 20000 || device.Price > 40000)) return false;
        if (preferences.Budget == 4 && (device.Price < 40000 || device.Price > 60000)) return false;
        if (preferences.Budget == 5 && device.Price < 60000) return false;

        // Проверка основного использования
        if (preferences.PrimaryUse == "gaming" && !device.IsGoodForGaming()) return false;
        if (preferences.PrimaryUse == "photo" && !device.IsGoodForPhotography()) return false;
        if (preferences.PrimaryUse == "premium" && !device.IsPremium()) return false;

        // Проверка размера экрана
        if (preferences.ScreenSizePreference == 0 && device.ScreenSize >= 5.5) return false;
        if (preferences.ScreenSizePreference == 1 && (device.ScreenSize < 5.5 || device.ScreenSize > 6.2)) return false;
        if (preferences.ScreenSizePreference == 2 && (device.ScreenSize <= 6.2 || device.ScreenSize > 6.7)) return false;
        if (preferences.ScreenSizePreference == 3 && device.ScreenSize <= 6.7) return false;

        // Проверка 5G
        if (preferences.Needs5G && !device.Has5G) return false;

        return true;
    }
}