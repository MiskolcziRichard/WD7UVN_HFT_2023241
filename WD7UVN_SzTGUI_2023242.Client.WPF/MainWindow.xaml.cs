using System.Windows;

namespace WD7UVN_SzTGUI_2023242.Client.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExpandAllServices(object sender, RoutedEventArgs e)
        {
            Window window = new GetAllServices();
            window.Show();
        }

        private void ExpandAllCustomers(object sender, RoutedEventArgs e)
        {

        }

        private void ExpandAllEmployees(object sender, RoutedEventArgs e)
        {

        }

        private void ExpandAllMaintainerTeams(object sender, RoutedEventArgs e)
        {

        }
    }
}
