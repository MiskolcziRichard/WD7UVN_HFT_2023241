﻿using WD7UVN_HFT_2023241.Models;
using System.ComponentModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using WD7UVN_SzTGUI_2023242.Client.WPF.Windows;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels
{
    public class GetAllEmployeesViewModel : ObservableRecipient
    {
        public RestCollection<Employee> Employees { get; set; }

        private Employee selectedEmployee;

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                SetProperty(ref selectedEmployee, value);
                (UpdateEmployeeCommand as RelayCommand).NotifyCanExecuteChanged();
                (DeleteEmployeeCommand as RelayCommand).NotifyCanExecuteChanged();
                (GetSubordinatesCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand UpdateEmployeeCommand { get; set; }
        public ICommand DeleteEmployeeCommand { get; set; }
        public ICommand GetSubordinatesCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public GetAllEmployeesViewModel()
        {
            if (!IsInDesignMode)
            {
                Employees = new RestCollection<Employee>("http://localhost:5000/", "api/Employee", "hub");

                UpdateEmployeeCommand = new RelayCommand(() =>
                {
                    Employees.Update(SelectedEmployee);
                },
                () =>
                {
                    return SelectedEmployee != null;
                });

                DeleteEmployeeCommand = new RelayCommand(() =>
                {
                    Employees.Delete(SelectedEmployee.ID);
                },
                () =>
                {
                    return SelectedEmployee != null;
                });

                GetSubordinatesCommand = new RelayCommand(() =>
                {
                    Window window = new GetSubordinates(SelectedEmployee);
                    window.Show();
                },
                () =>
                {
                    return SelectedEmployee != null;
                });
            }
        }
    }
}
