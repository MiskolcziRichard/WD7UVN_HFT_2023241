using System.Windows;
using WD7UVN_HFT_2023241.Models;
using WD7UVN_SzTGUI_2023242.Client.WPF.Windows;

namespace WD7UVN_SzTGUI_2023242.Client.WPF
{
    /// <summary>
    /// Interaction logic for GetAllServices.xaml
    /// </summary>
    public partial class GetAllServices : Window
    {
        public RestCollection<Service> Services { get; }

        public GetAllServices()
        {
            InitializeComponent();

            Services = new RestCollection<Service>("http://localhost:5000/", "api/Service");
        }

        private void CreateNewService(object sender, RoutedEventArgs e)
        {
            Window window = new CreateNewService();
            window.Show();
        }
    }
}
