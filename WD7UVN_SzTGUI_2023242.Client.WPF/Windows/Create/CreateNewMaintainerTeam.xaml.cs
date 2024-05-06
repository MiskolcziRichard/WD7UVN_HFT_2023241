using System;
using System.Windows;
using WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.Windows
{
    public partial class CreateNewMaintainerTeam : Window
    {
        public CreateNewMaintainerTeam(CreateNewMaintainerTeamViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.CloseAction = new Action(() => this.Close());
        }
    }
}
