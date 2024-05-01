using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DemoTry1.ViewModels;
using DemoTry1.Views;

namespace DemoTry1;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new Registration()
            {
                DataContext = new RegistrationViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}