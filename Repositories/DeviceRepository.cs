using AngleSharp.Common;
using SQLite;

using ChoosingGadgets.Constants;
using ChoosingGadgets.Models;

using Device = ChoosingGadgets.Models.Device;
using DeviceType = ChoosingGadgets.Models.DeviceType;

namespace ChoosingGadgets.Repositories;

public class DeviceRepository
{
    private SQLiteAsyncConnection _database;

    public DeviceRepository()
    {
        _database = new SQLiteAsyncConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);
        InitializeDatabaseAsync().SafeFireAndForget();
    }

    private async Task InitializeDatabaseAsync()
    {
        await _database.CreateTableAsync<Computer>();
        await _database.CreateTableAsync<Smartphone>();
    }

    public async Task<List<Device>> GetAllDevicesAsync()
    {
        var computers = await _database.Table<Computer>().ToListAsync();
        var smartphones = await _database.Table<Smartphone>().ToListAsync();

        return computers.Cast<Device>().Concat(smartphones).ToList();
    }

    public async Task<List<Device>> GetDevicesByTypeAsync(DeviceType deviceType)
    {
        return deviceType switch
        {
            DeviceType.Computer => [.. (await _database.Table<Computer>().ToListAsync()).Cast<Device>()],
            DeviceType.Smartphone => [.. (await _database.Table<Smartphone>().ToListAsync()).Cast<Device>()],
            _ => await GetAllDevicesAsync()
        };
    }

    public async Task<Device> GetDeviceByIdAsync(int id, DeviceType deviceType)
    {
        return deviceType switch
        {
            DeviceType.Computer => await _database.Table<Computer>().FirstOrDefaultAsync(x => x.Id == id),
            DeviceType.Smartphone => await _database.Table<Smartphone>().FirstOrDefaultAsync(x => x.Id == id),
            _ => null
        };
    }

    public async Task AddDeviceAsync(Device device)
    {
        if (device is Computer computer)
            await _database.InsertAsync(computer);
        else if (device is Smartphone smartphone)
            await _database.InsertAsync(smartphone);
    }

    public async Task UpdateDeviceAsync(Device device)
    {
        if (device is Computer computer)
            await _database.UpdateAsync(computer);
        else if (device is Smartphone smartphone)
            await _database.UpdateAsync(smartphone);
    }

    public async Task DeleteDeviceAsync(Device device)
    {
        if (device is Computer computer)
            await _database.DeleteAsync<Computer>(computer.Id);
        else if (device is Smartphone smartphone)
            await _database.DeleteAsync<Smartphone>(smartphone.Id);
    }

    public async Task<int> DeleteAllDevicesAsync()
    {
        var computersDeleted = await _database.DeleteAllAsync<Computer>();
        var smartphonesDeleted = await _database.DeleteAllAsync<Smartphone>();
        return computersDeleted + smartphonesDeleted;
    }

    public async Task<List<Device>> SearchDevicesAsync(string searchTerm)
    {
        var computers = await _database.Table<Computer>()
            .Where(c => c.Name.Contains(searchTerm) ||
                       c.Manufacturer.Contains(searchTerm) ||
                       c.Model.Contains(searchTerm))
            .ToListAsync();

        var smartphones = await _database.Table<Smartphone>()
            .Where(s => s.Name.Contains(searchTerm) ||
                       s.Manufacturer.Contains(searchTerm) ||
                       s.Model.Contains(searchTerm))
            .ToListAsync();

        return computers.Cast<Device>().Concat(smartphones).ToList();
    }

    public async Task<bool> DeviceExistsAsync(Device device)
    {
        if (device is Computer computer)
            return await _database.Table<Computer>().FirstOrDefaultAsync(c =>
                c.Manufacturer == computer.Manufacturer &&
                c.Model == computer.Model) != null;

        if (device is Smartphone smartphone)
            return await _database.Table<Smartphone>().FirstOrDefaultAsync(s =>
                s.Manufacturer == smartphone.Manufacturer &&
                s.Model == smartphone.Model) != null;

        return false;
    }

    public async Task<int> GetDevicesCountAsync()
    {
        var computersCount = await _database.Table<Computer>().CountAsync();
        var smartphonesCount = await _database.Table<Smartphone>().CountAsync();
        return computersCount + smartphonesCount;
    }
}

public static class TaskExtensions
{
    public static void SafeFireAndForget(this Task task, bool continueOnCapturedContext = true, Action<Exception>? onException = null)
    {
        task.ContinueWith(t =>
        {
            if (t.IsFaulted && onException != null)
                onException(t.Exception);
        },
        continueOnCapturedContext ? TaskScheduler.FromCurrentSynchronizationContext() : TaskScheduler.Default);
    }
}