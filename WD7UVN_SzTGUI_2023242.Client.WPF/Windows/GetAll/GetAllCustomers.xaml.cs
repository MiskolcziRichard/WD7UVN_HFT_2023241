using System.Windows;
using WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels;

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
