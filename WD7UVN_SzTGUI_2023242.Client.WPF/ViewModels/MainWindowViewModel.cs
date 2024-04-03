using WD7UVN_HFT_2023241.Models;
using System.ComponentModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Service> Services { get; set; }
        public RestCollection<MaintainerTeam> MaintainerTeams { get; set; }
        public RestCollection<Customer> Customers { get; set; }
        public RestCollection<Employee> Employees { get; set; }

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
                Services = new RestCollection<Service>("http://localhost:5000/", "api/Service");
                Employees = new RestCollection<Employee>("http://localhost:5000/", "api/Employee");
                MaintainerTeams = new RestCollection<MaintainerTeam>("http://localhost:5000/", "api/MaintainerTeam");
                Customers = new RestCollection<Customer>("http://localhost:5000/", "api/Customer");
            }
        }
    }
}
