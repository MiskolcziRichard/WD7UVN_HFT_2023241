using System.Windows;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.Windows
{
    /// <summary>
    /// Interaction logic for GetAllServices.xaml
    /// </summary>
    public partial class GetAllServices : Window
    {
        public GetAllServices()
        {
            InitializeComponent();
        }

        private void CreateNewService(object sender, RoutedEventArgs e)
        {
            Window window = new CreateNewService();
            window.Show();
        }
    }
}
