using WD7UVN_HFT_2023241.Models;
using System.ComponentModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels
{
    public class GetUsersViewModel : ObservableRecipient
    {
        public RestCollection<Customer> Clients { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public GetUsersViewModel(Service e)
        {
            if (!IsInDesignMode)
            {
                Clients = new RestCollection<Customer>("http://localhost:5000/", "api/WhoUsesService?id=" + e.ID.ToString(), "hub", true);
            }
        }
    }
}
