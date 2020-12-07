using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace SpotiStore.Views
{
    public class PlaylistFinderView : UserControl
    {
        public PlaylistFinderView()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
