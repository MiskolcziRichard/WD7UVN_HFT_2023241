using System.Windows;
using WD7UVN_HFT_2023241.Models;
using WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.Windows
{
    public partial class GetColleagues : Window
    {
        private readonly GetColleaguesViewModel viewModel;
        public GetColleagues(MaintainerTeam m)
        {
            InitializeComponent();
            viewModel = new GetColleaguesViewModel(m);
            this.DataContext = viewModel;
        }
    }
}
