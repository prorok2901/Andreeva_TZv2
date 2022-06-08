using Andreeva_TZv2.Сompound;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Andreeva_TZv2
{
    /// <summary>
    /// Логика взаимодействия для InformationRoom.xaml
    /// </summary>
    public partial class InformationRoom : Page
    {
        private int numberRoom;
        private int countDay;

        private TextBox box;
        private TextBox price;

        decimal priceRoom;
        public InformationRoom(int _numberRoom, TextBox _text, int _countDay, TextBox _price)
        {
            InitializeComponent();
            numberRoom = _numberRoom;
            box = _text;
            countDay = _countDay;
            price = _price;
            if (numberRoom != 0)
            {
                BD.info_room basa = Connector.DataBase().info_room.FirstOrDefault(a => a.num_room == numberRoom);
                if (basa != null)
                {
                    CountRoom.Text = basa.count_room.ToString();
                    priceRoom = basa.price;
                    Price.Text = basa.price.ToString();
                    Info.Text = basa.chort_description;
                }
            }
        }

        private void Button_Click(object _sender, RoutedEventArgs _e)
        {
            price.Text = (priceRoom * countDay).ToString();
            box.Text = (numberRoom).ToString();
            NavigationService.GoBack();
        }
    }
}
