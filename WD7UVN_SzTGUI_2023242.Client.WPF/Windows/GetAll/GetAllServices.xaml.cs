using System.Windows;
using WD7UVN_SzTGUI_2023242.Client.WPF.ViewModels;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.Windows
{
    /// <summary>
    /// Interaction logic for GetAllServices.xaml
    /// </summary>
    public partial class GetAllServices : Window
    {
        public GetAllServices()
        {
            InitializeComponent();
        }

        private void CreateNewService(object sender, RoutedEventArgs e)
        {
            CreateNewServiceViewModel viewModel = new CreateNewServiceViewModel();
            viewModel.NewServiceCreated += (newService) =>
            {
                var getAllServicesViewModel = (GetAllServicesViewModel)DataContext;
                if (getAllServicesViewModel != null)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        getAllServicesViewModel.Services.Add(newService);
                    }); 
                }
            };
            Window window = new CreateNewService(viewModel);
            window.Show();
        }
    }
}
