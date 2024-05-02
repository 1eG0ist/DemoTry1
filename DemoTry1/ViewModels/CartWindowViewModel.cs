using System.Collections.Generic;
using System.Collections.ObjectModel;
using DemoTry1.Models;
using ReactiveUI;

namespace DemoTry1.ViewModels;

public class CartWindowViewModel: ViewModelBase
{
    private ObservableCollection<Product> _cart;

    public ObservableCollection<Product> Cart
    {
        get => _cart;
        set => this.RaiseAndSetIfChanged(ref _cart, value);
    }

    public CartWindowViewModel()
    {
        Cart = SessionData.Cart;
    }
}