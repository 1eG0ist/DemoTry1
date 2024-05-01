using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Avalonia.Media.Imaging;
using DemoTry1.Models;
using ReactiveUI;

namespace DemoTry1.ViewModels;

public class EditProductWindowViewModel: ViewModelBase
{
    private Product _editingProduct;
    private ObservableCollection<Manufacturer> _manufacturers;
    
    private Bitmap? _productImage;
    
    public Bitmap? ProductImage
    {
        get => _productImage;
        set => this.RaiseAndSetIfChanged(ref _productImage, value);
    }

    public ObservableCollection<Manufacturer> Manufacturers
    {
        get => _manufacturers;
        set => this.RaiseAndSetIfChanged(ref _manufacturers, value);
    }
    
    private Manufacturer _selectedManufacturer;
    public Manufacturer SelectedManufacturer
    {
        get => _selectedManufacturer;
        set => this.RaiseAndSetIfChanged(ref _selectedManufacturer, value);
    }
    
    public Product EditingProduct
    {
        get => _editingProduct;
        set => this.RaiseAndSetIfChanged(ref _editingProduct, value);
    }

    public EditProductWindowViewModel(Product editProduct)
    {
        EditingProduct = editProduct;
        if (editProduct.ProductManufacturer == null) SelectedManufacturer = new Manufacturer("No manufacturer");
        else SelectedManufacturer = new Manufacturer(editProduct.ProductManufacturer);
        Manufacturers = new ObservableCollection<Manufacturer>
        {
            new Manufacturer("SevkaIndastris"),
            new Manufacturer("DimkaIntertament"),
            new Manufacturer("SergeyCOm"),
            new Manufacturer("OOO LEgendus 228"),
        };
        LoadProductImage();
    }
    
    private void LoadProductImage()
    {
        // Проверяем, есть ли путь к изображению
        if (EditingProduct.ProductImagePath == null)
        {
            string defaultImagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Assets", "default_product_image.jpg");
            EditingProduct.ProductImagePath = defaultImagePath;
        }

        ProductImage = new Bitmap(EditingProduct.ProductImagePath);
    }
}