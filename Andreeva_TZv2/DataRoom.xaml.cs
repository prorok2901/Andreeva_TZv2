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

        TextBox textBox;
        public DataRoom(TextBox box)
        {
            InitializeComponent();
            textBox = box;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button numberRoom;
            StackPanel stack = new StackPanel();

            int CoutRooms = 30;

            int number = 1;
            int Count = 1;

            for (int i = 0; i < CoutRooms; i++)
            {
                if (Count % 9 == 0)
                {
                    ListRoom.Children.Add(stack);
                    stack = new StackPanel();
                    Count = 1;
                }

                numberRoom = new Button
                {
                    Content = number,

                };
                numberRoom.Width = 20;
                numberRoom.Height = 20;
                numberRoom.Click += InformationRoom;

                stack.Children.Add(numberRoom);
                Count++;
                number++;
            }
            ListRoom.Children.Add(stack);
        }

        private void InformationRoom(object sender, RoutedEventArgs e)
        {
            int numberRoom = int.Parse((sender as Button).Content.ToString());
            infoRoom = new InformationRoom(numberRoom, textBox);
            InfoRoom.Navigate(infoRoom);

        }

        private void ComboBoxDATA()
        {
            for(int i = 1; i<=5; i++)
            {
                CountPeople.Items.Add(i);
            }
            //foreach (BD.Client r in andreeva_TZ.Client.ToList())
            //{
            //    loginClient.Items.Add(r.Login);
            //}

        }
    }
}
