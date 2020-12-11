using System.Windows;
using WpfSampleProject.ViewModel;

namespace WpfSampleProject.View
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
