using WD7UVN_HFT_2023241.Models;
using System.ComponentModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels
{
    public class CreateNewServiceViewModel : ObservableRecipient
    {
        public Action CloseAction { get; set; }
        public event Action<Service> NewServiceCreated;

        public Service newService;
        public Service NewService
        {
            get { return newService; }
            set
            {
                SetProperty(ref newService, value);
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

        public CreateNewServiceViewModel()
        {
            newService = new Service();

            if (!IsInDesignMode)
            {
                CreateCommand = new RelayCommand(() =>
                {
                    NewServiceCreated?.Invoke(NewService);
                    CloseAction();
                },
                () =>
                {
                    return NewService != null;
                });
            }
        }
    }
}
