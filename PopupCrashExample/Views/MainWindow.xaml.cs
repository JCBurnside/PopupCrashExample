using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;

namespace PopupCrashExample.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private int clicksRemaining = 2;

        public static readonly AvaloniaProperty<string> ClickStringProperty
            = AvaloniaProperty.RegisterDirect<MainWindow, string>(nameof(ClickString), o => o.ClickString);

        public string ClickString => $"Click the button {clicksRemaining} more {(clicksRemaining>1?"times":"time")}";

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void ShowPopup(Control child)
        {
            if(clicksRemaining>0)
            {
                var oldString = ClickString;
                clicksRemaining--;
                this.RaisePropertyChanged(ClickStringProperty, oldString, ClickString);
            }

            var popup = new Popup()
            {
                Child = child,
                PlacementTarget = this,
                PlacementMode = PlacementMode.Pointer,
                StaysOpen = false
            };
            popup.Open();
        }
    }
}
