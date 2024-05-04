using WD7UVN_HFT_2023241.Models;
using System.ComponentModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels
{
    public class GetResponsibleEmployeeViewModel : ObservableRecipient
    {
        //Hiába egyetlen eredmény van, meghagyom RestCollection-nek a SignalR miatt
        public RestCollection<Employee> Employees { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public GetResponsibleEmployeeViewModel(Service s)
        {
            if (!IsInDesignMode)
            {
                Employees = new RestCollection<Employee>("http://localhost:5000/", "api/WhoIsResponsibleForService?id=" + s.ID.ToString(), "hub", true);
            }
        }
    }
}
