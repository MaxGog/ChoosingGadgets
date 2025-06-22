using ChoosingGadgets.Repositories;

namespace ChoosingGadgets.Services;

public class BackgroundParserService
{
    private readonly ParserService _parser;
    private readonly DeviceRepository _repository;
    
    public BackgroundParserService(ParserService parser, DeviceRepository repository)
    {
        _parser = parser;
        _repository = repository;
    }
    
    public async Task StartPeriodicParsing(TimeSpan interval, CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            await ParsePopularSites();
            await Task.Delay(interval, cancellationToken);
        }
    }
    
    private async Task ParsePopularSites()
    {
        var sites = new Dictionary<string, Models.DeviceType>
        {
            {"https://www.dns-shop.ru/catalog/17a892f816404e77/noutbuki/", Models.DeviceType.Computer},
            {"https://www.gsmarena.com/samsung-phones-9.php", Models.DeviceType.Smartphone}
        };
        
        foreach (var site in sites)
        {
            var devices = await _parser.ParseDevicesFromWeb(site.Value, site.Key);
            foreach (var device in devices)
            {
                await _repository.AddDeviceAsync(device);
            }
        }
    }
}