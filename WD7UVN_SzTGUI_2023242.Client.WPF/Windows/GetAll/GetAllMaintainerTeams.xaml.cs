using System.Windows;

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
            Window window = new CreateNewMaintainerTeam();
            window.Show();
        }
    }
}
