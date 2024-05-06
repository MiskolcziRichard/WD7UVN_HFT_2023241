using System.Windows;
using WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.Windows
{
    /// <summary>
    /// Interaction logic for GetAllMaintainerTeams.xaml
    /// </summary>
    public partial class GetAllMaintainerTeams : Window
    {
        public GetAllMaintainerTeams()
        {
            InitializeComponent();
        }

        private void CreateNewMaintainerTeam(object sender, RoutedEventArgs e)
        {
            CreateNewMaintainerTeamViewModel viewModel = new CreateNewMaintainerTeamViewModel();
            viewModel.NewMaintainerTeamCreated += (newMaintainerTeam) =>
            {
                var getAllMaintainerTeamsViewModel = (GetAllMaintainerTeamsViewModel)DataContext;
                if (getAllMaintainerTeamsViewModel != null)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        getAllMaintainerTeamsViewModel.MaintainerTeams.Add(newMaintainerTeam);
                    }); 
                }
            };
            Window window = new CreateNewMaintainerTeam(viewModel);
            window.Show();
        }
    }
}
