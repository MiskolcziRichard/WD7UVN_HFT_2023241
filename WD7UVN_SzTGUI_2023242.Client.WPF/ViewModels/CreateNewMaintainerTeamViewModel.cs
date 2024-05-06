using WD7UVN_HFT_2023241.Models;
using System.ComponentModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels
{
    public class CreateNewMaintainerTeamViewModel : ObservableRecipient
    {
        public Action CloseAction { get; set; }
        public event Action<MaintainerTeam> NewMaintainerTeamCreated;

        public MaintainerTeam newMaintainerTeam;
        public MaintainerTeam NewMaintainerTeam
        {
            get { return newMaintainerTeam; }
            set
            {
                SetProperty(ref newMaintainerTeam, value);
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

        public CreateNewMaintainerTeamViewModel()
        {
            newMaintainerTeam = new MaintainerTeam();

            if (!IsInDesignMode)
            {
                CreateCommand = new RelayCommand(() =>
                {
                    NewMaintainerTeamCreated?.Invoke(NewMaintainerTeam);
                    CloseAction();
                },
                () =>
                {
                    return NewMaintainerTeam != null;
                });
            }
        }
    }
}
