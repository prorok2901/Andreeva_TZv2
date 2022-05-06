using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
            DateTime dateLast;
            ListRoom.Items.Clear();
            BD.borrow_room borrowRoom;


            foreach (BD.info_room room in andreeva_TZ.info_room)
            {
                lastDate = enterDate.AddDays(countDay);

                borrowRoom = (BD.borrow_room)andreeva_TZ.borrow_room.Where(a => a.room == room.num_room).FirstOrDefault();
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
        private void Proverka(BD.info_room room)
        {
            if((TypeRoom.Text == room.type_room) && (int.Parse(CountPeople.Text) >= room.capacity) && (int.Parse(CountRoom.Text) == room.count_room))
            {
                CreateButtonRoom(room);
            }
        }

        private void CreateButtonRoom(BD.info_room room)
        {
            Button numberRoom = new Button
            {
                Content = room.num_room,

            };
            numberRoom.Width = 60;
            numberRoom.Height = 20;
            numberRoom.Click += InformationRoom;

            ListRoom.Items.Add(numberRoom);
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
            TypeRoom.Items.Add("стандарт");
            TypeRoom.Items.Add("люкс");
            TypeRoom.Items.Add("апартаменты");
        }
    }
}
