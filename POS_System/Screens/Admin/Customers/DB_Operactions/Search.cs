using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Screens.Admin.Customers.DB_Operactions
{
    internal class Search : IDisposable
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlCommand cmd = null;
        private SqlDataAdapter adapt = null;
        private string sKey = null;
        private bool disposedValue;

        public Search(string sKey)
        {
            connectionOBJ = DBConnection.GetConnection();
            this.sKey = sKey;
        }

        public DataTable Search_Query()
        {
            DataTable dt = new DataTable();
            try
            {
                connectionOBJ.GetConn().Open();
                cmd = new SqlCommand("SELECT * FROM DealCust WHERE DealCustID LIKE '%" + sKey + "%'  OR name LIKE '%" + sKey + "%' OR surname LIKE '%" + sKey + "%'", connectionOBJ.GetConn());

                adapt = new SqlDataAdapter(cmd);
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
                cmd.Dispose();
                adapt.Dispose();
                connectionOBJ.GetConn().Close();
            }

        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Search()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
