using Avalonia.Media.Imaging;

namespace DemoTry1.Models;

public partial class Product
{ 
    public string? ProductImagePath { get; set; }
    public string? ProductName { get; set; }

    public string? ProductManufacturer { get; set; }

    public float? ProductPrice { get; set; }

    public string? ProductDescription { get; set; }

    public int? ProductCount { get; set; }
}