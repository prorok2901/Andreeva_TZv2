using Andreeva_TZv2.Сompound;
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
        private BD.user admin;

        public Borrow(BD.user _admin)
        {
            InitializeComponent();
            ComboBoxLogin();
            admin = _admin;
        }

        private void Button_Click(object _sender, RoutedEventArgs _e)
        {
            if(loginClient.SelectedIndex != -1 && CountDay.Text != null &&
                DataZaseleniya.Text != null)
            {
                if(CodePOD.Text == "123")
                {
                    BD.client client = Connector.DataBase().client.FirstOrDefault(a => a.email_Adress == loginClient.Text);

                    BD.borrow_room borrow = new BD.borrow_room
                    {
                        room = int.Parse(NumberRoomHotel.Text),
                        count_day = int.Parse(CountDay.Text),
                        client = client.email_Adress,
                        administrator = admin.id,
                        date_settlement = DateTime.Parse(DataZaseleniya.Text),
                    };
                    Connector.DataBase().borrow_room.Add(borrow);
                    Connector.DataBase().SaveChanges();

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

        private void Button_Click_1(object _sender, RoutedEventArgs _e)
        {
            try
            {
                int countDay = int.Parse(CountDay.Text);
                NavigationService.Navigate(Pages.DataRoomsPage(NumberRoomHotel, countDay, PriceBox, DateTime.Parse(DataZaseleniya.Text)));
            }
            catch
            {
                MessageBox.Show("Вы не заполнили данные выше");
            }
           
        }

        private void Button_Click_2(object _sender, RoutedEventArgs _e)
        {
            NavigationService.Navigate(Pages.RegistrationPage(loginClient));
        }
        private void ComboBoxLogin()
        {
            foreach (BD.client r in Connector.DataBase().client.ToList())
            {
                loginClient.Items.Add(r.email_Adress);
            }
        }

        private void TextBox_LostFocus(object _sender, RoutedEventArgs _e)
        {
            if (CountDay.Text == "")
            {
                CountDay.Text = "Кол-во дней:";
                CollorText(CountDay, false);
            }
        }

        private void TextBox_GotFocus(object _sender, RoutedEventArgs _e)
        {
            if (CountDay.Text == "Кол-во дней:")
            {
                CollorText(CountDay, true);
            }
        }

        private void TextBox_LostFocus_1(object _sender, RoutedEventArgs _e)
        {
            if (DataZaseleniya.Text == "")
            {
                DataZaseleniya.Text = "Дата заселения";
                CollorText(DataZaseleniya, false);
            }
        }

        private void TextBox_GotFocus_1(object _sender, RoutedEventArgs _e)
        {
            if (DataZaseleniya.Text == "Дата заселения")
            {
                CollorText(DataZaseleniya, true);
            }
        }

        private void TextBox_GotFocus_2(object _sender, RoutedEventArgs _e)
        {
            if (CodePOD.Text == "Код подтверждения")
            {
                CollorText(CodePOD, true);
            }
        }

        private void TextBox_LostFocus_2(object _sender, RoutedEventArgs _e)
        {
            if (CodePOD.Text == "")
            {
                CodePOD.Text = "Код подтверждения";
                CollorText(CodePOD, false);
            }
        }

        private void CollorText(TextBox _box, bool _proverka)
        {
            var bc = new BrushConverter();
            if (_proverka == true)
            {
                _box.Text = null;
                _box.Foreground = Brushes.Black;
            }
            else
            {
                _box.Foreground = (Brush)bc.ConvertFrom("#404142");
            }
        }
    }
}
