using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace POS_System.Screens.Admin.Customers.DB_Operactions
{
    internal class Delete : IDisposable
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlCommand cmd;
        private int DealCustID;
        private bool disposedValue;

        public Delete(int ID)
        {
            connectionOBJ = DBConnection.GetConnection();
            DealCustID = ID;
        }

        public void Insert_Query()
        {

            try
            {
                if (MessageBox.Show("Are you sure you want to Delete this record?  Click YES To Confirm", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    connectionOBJ.GetConn().Open();
                    cmd = new SqlCommand("DELETE FROM DealCust WHERE DealCustID=@DealCustID", connectionOBJ.GetConn());

                    _ = cmd.Parameters.AddWithValue("@DealCustID", DealCustID);
                    

                    _ = cmd.ExecuteNonQuery();

                    _ = MessageBox.Show("Employee Updated Succesfully");
                }
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
