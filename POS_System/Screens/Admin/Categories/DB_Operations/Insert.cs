using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace POS_System.Screens.Admin.Categories.DB_Operations
{
    internal class Insert : IDisposable
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlCommand cmd = null;
        private bool disposedValue;
        private readonly string Title;
        private readonly string description;

        public Insert(Category cObj)
        {
            connectionOBJ = DBConnection.GetConnection();
            Title = cObj.Title;
            description = cObj.Description;
        }

        public void Insert_Query()
        {

            try
            {
                connectionOBJ.GetConn().Open();
                cmd = new SqlCommand("INSERT INTO Category (title, description, added_date, added_by) VALUES (@title, @description, @added_date, @added_by)", connectionOBJ.GetConn());

                _ = cmd.Parameters.AddWithValue("@title", Title);
                _ = cmd.Parameters.AddWithValue("@description", description);
                _ = cmd.Parameters.AddWithValue("@added_date", DateTime.Now);
                _ = cmd.Parameters.AddWithValue("@added_by", 0);

                _ = cmd.ExecuteNonQuery();

                _ = MessageBox.Show("Employee Added Succesfully");
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
        // ~Insert()
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
