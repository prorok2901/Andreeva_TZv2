using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            foreach (BD.Client r in andreeva_tz.Client.ToList())
            {
                LoginClient.Items.Add(r.Login);
            }
            foreach (BD.InfoRoom r in andreeva_tz.InfoRoom.ToList())
            {
                NumberRoom.Items.Add(r.NumberRoom);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(LoginClient.SelectedIndex > -1 && NumberRoom.SelectedIndex > -1 && DataOtbitiya.Text != null)
            {
                int i = int.Parse(NumberRoom.Text);
                BD.BorrowRoom borowwRoom = andreeva_tz.BorrowRoom.Where(a => a.InfoRoom.NumberRoom == i && a.Client == LoginClient.Text).FirstOrDefault();
                BD.BookingHistory bookingHistory = new BD.BookingHistory
                {
                    borrowRoom = borowwRoom.ID,

                    DepartureDate = DateTime.Parse(DataOtbitiya.Text)
                };

                if(Comment.Text != null) bookingHistory.Cause = Comment.Text;

                andreeva_tz.BookingHistory.Add(bookingHistory);
                andreeva_tz.SaveChanges();
            }
        }
    }
}
