using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace POS_System.Screens.Admin
{
    internal class Search : IDisposable
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlDataAdapter adapt = null;
        private bool disposedValue;

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
                adapt = new SqlDataAdapter("select * from Employee where Name like '" + sKey + "%'", connectionOBJ.GetConn());
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
