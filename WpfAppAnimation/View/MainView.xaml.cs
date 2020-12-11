using System.Windows;
using WpfAppAnimation.ViewModel;

namespace WpfAppAnimation.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainViewModel ViewModel { get => DataContext as MainViewModel; }

        public MainView()
        {
            InitializeComponent();
        }
    }
}
