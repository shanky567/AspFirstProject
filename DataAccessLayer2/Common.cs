using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;



namespace DataAccessLayer2
{
    class Common
    {
        public static NextPage.DatabaseUtil.PetaPoco.Database Database
        {
            get { return new NextPage.DatabaseUtil.PetaPoco.Database(System.Configuration.ConfigurationManager.AppSettings["ConnectionStringName"]); }
        }

    }
}
