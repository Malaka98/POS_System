using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Screens.Admin.Dealers.DB_Operations
{
    internal class Delete
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlCommand cmd = null;

        public Delete()
        {
            connectionOBJ = DBConnection.GetConnection();
        }

        public void Delete_Query(int dId)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this Record?  Click YES to confirm", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    cmd = new SqlCommand("DELETE FROM Dealers WHERE DealID=@DealID", connectionOBJ.GetConn());
                    connectionOBJ.GetConn().Open();

                    _ = cmd.Parameters.AddWithValue("@DealID", dId);
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

    }
}
