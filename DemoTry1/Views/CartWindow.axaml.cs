using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using DemoTry1.ViewModels;

namespace DemoTry1.Views;

public partial class CartWindow : Window
{
    public CartWindow()
    {
        InitializeComponent();
        DataContext = new CartWindowViewModel();
    }
}