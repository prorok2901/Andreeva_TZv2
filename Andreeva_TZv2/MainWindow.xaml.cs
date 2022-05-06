using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

// e6bf79 a98434 FFC373 F5DEB3

namespace Andreeva_TZv2
{
    /*
    Необходимо создать программу для отеля «День и ночь». 

    Программа будет использоваться на ресепшне администратором для оформления гостями номеров отеля.

    После запуска происходит авторизация. Ввод логина и пароля. Приложение предоставляет возможность просмотра: Данных гостей.
    В базе должны храниться: ФИО, номер телефона;

    Информации о номерах. Вместимость, количество комнат, тип номера (стандарт, люкс, апартамент), описание номера, цена.
    Должен быть способ фильтрации вывода номеров (свободные и занятые в определенный промежуток времени);

    История бронирования. Хранятся нынешние и старые бронирования (Информация о номере и клиенте, дата въезда и выезда).

    Возможность регистрировать номер. Вводится информация о клиенте, выбор номера (при выборе номера автоматически подставляется цена), 
    количество человек, дата и время въезда и выезда (после ввода даты выезда итоговая стоимость так же заполняется автоматически).
    Должна быть проверка, невозможно выбрать номер для регистрации в дни, когда номер уже забронирован.
    Когда проходит дата выезда номер приобретает статус «свободен». 
    Предусмотреть вариант, что гости захотят выехать раньше бронированного времени (создать такую кнопочку). 

    */
    public partial class MainWindow : Window
    {
        static Functional _functional;
        BD.DayAndNightEntities andreeva_TZ = new BD.DayAndNightEntities();

        static bool InKognito = true;

        BD.user admin;

        public MainWindow()
        {
            InitializeComponent();
            FillDAtaBase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Login.Text != null)
            {
                string login = Login.Text;

                if (Password.Text != null || Password.Text != "Введите пароль")
                {
                    Password.Text = MaskaPassword.Password;
                    string password = Password.Text;
                    BD.user basa = (BD.user)andreeva_TZ.user.Where(a => a.login == login && a.password == password && a.role == "администратор").FirstOrDefault();
                    if (basa != null)
                    {
                        admin = basa;
                        _functional = new Functional(admin);
                        if (_functional != null)
                        {
                            _functional.Show();
                        }
                        else
                        {
                            _functional.Activate();
                        }
                        Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        Password.Text = "Введите пароль";
                        MaskaPassword.Password = "";
                        MessageBox.Show("Косяк" + password);
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

        public void WindowHidder()
        {
            _functional.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FillDAtaBase()
        {

        }

        private void Password_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Password.Text == "Введите пароль")
            {
                CollorText(Password, true);
            }
        }
        private void Password_LostFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (MaskaPassword.Password == "")
            {
                Password.Text = "Введите пароль";
                CollorText(Password, false);
                Password.Opacity = 1;
                MaskaPassword.Opacity = 0;
            }

        }
        private void Login_GotFocus(object sender, RoutedEventArgs e)
        {

            if (Login.Text == "Введите логин")
            {
                CollorText(Login, true);
            }
        }

        private void Login_LostFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (Login.Text == "")
            {
                Login.Text = "Введите логин";
                CollorText(Login, false);
            }
        }
        private void CollorText(TextBox box, bool proverka)
        {
            var bc = new BrushConverter();
            if (proverka == true)
            {
                box.Text = null;
                box.Foreground = Brushes.Black;
            }
            else
            {
                box.Foreground = (Brush)bc.ConvertFrom("#404142");
            }
        }
        //добавить таблицу статус юзера

        private void Inkognito_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (InKognito)
            {
                Inkognito.Source = BitmapFrame.Create(new Uri(@"C:\Users\proro\Source\Repos\prorok2901\Andreeva_TZv2\Andreeva_TZv2\zamokOTK.png"));
                Password.Opacity = 1;
                MaskaPassword.Opacity = 0;
                Password.Text = MaskaPassword.Password;
                InKognito = false;
                MaskaPassword.IsEnabled = false;
            }
            else
            {
                Inkognito.Source = BitmapFrame.Create(new Uri(@"C:\Users\proro\Source\Repos\prorok2901\Andreeva_TZv2\Andreeva_TZv2\zamokZAK.png"));
                Password.Opacity = 0;
                MaskaPassword.Opacity = 1;
                InKognito = true;
                MaskaPassword.IsEnabled = true;
            }


        }
        //Спектакль Джо - Портрет
    }
}
