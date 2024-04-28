using WD7UVN_HFT_2023241.Models;
using System.ComponentModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Service> Services { get; set; }
        public RestCollection<MaintainerTeam> MaintainerTeams { get; set; }
        public RestCollection<Customer> Customers { get; set; }
        public RestCollection<Employee> Employees { get; set; }

        private Service selectedService;
        public Service SelectedService
        {
            get { return selectedService; }
            set { SetProperty(ref selectedService, value); (DeleteServiceCommand as RelayCommand).NotifyCanExecuteChanged(); }
        }
        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set { SetProperty(ref selectedEmployee, value); (DeleteEmployeeCommand as RelayCommand).NotifyCanExecuteChanged(); }
        }
        private Customer selectedCustomer;
        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set { SetProperty(ref selectedCustomer, value); (DeleteCustomerCommand as RelayCommand).NotifyCanExecuteChanged(); }
        }
        private MaintainerTeam selectedMaintainerTeam;
        public MaintainerTeam SelectedMaintainerTeam
        {
            get { return selectedMaintainerTeam; }
            set { SetProperty(ref selectedMaintainerTeam, value); (DeleteMaintainerTeamCommand as RelayCommand).NotifyCanExecuteChanged(); }
        }

        public ICommand DeleteServiceCommand { get; set; }
        public ICommand DeleteCustomerCommand { get; set; }
        public ICommand DeleteMaintainerTeamCommand { get; set; }
        public ICommand DeleteEmployeeCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Services = new RestCollection<Service>("http://localhost:5000/", "api/Service", "hub");
                Employees = new RestCollection<Employee>("http://localhost:5000/", "api/Employee", "hub");
                MaintainerTeams = new RestCollection<MaintainerTeam>("http://localhost:5000/", "api/MaintainerTeam", "hub");
                Customers = new RestCollection<Customer>("http://localhost:5000/", "api/Customer", "hub");

                DeleteServiceCommand = new RelayCommand(() =>
                {
                    Services.Delete(SelectedService.ID);
                },
                () =>
                {
                    return SelectedService != null;
                });

                DeleteCustomerCommand = new RelayCommand(() =>
                {
                    Customers.Delete(SelectedCustomer.ID);
                },
                () =>
                {
                    return SelectedCustomer != null;
                });

                DeleteEmployeeCommand = new RelayCommand(() =>
                {
                    Employees.Delete(SelectedEmployee.ID);
                },
                () =>
                {
                    return SelectedEmployee != null;
                });

                DeleteMaintainerTeamCommand = new RelayCommand(() =>
                {
                    MaintainerTeams.Delete(SelectedMaintainerTeam.ID);
                },
                () =>
                {
                    return SelectedMaintainerTeam != null;
                });
            }
        }
    }
}
