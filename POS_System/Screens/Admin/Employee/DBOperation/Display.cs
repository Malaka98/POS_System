using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace POS_System.Screens.Admin.Employee
{
    internal class Display : IDisposable
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlDataAdapter adapt = null;
        private bool disposedValue;

        public Display()
        {
            connectionOBJ = DBConnection.GetConnection();
        }


        public DataTable Display_query()
        {
            try
            {
                connectionOBJ.GetConn().Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("select EmpID, Name, Surname, ID, SEX [Gender], Birth_Date, Age, Address, Mobile, DateOfReciving [Reciving Date], Sallary, added_date [Added Time] from Employee", connectionOBJ.GetConn());
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
        // ~Display()
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
