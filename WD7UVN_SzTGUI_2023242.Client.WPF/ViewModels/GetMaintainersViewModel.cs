﻿using WD7UVN_HFT_2023241.Models;
using System.ComponentModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels
{
    public class GetMaintainersViewModel : ObservableRecipient
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

        public GetMaintainersViewModel(Service e)
        {
            if (!IsInDesignMode)
            {
                Employees = new RestCollection<Employee>("http://localhost:5000/", "api/WhoMaintainsService?id=" + e.ID.ToString(), "hub", true);
            }
        }
    }
}
