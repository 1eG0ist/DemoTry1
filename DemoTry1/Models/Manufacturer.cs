namespace DemoTry1.Models;

public class Manufacturer
{
    public string? ManufacturerName { get; set; }

    public Manufacturer(string name)
    {
        ManufacturerName = name;
    }
}