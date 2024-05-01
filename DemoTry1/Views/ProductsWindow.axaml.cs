using System;
using Avalonia;
using Avalonia.Controls;
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
        ProductsWindowViewModel viewModel = (ProductsWindowViewModel)DataContext!;
        viewModel.AllUserProducts.Add(prod);
        CallProductListSync();
    }

    private void EditProduct_OnClick(object? sender, RoutedEventArgs e)
    {
        ProductsWindowViewModel viewModel = (ProductsWindowViewModel)DataContext!;
        if (ProductsList.SelectedItems.Count == 0)
        {
            new NotificationWindow("Select product!").Show();
        }
        else
        {
            new EditProductWindow(ProductsList.SelectedItems[0] as Product, OnEdit).Show();
        }
    }
    
    private void OnEdit(Product prod)
    {
        ProductsWindowViewModel viewModel = (ProductsWindowViewModel)DataContext!;
        viewModel.AllUserProducts.Replace(ProductsList.SelectedItems[0] as Product, prod);
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
        }
        else
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
}