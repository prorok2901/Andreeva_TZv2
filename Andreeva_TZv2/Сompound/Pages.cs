using System;
using System.Windows.Controls;

namespace Andreeva_TZv2.Сompound
{
    internal class Pages
    {
        private static AuthorizationUser authorizationUser = new AuthorizationUser();
        private static LiberationRoom liberationRoom = new LiberationRoom();

        private static Borrow borrow;
        private static Functional functional;
        private static DataRoom dataRoom;
        private static Registration registration;
        private static InformationRoom informationRoom;

        public static AuthorizationUser AuthorizationData()
        {
            return authorizationUser;
        }

        public static Borrow BorrowPage(BD.user _anmin)
        {
            borrow = new Borrow(_anmin);
            return borrow;
        }

        public static Functional FunctionalPage(BD.user _anmin)
        {
            functional = new Functional(_anmin);
            return functional;
        }

        public static LiberationRoom LiberationPage()
        {
            return liberationRoom;
        }

        public static DataRoom DataRoomsPage(TextBox _box, int _counDay, TextBox _priceBox, DateTime _data)
        {
            dataRoom = new DataRoom(_box, _counDay, _priceBox, _data);
            return dataRoom;
        }

        public static Registration RegistrationPage(ComboBox _login)
        {
            registration = new Registration(_login);
            return registration;
        }

        public static InformationRoom InformationRoomPage(int _numberRoom, TextBox _box, int _counDay, TextBox _priceBox)
        {
            informationRoom = new InformationRoom( _numberRoom, _box, _counDay, _priceBox);
            return informationRoom;
        }
    }
}
