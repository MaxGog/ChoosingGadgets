using SQLite;

namespace ChoosingGadgets.Models;

public class Device
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public DeviceType Type { get; set; } // Компьютеры, смартфоны
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public string SourceUrl { get; set; }
}