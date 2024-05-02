using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using DemoTry1.Models;
using ReactiveUI;

namespace DemoTry1.ViewModels;

public class ProductsWindowViewModel : ViewModelBase
{
    private bool _isAdmin = false;
    public bool IsAdmin
    {
        get => _isAdmin;
        set => this.RaiseAndSetIfChanged(ref _isAdmin, value);
    }
    
    private Manufacturer _selectedManufacturer;
    
    public Manufacturer SelectedManufacturer
    {
        get => _selectedManufacturer;
        set => this.RaiseAndSetIfChanged(ref _selectedManufacturer, value);
    }

    private bool _isOrderByPrice = false;

    public bool IsOrderByPrice
    {
        get => _isOrderByPrice;
        set => this.RaiseAndSetIfChanged(ref _isOrderByPrice, value);
    }
    
    private string _filterText;
    public string FilterText
    {
        get => _filterText;
        set => this.RaiseAndSetIfChanged(ref _filterText, value);
    }

    private ObservableCollection<Product> _userProducts;
    private List<Product> _allUserProducts;
    private List<Manufacturer> _manufacturers;
        
    public List<Product> AllUserProducts
    {
        get => _allUserProducts;
        set => this.RaiseAndSetIfChanged(ref _allUserProducts, value);
    }
    
    public List<Manufacturer> Manufacturers
    {
        get => _manufacturers;
        set => this.RaiseAndSetIfChanged(ref _manufacturers, value);
    }

    public ObservableCollection<Product> UserProducts
    {
        get => _userProducts;
        set => this.RaiseAndSetIfChanged(ref _userProducts, value);
    }
    
    public ProductsWindowViewModel()
    {
        AllUserProducts = SessionData.Products;

        UserProducts = new ObservableCollection<Product>(AllUserProducts);

        Manufacturers = new List<Manufacturer>()
        {
            new Manufacturer("Any one"),
            new Manufacturer("SevkaIndastris"),
            new Manufacturer("DimkaIntertament"),
            new Manufacturer("SergeyCOm"),
            new Manufacturer("OOO LEgendus 228"),
        };

        this.WhenAnyValue(
                x => x.FilterText,
                x => x.SelectedManufacturer,
                x => x.IsOrderByPrice,
                (filterText, selectedManufacturer, isOrderByPrice) => (filterText, selectedManufacturer, isOrderByPrice))
            .Select(criteria => FilterProducts(criteria.filterText, criteria.selectedManufacturer, criteria.isOrderByPrice))
            .ObserveOn(RxApp.MainThreadScheduler)
            .Subscribe(filteredProducts => UserProducts = new ObservableCollection<Product>(filteredProducts));
    }

    public IEnumerable<Product> FilterProducts(string filterText, Manufacturer selectedManufacturer, bool isOrderByPrice)
    {
        var filteredProducts = string.IsNullOrWhiteSpace(filterText) ?
            _allUserProducts :
            _allUserProducts.Where(product => product.ProductName.Contains(filterText, StringComparison.OrdinalIgnoreCase));

        if (selectedManufacturer != null && selectedManufacturer.ManufacturerName != "Any one")
        {
            filteredProducts = filteredProducts.Where(product => product.ProductManufacturer == selectedManufacturer.ManufacturerName);
        }

        if (isOrderByPrice)
        {
            filteredProducts = filteredProducts.OrderBy(product => product.ProductPrice);
        }

        return filteredProducts;
    }
}