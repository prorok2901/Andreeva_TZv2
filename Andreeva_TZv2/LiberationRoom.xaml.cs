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
                    BD.BorrowRoom borowwRoom = andreeva_tz.BorrowRoom.Where(a => a.InfoRoom.NumberRoom == i && a.Client == LoginClient.Text).FirstOrDefault();

                    DateTime date = DateTime.Parse(DataOtbitiya.Text);

                    if (borowwRoom.SettlementDate <= date && date < borowwRoom.SettlementDate.AddDays(borowwRoom.CountDay))
                    {
                        BD.BookingHistory bookingHistory = new BD.BookingHistory
                        {
                            borrowRoom = borowwRoom.ID,

                            DepartureDate = date
                        };

                        andreeva_tz.BorrowRoom.Remove(borowwRoom);

                        if (Comment.Text != null) bookingHistory.Cause = Comment.Text;

                        andreeva_tz.BookingHistory.Add(bookingHistory);
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
            foreach (BD.Client r in andreeva_tz.Client.ToList())
            {
                LoginClient.Items.Add(r.Login);
            }
            foreach (BD.InfoRoom r in andreeva_tz.InfoRoom.ToList())
            {
                NumberRoom.Items.Add(r.NumberRoom);
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
