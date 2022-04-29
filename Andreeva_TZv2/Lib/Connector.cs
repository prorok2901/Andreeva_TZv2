using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreeva_TZv2.Lib
{
    internal class Connector
    {
        private static BD.Administrator profile;
        private static BD.DayAndNightEntities connector;

        public Connector(BD.Administrator _profile)
        {
            _profile = profile;
        }

        public static BD.Administrator GetMyProfile()
        {
            return profile = new BD.Administrator();
        }

        public static BD.DayAndNightEntities GetModel()
        {
            return connector = new BD.DayAndNightEntities();
        }



    }
}
