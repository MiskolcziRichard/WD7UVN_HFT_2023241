using System.Windows;
using WD7UVN_HFT_2023241.Models;

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

            Services = new RestCollection<Service>("https://localhost:5001", "Service", "hub");
        }
    }
}
