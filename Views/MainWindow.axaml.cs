using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using SpotiStore.ViewModels;

namespace SpotiStore.Views
{
    public class MainWindow : Window
    {
        MainWindowViewModel vm;
        public MainWindow()
        {

            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }


        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
