using System.Windows;
using WpfAppValidationAttribute.ViewModel;

namespace WpfAppValidationAttribute
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
