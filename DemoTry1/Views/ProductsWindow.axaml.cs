using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DemoTry1.Models;
using DemoTry1.ViewModels;
using DynamicData;

namespace DemoTry1.Views;

public partial class ProductsWindow : Window
{
    public ProductsWindow(bool isAdmin)
    {
        InitializeComponent();
        DataContext = new ProductsWindowViewModel();
        ProductsWindowViewModel viewModel = (ProductsWindowViewModel)DataContext!;
        viewModel.IsAdmin = isAdmin;
    }

    public ProductsWindow()
    {
        InitializeComponent();
        DataContext = new ProductsWindowViewModel();

    }

    private void CreateProduct_OnClick(object? sender, RoutedEventArgs e)
    {
        ProductsWindowViewModel viewModel = (ProductsWindowViewModel)DataContext!;
        
        new EditProductWindow(new Product(), OnSave).Show();
    }

    private void OnSave(Product prod)
    {
        SessionData.Products.Add(prod);
        CallProductListSync();
    }
    
    private void OnEdit(Product prod)
    {
        SessionData.Products.Replace(ProductsList.SelectedItems[0] as Product, prod);
        CallProductListSync();
    }

    private void CallProductListSync()
    {
        ProductsWindowViewModel viewModel = (ProductsWindowViewModel)DataContext!;
        viewModel.FilterText = " ";
        viewModel.FilterText = "";
    }

    private void DeleteProduct_OnClick(object? sender, RoutedEventArgs e)
    {
        ProductsWindowViewModel viewModel = (ProductsWindowViewModel)DataContext!;
        if (ProductsList.SelectedItems.Count == 0)
        {
            new NotificationWindow("Select product!").Show();
        } else if (SessionData.Cart.Contains(ProductsList.SelectedItems[0] as Product))
        {
            new NotificationWindow("This product in cart.\nCan't delete").Show();
        } else
        {
            viewModel.AllUserProducts.Remove(ProductsList.SelectedItems[0] as Product);
            CallProductListSync();
        }
    }

    private void Exit_OnClick(object? sender, RoutedEventArgs e)
    {
        Registration regWindow = new Registration();
        regWindow.DataContext = new RegistrationViewModel();
        regWindow.Show();
        this.Close();
    }

    private void AddProductToCart_OnClick(object? sender, RoutedEventArgs e)
    {
        SessionData.Cart.Add(ProductsList.SelectedItems[0] as Product);
    }

    private void OpenCartWindow_OnClick(object? sender, RoutedEventArgs e)
    {
        new CartWindow().Show();
    }

    private void ProductsList_OnDoubleTapped(object? sender, TappedEventArgs e)
    {
        if (ProductsList.SelectedItems.Count == 0)
        {
            new NotificationWindow("Select product!").Show();
        } else if (SessionData.isEditWindowOpen)
        {
            new NotificationWindow("You already opened\nedit window!").Show();
        } else
        {
            new EditProductWindow(ProductsList.SelectedItems[0] as Product, OnEdit).Show();
            SessionData.isEditWindowOpen = true;
        }
    }
}