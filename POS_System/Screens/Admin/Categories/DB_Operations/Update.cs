using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Screens.Admin.Categories.DB_Operations
{
    internal class Update : IDisposable
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlCommand cmd = null;
        private bool disposedValue;
        private readonly string Title;
        private readonly string description;
        private readonly int CatID;

        public Update(Category cObj)
        {
            connectionOBJ = DBConnection.GetConnection();
            Title = cObj.Title;
            description = cObj.Description;
            CatID = cObj.CatID;
        }

        public void Update_Query()
        {

            try
            {
                if (MessageBox.Show("Click YES to save the changes", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    connectionOBJ.GetConn().Open();
                    cmd = new SqlCommand("UPDATE Category SET title=@title, description=@description, added_date=@added_date, added_by=@added_by WHERE CatID=@CatID", connectionOBJ.GetConn());

                    _ = cmd.Parameters.AddWithValue("@title", Title);
                    _ = cmd.Parameters.AddWithValue("@description", description);
                    _ = cmd.Parameters.AddWithValue("@added_date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@CatID", CatID);
                    _ = cmd.Parameters.AddWithValue("@added_by", 0);

                    _ = cmd.ExecuteNonQuery();

                    _ = MessageBox.Show("Employee Added Succesfully");
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
        // ~Update()
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
