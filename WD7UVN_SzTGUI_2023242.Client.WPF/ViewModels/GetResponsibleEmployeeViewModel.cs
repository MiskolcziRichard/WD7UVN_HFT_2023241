using WD7UVN_HFT_2023241.Models;
using System.ComponentModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels
{
    public class GetResponsibleEmployeeViewModel : ObservableRecipient
    {
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
                Employees = new RestCollection<Employee>("http://localhost:5000/", "api/WhoIsResponsibleForService?id=" + s.ID.ToString(), "hub", true, true);
            }
        }
    }
}
