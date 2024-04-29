using WD7UVN_HFT_2023241.Models;
using System.ComponentModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels
{
    public class GetAllServicesViewModel : ObservableRecipient
    {
        public RestCollection<Service> Services { get; set; }

        private Service selectedService;

        public Service SelectedService
        {
            get { return selectedService; }
            set { SetProperty(ref selectedService, value); (UpdateServiceCommand as RelayCommand).NotifyCanExecuteChanged(); }
        }

        public ICommand UpdateServiceCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public GetAllServicesViewModel()
        {
            if (!IsInDesignMode)
            {
                Services = new RestCollection<Service>("http://localhost:5000/", "api/Service", "hub");

                UpdateServiceCommand = new RelayCommand(() =>
                {
                    Services.Update(SelectedService);
                },
                () =>
                {
                    return SelectedService != null;
                });
            }
        }
    }
}
