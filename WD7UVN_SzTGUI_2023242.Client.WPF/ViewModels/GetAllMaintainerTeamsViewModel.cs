﻿using WD7UVN_HFT_2023241.Models;
using System.ComponentModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using WD7UVN_SzTGUI_2023242.Client.WPF.Windows;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels
{
    public class GetAllMaintainerTeamsViewModel : ObservableRecipient
    {
        public RestCollection<MaintainerTeam> MaintainerTeams { get; set; }

        private MaintainerTeam selectedMaintainerTeam;

        public MaintainerTeam SelectedMaintainerTeam
        {
            get { return selectedMaintainerTeam; }
            set
            {
                SetProperty(ref selectedMaintainerTeam, value);
                (UpdateMaintainerTeamCommand as RelayCommand).NotifyCanExecuteChanged();
                (GetColleaguesCommand as RelayCommand).NotifyCanExecuteChanged();
                (DeleteMaintainerTeamCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand UpdateMaintainerTeamCommand { get; set; }
        public ICommand GetColleaguesCommand { get; set; }
        public ICommand DeleteMaintainerTeamCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public GetAllMaintainerTeamsViewModel()
        {
            if (!IsInDesignMode)
            {
                MaintainerTeams = new RestCollection<MaintainerTeam>("http://localhost:5000/", "api/MaintainerTeam", "hub");

                UpdateMaintainerTeamCommand = new RelayCommand(() =>
                {
                    MaintainerTeams.Update(SelectedMaintainerTeam);
                },
                () =>
                {
                    return SelectedMaintainerTeam != null;
                });

                DeleteMaintainerTeamCommand = new RelayCommand(() =>
                {
                    MaintainerTeams.Delete(SelectedMaintainerTeam.ID);
                },
                () =>
                {
                    return SelectedMaintainerTeam != null;
                });

                GetColleaguesCommand = new RelayCommand(() =>
                {
                    Window window = new GetColleagues(SelectedMaintainerTeam);
                    window.Show();
                },
                () =>
                {
                    return SelectedMaintainerTeam != null;
                });
            }
        }
    }
}
