﻿using System;
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
    /// Логика взаимодействия для Borrow.xaml
    /// </summary>
    public partial class Borrow : Page
    {
        Registration registration;
        static DataRoom informationRoom;

        BD.DayAndNightEntities andreeva_TZ = new BD.DayAndNightEntities();

        public Borrow()
        {
            InitializeComponent();
            ComboBoxLogin();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int countDay = int.Parse(CountDay.Text);
                informationRoom = new DataRoom(NumberRoomHotel, countDay, PriceBox, DateTime.Parse(DataZaseleniya.Text));
                NavigationService.Navigate(informationRoom);
            }
            catch
            {
                MessageBox.Show("Вы не заполнили данные выше");
            }
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            registration = new Registration(loginClient);
            NavigationService.Navigate(registration);
        }
        private void ComboBoxLogin()
        {
            foreach (BD.Client r in andreeva_TZ.Client.ToList())
            {
                loginClient.Items.Add(r.Login);
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (CountDay.Text == "")
            {
                CountDay.Text = "Кол-во дней:";
                CollorText(CountDay, false);
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CountDay.Text == "Кол-во дней:")
            {
                CollorText(CountDay, true);
            }
        }

        private void TextBox_LostFocus_1(object sender, RoutedEventArgs e)
        {
            if (DataZaseleniya.Text == "")
            {
                DataZaseleniya.Text = "Дата заселения";
                CollorText(DataZaseleniya, false);
            }
        }

        private void TextBox_GotFocus_1(object sender, RoutedEventArgs e)
        {
            if (DataZaseleniya.Text == "Дата заселения")
            {
                CollorText(DataZaseleniya, true);
            }
        }

        private void TextBox_GotFocus_2(object sender, RoutedEventArgs e)
        {
            if (CodePOD.Text == "Код подтверждения")
            {
                CollorText(CodePOD, true);
            }
        }

        private void TextBox_LostFocus_2(object sender, RoutedEventArgs e)
        {
            if (CodePOD.Text == "")
            {
                CodePOD.Text = "Код подтверждения";
                CollorText(CodePOD, false);
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
    }
}
