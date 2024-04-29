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
