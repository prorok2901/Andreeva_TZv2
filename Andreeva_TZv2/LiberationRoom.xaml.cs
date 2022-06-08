using Andreeva_TZv2.Сompound;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Andreeva_TZv2
{
    public partial class LiberationRoom : Page
    {
        public LiberationRoom()
        {
            InitializeComponent();
            UpdateComboBox();
        }

        private void Button_Click(object _sender, RoutedEventArgs _e)
        {
            if(LoginClient.SelectedIndex > -1 && NumberRoom.SelectedIndex > -1 && DataOtbitiya.Text != null)
            {
                if(CodePOD.Text == "123")
                {
                    int i = int.Parse(NumberRoom.Text);
                    BD.borrow_room borowwRoom = Connector.DataBase().borrow_room.Where(a => a.info_room.num_room == i && a.client == LoginClient.Text).FirstOrDefault();

                    DateTime date = DateTime.Parse(DataOtbitiya.Text);

                    if (borowwRoom.date_settlement <= date && date < borowwRoom.date_settlement.AddDays(borowwRoom.count_day))
                    {
                        BD.booking_history bookingHistory = new BD.booking_history
                        {
                            borrow_room = borowwRoom.id,

                            date_departure = date
                        };

                        Connector.DataBase().borrow_room.Remove(borowwRoom);

                        if (Comment.Text != null) bookingHistory.cause = Comment.Text;

                        Connector.DataBase().booking_history.Add(bookingHistory);
                        Connector.DataBase().SaveChanges();

                        NavigationService.GoBack();
                    }
                    else
                    {
                        MessageBox.Show("Вы указали день раньше чем прибыли в отель");
                    }
                }
                else
                {
                    MessageBox.Show("Нeверный код подтверждения");
                }
                
            }
        }

        private void DataOtbitiya_GotFocus(object _sender, RoutedEventArgs _e)
        {
            if (DataOtbitiya.Text == "Дата отбытия:")
            {
                CollorText(DataOtbitiya, true);
            }
        }
        private void DataOtbitiya_LostFocus(object _sender, RoutedEventArgs _e)
        {
            if (DataOtbitiya.Text == "")
            {
                DataOtbitiya.Text = "Дата отбытия:";
                CollorText(DataOtbitiya, false);
            }
        }

        private void CodePOD_LostFocus(object _sender, RoutedEventArgs _e)
        {
            if (CodePOD.Text == "")
            {
                CodePOD.Text = "Код подтверждения";
                CollorText(CodePOD, false);
            }
        }
        private void CodePOD_GotFocus(object _sender, RoutedEventArgs _e)
        {
            if (CodePOD.Text == "Код подтверждения")
            {
                CollorText(CodePOD, true);
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

        private void UpdateComboBox()
        {
            foreach (BD.client r in Connector.DataBase().client.ToList())
            {
                LoginClient.Items.Add(r.email_Adress);
            }
            foreach (BD.info_room r in Connector.DataBase().info_room.ToList())
            {
                NumberRoom.Items.Add(r.num_room);
            }
        }

        private void LoginClient_MouseEnter(object _sender, System.Windows.Input.MouseEventArgs _e)
        {
            UpdateComboBox();
        }

        private void NumberRoom_MouseEnter(object _sender, System.Windows.Input.MouseEventArgs _e)
        {
            UpdateComboBox();
        }
    }
}
