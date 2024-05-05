using System.Windows;
using WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels;
using WD7UVN_SzTGUI_2023242.Client.WPF.Windows;

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
            Window window = new GetAllCustomers();
            window.Show();
        }

        private void ExpandAllEmployees(object sender, RoutedEventArgs e)
        {
            Window window = new GetAllEmployees();
            window.Show();
        }

        private void ExpandAllMaintainerTeams(object sender, RoutedEventArgs e)
        {
            Window window = new GetAllMaintainerTeams();
            window.Show();
        }

        private void CreateNewCustomer(object sender, RoutedEventArgs e)
        {
            CreateNewCustomerViewModel viewModel = new CreateNewCustomerViewModel();
            viewModel.NewCustomerCreated += (newCustomer) =>
            {
                var getAllCustomersViewModel = (GetAllCustomersViewModel)DataContext;
                if (getAllCustomersViewModel != null)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        getAllCustomersViewModel.Customers.Add(newCustomer);
                    }); 
                }
            };
            Window window = new CreateNewCustomer(viewModel);
            window.Show();
        }
    }
}
