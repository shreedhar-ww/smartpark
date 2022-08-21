using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using SmartPark.Entity;

namespace SmartPark.Data
{
    public class DBAutoTopUp : DBHelper
    {
        public List<AutoTopUp> GetAutoTopUpList()
        {
            List<AutoTopUp> listAutoTopUp = new List<AutoTopUp>();
            AutoTopUp[] objAutoTopUp = new AutoTopUp[] { };
            objAutoTopUp[0].AutoTopUpId = 0;
            objAutoTopUp[0].AutoTopUpName = "ACTIVATE";      
            objAutoTopUp[1].AutoTopUpId = 1;
            objAutoTopUp[1].AutoTopUpName = "DEACTIVATE";
            listAutoTopUp.Add(objAutoTopUp[0]);
            listAutoTopUp.Add(objAutoTopUp[1]);
            return listAutoTopUp;
        }
    }
}
