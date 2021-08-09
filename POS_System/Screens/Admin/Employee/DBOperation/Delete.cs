using System;
using System.Data.SqlClient;
using System.Windows;

namespace POS_System.Screens.Admin.Employee
{
    internal class Delete : IDisposable
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlCommand cmd = null;
        private bool disposedValue;

        public Delete()
        {
            connectionOBJ = DBConnection.GetConnection();
        }

        public void Delete_Query(int empId)
        {
            try
            {
                cmd = new SqlCommand("Delete Employee Where EmpID=@EmpID", connectionOBJ.GetConn());
                connectionOBJ.GetConn().Open();

                _ = cmd.Parameters.AddWithValue("@EmpID", empId);
                _ = cmd.ExecuteNonQuery();

                _ = MessageBox.Show("Employee Deleted Succesfully");
            }
            catch (SqlException e)
            {
                _ = MessageBox.Show(e.ToString());
            }
            finally
            {
                cmd.Dispose();
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
        // ~Delete()
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
