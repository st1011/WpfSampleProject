using System.Windows;
using WpfAppDependencyProperty.ViewModel;

namespace WpfAppDependencyProperty
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.TimePickerInstance.AllTextBoxEnable = !this.TimePickerInstance.AllTextBoxEnable;
        }
    }
}
