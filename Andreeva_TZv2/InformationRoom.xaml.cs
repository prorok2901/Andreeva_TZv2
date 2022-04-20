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
    /// Логика взаимодействия для InformationRoom.xaml
    /// </summary>
    public partial class InformationRoom : Page
    {
        TextBox box;
        int numberRoom;
        BD.DayAndNightEntities andreeva_TZ = new BD.DayAndNightEntities();
        public InformationRoom(int _numberRoom, TextBox text)
        {
            InitializeComponent();
            numberRoom = _numberRoom;
            box = text;
            if (numberRoom != 0)
            {
                BD.InfoRoom basa = (BD.InfoRoom)andreeva_TZ.InfoRoom.Where(a => a.NumberRoom == numberRoom).FirstOrDefault();
                if (basa != null)
                {
                    CountRoom.Text = basa.CountRoom.ToString();
                    Price.Text = basa.Price.ToString();
                }
            }
            else
            {
                MessageBox.Show("dfjhskfhcgj");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            box.Text = (numberRoom).ToString(); 
            NavigationService.GoBack();
        }
    }
}
