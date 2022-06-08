using Andreeva_TZv2.Сompound;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
namespace Andreeva_TZv2
{
    public partial class DataRoom : Page
    {
        private int countDay;

        private DateTime enterDate;
        private DateTime lastDate;

        private TextBox textBox;
        private TextBox price;

        public DataRoom(TextBox _box, int _countDay, TextBox _price, DateTime _enterDate)
        {
            InitializeComponent();
            textBox = _box;
            countDay = _countDay;
            price = _price;
            enterDate = _enterDate;
            ComboBoxDATA();
        }

        private void Button_Click(object _sender, RoutedEventArgs _e)
        {
            DateTime dateLast;
            ListRoom.Items.Clear();
            BD.borrow_room borrowRoom;


            foreach (BD.info_room room in Connector.DataBase().info_room)
            {
                lastDate = enterDate.AddDays(countDay);

                borrowRoom = Connector.DataBase().borrow_room.FirstOrDefault(a => a.room == room.num_room && room.status_room == "Рабоет");
                if (borrowRoom!=null)
                {
                    dateLast = borrowRoom.date_settlement.AddDays(borrowRoom.count_day);
                    if((!(borrowRoom.date_settlement < enterDate) && !(dateLast > enterDate)) || 
                        (!(borrowRoom.date_settlement < lastDate) && !(dateLast > lastDate)))
                    {
                       
                    }
                }
                else
                {
                    Proverka(room);
                }
            }
        }
        private void Proverka(BD.info_room _room)
        {
            if((TypeRoom.Text == _room.type_room) && (int.Parse(CountPeople.Text) >= _room.capacity) && (int.Parse(CountRoom.Text) == _room.count_room))
            {
                CreateButtonRoom(_room);
            }
        }

        private void CreateButtonRoom(BD.info_room _room)
        {
            Button numberRoom = new Button
            {
                Content = _room.num_room,

            };
            numberRoom.Width = 60;
            numberRoom.Height = 20;
            numberRoom.Click += InformationRoom;

            ListRoom.Items.Add(numberRoom);
        }

        private void InformationRoom(object _sender, RoutedEventArgs _e)
        {
            int numberRoom = int.Parse((_sender as Button).Content.ToString());
            InfoRoom.Navigate(Pages.InformationRoomPage(numberRoom, textBox, countDay, price));
        }

        private void ComboBoxDATA()
        {
            for (int i = 1; i <= 5; i++)
            {
                CountPeople.Items.Add(i);
                CountRoom.Items.Add(i);
            }
            TypeRoom.Items.Add("стандарт");
            TypeRoom.Items.Add("люкс");
            TypeRoom.Items.Add("апартаменты");
        }
    }
}
