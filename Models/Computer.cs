namespace ChoosingGadgets.Models;

public class Computer : Device
{
    public string Processor { get; set; }
    public string GPU { get; set; }
    public int RAM { get; set; } // в ГБ
    public string Storage { get; set; }
    public string OS { get; set; }
}