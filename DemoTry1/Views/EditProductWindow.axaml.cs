using System;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using DemoTry1.Delegates;
using DemoTry1.Models;
using DemoTry1.ViewModels;

namespace DemoTry1.Views;

public partial class EditProductWindow : Window
{
    private SaveProductDelegate onSave;

    public override void Show()
    {
        SessionData.isEditWindowOpen = true;
        base.Show();
    }

    public EditProductWindow(Product product, SaveProductDelegate onSave)
    {
        InitializeComponent();
        DataContext = new EditProductWindowViewModel(product);
        this.onSave = onSave;
        Closing += (s, e) =>
        {
            SessionData.isEditWindowOpen = false;
            e.Cancel = false;
        };
    }
    
    public EditProductWindow()
    {
        InitializeComponent();
        DataContext = new EditProductWindowViewModel(new Product());
    }
    
    private async void SetImageButton_OnClick(object? sender, RoutedEventArgs e)
    {
        EditProductWindowViewModel viewModel = (EditProductWindowViewModel)DataContext!;
        OpenFileDialog dialog = new OpenFileDialog();
        var result = await dialog.ShowAsync(new EditProductWindow());
        viewModel.EditingProduct.ProductImagePath = result[0];
        viewModel.ProductImage = new Bitmap(result[0]);
    }


    private void Save_OnClick(object? sender, RoutedEventArgs e)
    {
        EditProductWindowViewModel viewModel = (EditProductWindowViewModel)DataContext!;
        viewModel.EditingProduct.ProductManufacturer = viewModel.SelectedManufacturer.ManufacturerName;
        onSave(viewModel.EditingProduct);
        SessionData.isEditWindowOpen = false;
        this.Close();
    }
}