using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using DemoTry1.ViewModels;

namespace DemoTry1.Views;

public partial class Registration : Window
{
    public Registration()
    {
        InitializeComponent();
    }

    private void LogIn_OnClick(object? sender, RoutedEventArgs e)
    {
        RegistrationViewModel regViewModel = (RegistrationViewModel)DataContext!;
        if (regViewModel.NameController == "admin" && regViewModel.PassController == "admin")
        {
            new ProductsWindow(true).Show();
            this.Close();
        }
        else
        {
            new ProductsWindow(false).Show();
            this.Close();
        }
    }

    private void Quest_OnClick(object? sender, RoutedEventArgs e)
    {
        new ProductsWindow(false).Show();
        this.Close();
    }
}