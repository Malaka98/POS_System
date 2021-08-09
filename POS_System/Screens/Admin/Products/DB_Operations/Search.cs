using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Screens.Admin.Products.DB_Operations
{
    internal class Search
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlDataAdapter adapt = null;

        public Search()
        {
            connectionOBJ = DBConnection.GetConnection();
        }

        public DataTable Search_Query(string sKey)
        {
            try
            {
                connectionOBJ.GetConn().Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select * from Product where Full_Name like '" + sKey + "%'", connectionOBJ.GetConn());
                _ = adapt.Fill(dt);
                return dt;
            }
            catch (SqlException e)
            {
                _ = MessageBox.Show(e.ToString());
                return null;
            }
            finally
            {
                adapt.Dispose();
                connectionOBJ.GetConn().Close();
            }

        }

    }
}
