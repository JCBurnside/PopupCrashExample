using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.Controls.ApplicationLifetimes;
using PopupCrashExample.Views;

namespace PopupCrashExample
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            switch(this.ApplicationLifetime)
            {
                case IClassicDesktopStyleApplicationLifetime desktop:
                    desktop.MainWindow = new MainWindow();
                    break;
            }
        }
    }
}
