using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Andreeva_TZv2
{
    /// <summary>
    /// Логика взаимодействия для Functional.xaml
    /// </summary>
    public partial class Functional : Window
    {
        static LiberationRoom liberationRoom = new LiberationRoom();
        static Borrow borrow = new Borrow();
        static MainWindow authorization = new MainWindow();

        public Functional()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FunctionFrame.Navigate(borrow);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (authorization != null)
            {
                authorization.Show();
            }
            else
            {
                authorization.Activate();
            }
            authorization.WindowHidder();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FunctionFrame.Navigate(liberationRoom);
        }
    }
}
