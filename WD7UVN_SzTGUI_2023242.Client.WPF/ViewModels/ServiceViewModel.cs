using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WD7UVN_HFT_2023241.Models;

namespace WD7UVN_SzTGUI_2023242.Client.WPF
{
    internal class ServiceViewModel : ObservableRecipient
    {
        private string errorService;

        public string ErrorService
        {
            get { return errorService; }
            set { SetProperty(ref errorService, value); }
        }


        public RestCollection<Service> Services { get; set; }

        private string newServiceText;

        public string NewServiceText
        {
            get
            {
                return newServiceText;
            }
            set
            {
                newServiceText = value;
            }
        }

        public ICommand SendServiceCommand { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public ServiceViewModel()
        {
            if (!IsInDesignMode)
            {
                Services = new RestCollection<Service>("http://localhost:62005/", "Service", "hub");
                SendServiceCommand = new RelayCommand(() =>
                {
                    Services.Add(new Service(1, NewServiceText, DateTime.Now, new User(1, "Én")));
                });
            }
        }
    }
}
