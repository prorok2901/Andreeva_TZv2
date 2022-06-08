using Andreeva_TZv2.Сompound;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Andreeva_TZv2
{
    public partial class Functional : Page
    {
        private BD.user admin;

        public Functional(BD.user _admin)
        {
            InitializeComponent();
            admin = _admin;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FunctionFrame.Navigate(Pages.BorrowPage(admin));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.AuthorizationData());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FunctionFrame.Navigate(Pages.LiberationPage());
        }
    }
}
