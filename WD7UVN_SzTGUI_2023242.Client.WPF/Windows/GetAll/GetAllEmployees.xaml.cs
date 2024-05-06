using System.Windows;
using WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.Windows
{
    /// <summary>
    /// Interaction logic for GetAllEmployees.xaml
    /// </summary>
    public partial class GetAllEmployees : Window
    {
        public GetAllEmployees()
        {
            InitializeComponent();
        }

        private void CreateNewEmployee(object sender, RoutedEventArgs e)
        {
            CreateNewEmployeeViewModel viewModel = new CreateNewEmployeeViewModel();
            viewModel.NewEmployeeCreated += (newEmployee) =>
            {
                var getAllEmployeesViewModel = (GetAllEmployeesViewModel)DataContext;
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
    }
}
