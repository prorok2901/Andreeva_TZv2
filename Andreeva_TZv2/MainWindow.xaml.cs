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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        static Functional _functional = new Functional();
        BD.DayAndNightEntities andreeva_TZ = new BD.DayAndNightEntities();

        static bool InKognito = true;


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
                    BD.Administrator basa = (BD.Administrator)andreeva_TZ.Administrator.Where(a => a.login == login && a.Password == password).FirstOrDefault();
                    if (basa != null)
                    {
                        if (_functional != null)
                        {
                            _functional.Show();
                        }
                        else
                        {
                            _functional.Activate();
                        }
                        Visibility = Visibility.Hidden;
                        Close();
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

        private void Inkognito_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (InKognito)
            {
                Inkognito.Source = BitmapFrame.Create(new Uri(@"C:\Users\student\Source\Repos\prorok2901\Andreeva_TZv2\Andreeva_TZv2\zamokOTK.png"));
                Password.Opacity = 1;
                MaskaPassword.Opacity = 0;
                Password.Text = MaskaPassword.Password;
                InKognito = false;
                MaskaPassword.IsEnabled = false;
            }
            else
            {
                Inkognito.Source = BitmapFrame.Create(new Uri(@"C:\Users\student\Source\Repos\prorok2901\Andreeva_TZv2\Andreeva_TZv2\zamokZAK.png"));
                Password.Opacity = 0;
                MaskaPassword.Opacity = 1;
                InKognito = true;
                MaskaPassword.IsEnabled = true;
            }


        }
        //Спектакль Джо - Портрет
    }
}

/*
 
use DayAndNight 
go
CREATE TABLE [Client] (
	Login varchar(32) NOT NULL,
	Name varchar(32) NOT NULL,
	PassportDetails varchar(10) NOT NULL,
  CONSTRAINT [PK_CLIENT] PRIMARY KEY CLUSTERED
  (
  [Login] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [Administrator] (
	login varchar(32) NOT NULL,
	Password varchar(16) NOT NULL,
	Name varchar(32) NOT NULL,
	Adres varchar(255),
  CONSTRAINT [PK_ADMINISTRATOR] PRIMARY KEY CLUSTERED
  (
  [login] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [InfoRoom] (
	NumberRoom integer NOT NULL,
	CountRoom integer NOT NULL,
	Capacity integer NOT NULL,
	TypeRoom varchar(10) NOT NULL,
	Price float(30) NOT NULL,
	RoomDescription float,
  CONSTRAINT [PK_INFOROOM] PRIMARY KEY CLUSTERED
  (
  [NumberRoom] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [BookingHistory] (
	borrowRoom integer NOT NULL,
	DepartureDate date NOT NULL,
	Comment varchar(255) Not null,
  CONSTRAINT [PK_BOOKINGHISTORY] PRIMARY KEY CLUSTERED
  (
  [borrowRoom] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO
CREATE TABLE [BorrowRoom] (
	ID integer NOT NULL,
	Room integer NOT NULL,
	Client varchar(32) NOT NULL,
	Administrotor varchar(32) NOT NULL,
	CountDay date NOT NULL,
	SettlementDate date NOT NULL,
  CONSTRAINT [PK_BORROWROOM] PRIMARY KEY CLUSTERED
  (
  [ID] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO



ALTER TABLE [BookingHistory] WITH CHECK ADD CONSTRAINT [BookingHistory_fk0] FOREIGN KEY ([borrowRoom]) REFERENCES [BorrowRoom]([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [BookingHistory] CHECK CONSTRAINT [BookingHistory_fk0]
GO

ALTER TABLE [BorrowRoom] WITH CHECK ADD CONSTRAINT [BorrowRoom_fk0] FOREIGN KEY ([Room]) REFERENCES [InfoRoom]([NumberRoom])
ON UPDATE CASCADE
GO
ALTER TABLE [BorrowRoom] CHECK CONSTRAINT [BorrowRoom_fk0]
GO
ALTER TABLE [BorrowRoom] WITH CHECK ADD CONSTRAINT [BorrowRoom_fk1] FOREIGN KEY ([Client]) REFERENCES [Client]([Login])
ON UPDATE CASCADE
GO
ALTER TABLE [BorrowRoom] CHECK CONSTRAINT [BorrowRoom_fk1]
GO
ALTER TABLE [BorrowRoom] WITH CHECK ADD CONSTRAINT [BorrowRoom_fk2] FOREIGN KEY ([Administrotor]) REFERENCES [Administrator]([login])
ON UPDATE CASCADE
GO
ALTER TABLE [BorrowRoom] CHECK CONSTRAINT [BorrowRoom_fk2]
GO*/
