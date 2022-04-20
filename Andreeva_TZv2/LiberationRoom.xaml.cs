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
                BD.BookingHistory client = new BD.BookingHistory
                {
                    borrowRoom = borowwRoom.ID,

                    DepartureDate = DateTime.Parse(DataOtbitiya.Text)//тут косяк
                };

                if(Comment.Text != null) client.Cause = Comment.Text;

                andreeva_tz.BookingHistory.Add(client);
                andreeva_tz.SaveChanges();
            }
        }
    }
}
