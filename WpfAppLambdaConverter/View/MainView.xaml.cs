using System.Windows;
using WpfAppLambdaConverter.ViewModel;

namespace WpfAppLambdaConverter
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
