using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace POS_System.Screens.Admin.Users.DB_Operation
{
    internal class Delete : IDisposable
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlCommand cmd = null;
        private bool disposedValue;
        private readonly int Uid;

        public Delete(User delUObj)
        {
            connectionOBJ = DBConnection.GetConnection();
            Uid = delUObj.UserID;
        }

        public void Delete_Query()
        {

            try
            {
                if (MessageBox.Show("Are you sure you want to delete this Record?  Click YES to confirm", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    connectionOBJ.GetConn().Open();
                    cmd = new SqlCommand("DELETE FROM Login WHERE UserID = @UserID", connectionOBJ.GetConn());

                    _ = cmd.Parameters.AddWithValue("@UserID", Uid);

                    _ = cmd.ExecuteNonQuery();

                    _ = MessageBox.Show("Employee Deleted Succesfully");
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
