using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace DemoTry1.Views;

public partial class NotificationWindow : Window
{
    public NotificationWindow(string message)
    {
        InitializeComponent();
        Message.Text = message;
    }
}