using System.Windows;

namespace WD7UVN_SzTGUI_2023242.Client.WPF.Windows
{
    /// <summary>
    /// Interaction logic for GetAllEmployees.xaml
    /// </summary>
    public partial class GetAllEmployees : Window
    {
        public GetAllEmployees()
        {
            InitializeComponent();
        }

        private void CreateNewEmployee(object sender, RoutedEventArgs e)
        {
            Window window = new CreateNewEmployee();
            window.Show();
        }
    }
}
