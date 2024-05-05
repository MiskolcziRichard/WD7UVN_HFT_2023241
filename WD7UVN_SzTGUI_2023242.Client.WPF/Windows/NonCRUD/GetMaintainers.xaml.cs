using System.Windows;
using WD7UVN_HFT_2023241.Models;
using WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.Windows
{
    /// <summary>
    /// Interaction logic for GetAllEmployees.xaml
    /// </summary>
    public partial class GetMaintainers : Window
    {
        private readonly GetMaintainersViewModel viewModel;
        public GetMaintainers(Service e)
        {
            InitializeComponent();
            viewModel = new GetMaintainersViewModel(e);
            this.DataContext = viewModel;
        }
    }
}
