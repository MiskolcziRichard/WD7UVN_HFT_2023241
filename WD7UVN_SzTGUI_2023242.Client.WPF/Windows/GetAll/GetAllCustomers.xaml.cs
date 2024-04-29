using System.Windows;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.Windows
{
    /// <summary>
    /// Interaction logic for GetAllCustomers.xaml
    /// </summary>
    public partial class GetAllCustomers : Window
    {
        public GetAllCustomers()
        {
            InitializeComponent();
        }

        private void CreateNewCustomer(object sender, RoutedEventArgs e)
        {
            Window window = new CreateNewCustomer();
            window.Show();
        }
    }
}
