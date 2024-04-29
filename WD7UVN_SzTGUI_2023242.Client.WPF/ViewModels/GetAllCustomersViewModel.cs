using WD7UVN_HFT_2023241.Models;
using System.ComponentModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels
{
    public class GetAllCustomersViewModel : ObservableRecipient
    {
        public RestCollection<Customer> Customers { get; set; }

        private Customer selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set { SetProperty(ref selectedCustomer, value); (UpdateCustomerCommand as RelayCommand).NotifyCanExecuteChanged(); }
        }

        public ICommand UpdateCustomerCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public GetAllCustomersViewModel()
        {
            if (!IsInDesignMode)
            {
                Customers = new RestCollection<Customer>("http://localhost:5000/", "api/Customer", "hub");

                UpdateCustomerCommand = new RelayCommand(() =>
                {
                    Customers.Update(SelectedCustomer);
                },
                () =>
                {
                    return SelectedCustomer != null;
                });
            }
        }
    }
}
