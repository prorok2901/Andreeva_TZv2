using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreeva_TZv2.Сompound
{
    internal class Connector
    {
        private static BD.DayAndNightEntities connector = new BD.DayAndNightEntities();

        private static BD.booking_history booking = new BD.booking_history();
        private static BD.borrow_room borrow = new BD.borrow_room();
        private static BD.user administrator = new BD.user();
        private static BD.blocking blocking = new BD.blocking();
        private static BD.client client = new BD.client();
        private static BD.info_room info_Room = new BD.info_room();


        public static BD.DayAndNightEntities DataBase()
        {
            return connector;
        }


        public static BD.user UserData()
        {
            return administrator;
        }

        public static BD.booking_history BookongData()
        {
            return booking;
        }

        public static BD.borrow_room BorrowData()
        {
            return borrow;
        }

        public static BD.info_room RoomData()
        {
            return info_Room;
        }

        public static BD.blocking BlockingData()
        {
            return blocking;
        }

        public static BD.client ClientData()
        {
            return client;
        }
    }
}
