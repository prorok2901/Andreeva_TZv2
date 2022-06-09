using Andreeva_TZv2.Сompound;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Andreeva_TZv2
{
    public partial class AuthorizationUser : Page
    {
        private BD.user admin;
        private BrushConverter bc = new BrushConverter();

        public AuthorizationUser()
        {
            InitializeComponent();
            Canvas.SetZIndex(MaskaPassword, -1);
        }

        private void Button_Click(object _sender, RoutedEventArgs _e)
        {
            if (Login.Text != null)
            {
                string login = Login.Text;

                if (MaskaPassword.Password != "")
                {
                    BD.user basa = Connector.DataBase().user.FirstOrDefault(a => a.login == login &&
                    a.password == MaskaPassword.Password
                    && a.role == "администратор");
                    if (basa != null)
                    {
                        admin = basa;
                        NavigationService.Navigate(Pages.FunctionalPage(admin));
                    }
                    else
                    {
                        Password.Text = "Введите пароль";
                        MaskaPassword.Password = "";
                        MessageBox.Show("Такого пользователя не существует");
                    }
                }
                else
                {
                    MessageBox.Show("Вы не ввели пароль");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Вы не ввели логин");
            }
        }


        private void Button_Click_1(object _sender, RoutedEventArgs _e)
        {
            Application.Current.MainWindow.Close();
        }


        private void Password_GotFocus(object _sender, RoutedEventArgs _e)
        {
            Canvas.SetZIndex(MaskaPassword, 1);
            MaskaPassword.Focus();
        }
        private void Password_LostFocus(object _sender, KeyboardFocusChangedEventArgs _e)
        {
            if(MaskaPassword.Password == "")
            {
                Canvas.SetZIndex(MaskaPassword, -1);
            }
            
        }


        private void Login_GotFocus(object _sender, RoutedEventArgs _e)
        {
            
            if (Login.Text == "Введите логин")
            {
                Login.Foreground = Brushes.Black;
            }
        }
        private void Login_LostFocus(object _sender, KeyboardFocusChangedEventArgs _e)
        {
            if (Login.Text == "")
            {
                Login.Foreground = (Brush)bc.ConvertFrom("#404142");
                Login.Text = "Введите логин";
            }
        }


        private void Inkognito_MouseEnter(object _sender, MouseEventArgs _e)
        {
            Inkognito.Source = new BitmapImage(new Uri("pack://application:,,,/Image/Open.png"));

            MaskaPassword.Opacity = 0;
            if (MaskaPassword.Password != "")
            {
                Password.Text = MaskaPassword.Password;
            }
            MaskaPassword.IsEnabled = false;
            
        }
        private void Inkognito_MouseLeave(object _sender, MouseEventArgs _e)
        {
            Inkognito.Source = BitmapFrame.Create(new Uri("pack://application:,,,/Image/Closed.png"));
            MaskaPassword.Opacity = 1;
            MaskaPassword.IsEnabled = true;
            if (MaskaPassword.Password == "")
            {
                Password.Text = "Введите пароль";
            }
        }
    }
}
