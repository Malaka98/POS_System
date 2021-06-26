using System.Data.SqlClient;
using System.Configuration;
using System.Windows;

namespace POS_System
{
    internal class DBConnection
    {

        private static DBConnection obj = null;
        private readonly SqlConnection conn;
        
        private DBConnection() //DataBase Connection Singleton prevents the instantiation from any other class.
        {
            try
            {
                conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                //conn.Open();
                //MessageBox.Show("Database connected");
            }
            catch (SqlException e)
            {
                _ = MessageBox.Show(e.ToString());
            }
        }

        public static DBConnection GetConnection() //Saves memory because object is not created at each request. Only single instance is reused again and again.
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

        public SqlConnection GetConn()
        {
            return conn;
        }

    }
}
