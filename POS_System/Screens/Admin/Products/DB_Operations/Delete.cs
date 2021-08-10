using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Screens.Admin.Products.DB_Operations
{
    internal class Delete
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlCommand cmd = null;

        public Delete()
        {
            connectionOBJ = DBConnection.GetConnection();
        }

        public void Delete_Query(int empId)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to Delete this record?  Click YES To Confirm", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cmd = new SqlCommand("DELETE FROM Product WHERE ProdID=@ProdID", connectionOBJ.GetConn());
                   
                    connectionOBJ.GetConn().Open();

                    _ = cmd.Parameters.AddWithValue("@ProdID", empId);
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
