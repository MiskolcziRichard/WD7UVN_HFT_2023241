using WD7UVN_HFT_2023241.Models;
using System.ComponentModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels
{
    public class CreateNewCustomerViewModel : ObservableRecipient
    {
        public Action CloseAction { get; set; }
        public event Action<Customer> NewCustomerCreated;

        public Customer newCustomer;
        public Customer NewCustomer
        {
            get { return newCustomer; }
            set
            {
                SetProperty(ref newCustomer, value);
                (CreateCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand CreateCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public CreateNewCustomerViewModel()
        {
            newCustomer = new Customer();

            if (!IsInDesignMode)
            {
                CreateCommand = new RelayCommand(() =>
                {
                    NewCustomerCreated?.Invoke(NewCustomer);
                    CloseAction();
                },
                () =>
                {
                    return NewCustomer != null;
                });
            }
        }
    }
}
