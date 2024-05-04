using System.Windows;
using WD7UVN_HFT_2023241.Models;
using WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.Windows
{
    public partial class GetResponsibleEmployee : Window
    {
        private readonly GetResponsibleEmployeeViewModel viewModel;
        public GetResponsibleEmployee(Service s)
        {
            InitializeComponent();
            viewModel = new GetResponsibleEmployeeViewModel(s);
            this.DataContext = viewModel;
        }
    }
}
