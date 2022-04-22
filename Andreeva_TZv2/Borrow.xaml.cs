using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Andreeva_TZv2
{
    public partial class Borrow : Page
    {
        BD.Administrator admin;
        Registration registration;
        static DataRoom informationRoom;

        BD.DayAndNightEntities andreeva_TZ = new BD.DayAndNightEntities();

        public Borrow(BD.Administrator _admin)
        {
            InitializeComponent();
            ComboBoxLogin();
            admin = _admin;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(loginClient.SelectedIndex != -1 && CountDay.Text != null &&
                DataZaseleniya.Text != null)
            {
                if(CodePOD.Text == "123")
                {
                    BD.Client client = andreeva_TZ.Client.Where(a => a.Login == loginClient.Text).FirstOrDefault();

                    BD.BorrowRoom borrow = new BD.BorrowRoom
                    {
                        Room = int.Parse(NumberRoomHotel.Text),
                        CountDay = int.Parse(CountDay.Text),
                        Client = client.Login,
                        Administrotor = admin.login,
                        SettlementDate = DateTime.Parse(DataZaseleniya.Text),
                    };
                    andreeva_TZ.BorrowRoom.Add(borrow);
                    andreeva_TZ.SaveChanges();

                    MessageBox.Show("Успех!");
                }
                else
                {
                    MessageBox.Show("Неверный код подтверждения");
                }  
            }
            else
            {
                MessageBox.Show("Данные указаны не все");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int countDay = int.Parse(CountDay.Text);
                informationRoom = new DataRoom(NumberRoomHotel, countDay, PriceBox, DateTime.Parse(DataZaseleniya.Text));
                NavigationService.Navigate(informationRoom);
            }
            catch
            {
                MessageBox.Show("Вы не заполнили данные выше");
            }
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            registration = new Registration(loginClient);
            NavigationService.Navigate(registration);
        }
        private void ComboBoxLogin()
        {
            foreach (BD.Client r in andreeva_TZ.Client.ToList())
            {
                loginClient.Items.Add(r.Login);
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CountDay.Text == "")
            {
                CountDay.Text = "Кол-во дней:";
                CollorText(CountDay, false);
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CountDay.Text == "Кол-во дней:")
            {
                CollorText(CountDay, true);
            }
        }

        private void TextBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            if (DataZaseleniya.Text == "")
            {
                DataZaseleniya.Text = "Дата заселения";
                CollorText(DataZaseleniya, false);
            }
        }

        private void TextBox_GotFocus_1(object sender, RoutedEventArgs e)
        {
            if (DataZaseleniya.Text == "Дата заселения")
            {
                CollorText(DataZaseleniya, true);
            }
        }

        private void TextBox_GotFocus_2(object sender, RoutedEventArgs e)
        {
            if (CodePOD.Text == "Код подтверждения")
            {
                CollorText(CodePOD, true);
            }
        }

        private void TextBox_LostFocus_2(object sender, RoutedEventArgs e)
        {
            if (CodePOD.Text == "")
            {
                CodePOD.Text = "Код подтверждения";
                CollorText(CodePOD, false);
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
    }
}
