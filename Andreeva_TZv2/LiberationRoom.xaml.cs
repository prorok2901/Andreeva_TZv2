using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Andreeva_TZv2
{
    /// <summary>
    /// Логика взаимодействия для LiberationRoom.xaml
    /// </summary>
    public partial class LiberationRoom : Page
    {
        BD.DayAndNightEntities andreeva_tz = new BD.DayAndNightEntities();
        public LiberationRoom()
        {
            InitializeComponent();
            UpdateComboBox();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(LoginClient.SelectedIndex > -1 && NumberRoom.SelectedIndex > -1 && DataOtbitiya.Text != null)
            {
                if(CodePOD.Text == "123")
                {
                    int i = int.Parse(NumberRoom.Text);
                    BD.borrow_room borowwRoom = andreeva_tz.borrow_room.Where(a => a.info_room.num_room == i && a.client == LoginClient.Text).FirstOrDefault();

                    DateTime date = DateTime.Parse(DataOtbitiya.Text);

                    if (borowwRoom.date_settlement <= date && date < borowwRoom.date_settlement.AddDays(borowwRoom.count_day))
                    {
                        BD.booking_history bookingHistory = new BD.booking_history
                        {
                            borrow_room = borowwRoom.id,

                            date_departure = date
                        };

                        andreeva_tz.borrow_room.Remove(borowwRoom);

                        if (Comment.Text != null) bookingHistory.cause = Comment.Text;

                        andreeva_tz.booking_history.Add(bookingHistory);
                        andreeva_tz.SaveChanges();

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

        private void DataOtbitiya_GotFocus(object sender, RoutedEventArgs e)
        {
            if (DataOtbitiya.Text == "Дата отбытия:")
            {
                CollorText(DataOtbitiya, true);
            }
        }

        private void DataOtbitiya_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DataOtbitiya.Text == "")
            {
                DataOtbitiya.Text = "Дата отбытия:";
                CollorText(DataOtbitiya, false);
            }
        }

        private void CodePOD_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CodePOD.Text == "")
            {
                CodePOD.Text = "Код подтверждения";
                CollorText(CodePOD, false);
            }
        }

        private void CodePOD_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CodePOD.Text == "Код подтверждения")
            {
                CollorText(CodePOD, true);
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

        private void UpdateComboBox()
        {
            foreach (BD.client r in andreeva_tz.client.ToList())
            {
                LoginClient.Items.Add(r.phone);
            }
            foreach (BD.info_room r in andreeva_tz.info_room.ToList())
            {
                NumberRoom.Items.Add(r.num_room);
            }
        }

        private void LoginClient_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            UpdateComboBox();
        }

        private void NumberRoom_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            UpdateComboBox();
        }
    }
}
