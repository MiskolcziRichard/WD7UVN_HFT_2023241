using System.Windows;
using WD7UVN_HFT_2023241.Models;
using WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.Windows
{
    public partial class GetUsers : Window
    {
        private readonly GetUsersViewModel viewModel;
        public GetUsers(Service s)
        {
            InitializeComponent();
            viewModel = new GetUsersViewModel(s);
            this.DataContext = viewModel;
        }
    }
}
