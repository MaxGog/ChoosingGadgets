namespace ChoosingGadgets.Models;

public class Smartphone : Device
{
    public string ScreenSize { get; set; }
    public string Resolution { get; set; }
    public string CPU { get; set; }
    public int RAM { get; set; } // в ГБ
    public int Storage { get; set; } // в ГБ
    public string Camera { get; set; }
    public string Battery { get; set; }
}