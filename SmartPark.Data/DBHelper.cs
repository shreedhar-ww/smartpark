using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPark.Data
{
    public class DBHelper
    {
        public string connectionString { get; set; }

        public SqlConnection objConnection { get; set; }
        public SqlCommand objCommand { get; set; }
        public SqlDataReader objReader { get; set; }

        public DBHelper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["SmartParkConnectionString"].ConnectionString;
            objConnection = dbConection;
            objCommand = null;
            objReader = null;
        }

        private SqlConnection _dbSmartPark;
        public SqlConnection dbConection
        {
            get
            {
                if (_dbSmartPark == null)
                {
                    _dbSmartPark = new SqlConnection(connectionString);
                }
                return _dbSmartPark;
            }
        }

        public void OpenConnection()
        {
            this.objConnection = objConnection;
            if (objConnection.State != ConnectionState.Open)
                objConnection.Open();
        }
    }  
}
