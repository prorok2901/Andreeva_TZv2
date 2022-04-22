using System.Windows;

namespace Andreeva_TZv2
{
    /// <summary>
    /// Логика взаимодействия для Functional.xaml
    /// </summary>
    public partial class Functional : Window
    {
        BD.Administrator admin;
        static LiberationRoom liberationRoom = new LiberationRoom();
        static Borrow borrow;
        static MainWindow authorization = new MainWindow();

        public Functional(BD.Administrator _admin)
        {
            InitializeComponent();
            admin = _admin;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            borrow = new Borrow(admin);
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
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            FunctionFrame.Navigate(liberationRoom);
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
