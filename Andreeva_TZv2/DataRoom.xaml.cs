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
    /// Логика взаимодействия для DataRoom.xaml
    /// </summary>
    public partial class DataRoom : Page
    {
        private InformationRoom infoRoom;

        BD.DayAndNightEntities andreeva_TZ = new BD.DayAndNightEntities();

        DateTime enterDate;
        DateTime lastDate;
        TextBox textBox;
        int countDay;
        TextBox price;
        public DataRoom(TextBox box, int _countDay, TextBox _price, DateTime _enterDate)
        {
            InitializeComponent();
            textBox = box;
            countDay = _countDay;
            price = _price;
            enterDate = _enterDate;
            ComboBoxDATA();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListRoom.Items.Clear();
            int roomText = int.Parse(CountRoom.Text);
            int peopleText = int.Parse(CountPeople.Text);

            var infoRoom = andreeva_TZ.InfoRoom.Where(a =>
                a.TypeRoom == TypeRoom.Text &&
                a.CountRoom >= roomText &&
                a.Capacity >= peopleText).ToList();

            foreach (BD.InfoRoom room in infoRoom)
            {
                DateTime dateLast;
                lastDate = enterDate.AddDays(countDay);
                var roomList = andreeva_TZ.BorrowRoom.Where(a => a.Room == room.NumberRoom).ToList();

                foreach (var _room in roomList)
                {
                    dateLast = _room.SettlementDate.AddDays(_room.CountDay);

                    if ((enterDate >= _room.SettlementDate) && (enterDate <= dateLast))
                    {
                        Button numberRoom = new Button
                        {
                            Content = room.NumberRoom,

                        };
                        numberRoom.Width = 60;
                        numberRoom.Height = 20;
                        numberRoom.Click += InformationRoom;

                        ListRoom.Items.Add(numberRoom);
                    }

                }
            }
        }

        private void InformationRoom(object sender, RoutedEventArgs e)
        {
            int numberRoom = int.Parse((sender as Button).Content.ToString());
            infoRoom = new InformationRoom(numberRoom, textBox, countDay, price);
            InfoRoom.Navigate(infoRoom);

        }

        private void ComboBoxDATA()
        {
            for (int i = 1; i <= 5; i++)
            {
                CountPeople.Items.Add(i);
                CountRoom.Items.Add(i);
            }
            TypeRoom.Items.Add("Стандарт");
            TypeRoom.Items.Add("Люкс");
            TypeRoom.Items.Add("Апартаменты");
        }
    }
}
