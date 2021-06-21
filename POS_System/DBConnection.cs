using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;

namespace POS_System
{
    class DBConnection
    {

        private static DBConnection obj = null;
        SqlConnection conn;
        
        private DBConnection() //DataBase Connection Singleton prevents the instantiation from any other class.
        {
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();
                //MessageBox.Show("Database connected");
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public static DBConnection getConnection() //Saves memory because object is not created at each request. Only single instance is reused again and again.
        {
            if(obj == null)
            {
                lock(new object())
                {
                    if(obj == null)
                    {
                        obj = new DBConnection(); //instance will be created at request time
                    }
                }
            }

            return obj;
        }

    }
}
