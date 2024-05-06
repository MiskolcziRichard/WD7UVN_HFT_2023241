using WD7UVN_HFT_2023241.Models;
using System.ComponentModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels
{
    public class CreateNewEmployeeViewModel : ObservableRecipient
    {
        public Action CloseAction { get; set; }
        public event Action<Employee> NewEmployeeCreated;

        public Employee newEmployee;
        public Employee NewEmployee
        {
            get { return newEmployee; }
            set
            {
                SetProperty(ref newEmployee, value);
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

        public CreateNewEmployeeViewModel()
        {
            newEmployee = new Employee();

            if (!IsInDesignMode)
            {
                CreateCommand = new RelayCommand(() =>
                {
                    NewEmployeeCreated?.Invoke(NewEmployee);
                    CloseAction();
                },
                () =>
                {
                    return NewEmployee != null;
                });
            }
        }
    }
}
