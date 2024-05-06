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
                var getAllCustomersViewModel = (MainWindowViewModel)DataContext;
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

        private void CreateNewEmployee(object sender, RoutedEventArgs e)
        {
            CreateNewEmployeeViewModel viewModel = new CreateNewEmployeeViewModel();
            viewModel.NewEmployeeCreated += (newEmployee) =>
            {
                var getAllEmployeesViewModel = (MainWindowViewModel)DataContext;
                if (getAllEmployeesViewModel != null)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        getAllEmployeesViewModel.Employees.Add(newEmployee);
                    }); 
                }
            };
            Window window = new CreateNewEmployee(viewModel);
            window.Show();
        }

        private void CreateNewMaintainerTeam(object sender, RoutedEventArgs e)
        {
            CreateNewMaintainerTeamViewModel viewModel = new CreateNewMaintainerTeamViewModel();
            viewModel.NewMaintainerTeamCreated += (newMaintainerTeam) =>
            {
                var getAllMaintainerTeamsViewModel = (MainWindowViewModel)DataContext;
                if (getAllMaintainerTeamsViewModel != null)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        getAllMaintainerTeamsViewModel.MaintainerTeams.Add(newMaintainerTeam);
                    }); 
                }
            };
            Window window = new CreateNewMaintainerTeam(viewModel);
            window.Show();
        }

        private void CreateNewService(object sender, RoutedEventArgs e)
        {
            CreateNewServiceViewModel viewModel = new CreateNewServiceViewModel();
            viewModel.NewServiceCreated += (newService) =>
            {
                var getAllServicesViewModel = (MainWindowViewModel)DataContext;
                if (getAllServicesViewModel != null)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        getAllServicesViewModel.Services.Add(newService);
                    }); 
                }
            };
            Window window = new CreateNewService(viewModel);
            window.Show();
        }
    }
}
