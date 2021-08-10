using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Screens.Admin.Dealers.DB_Operations
{
    internal class Update
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlCommand cmd = null;

        public Update()
        {
            connectionOBJ = DBConnection.GetConnection();
           
        }

        public void Update_Query(Dealer dl)
        {
           
            try
            {
                if (MessageBox.Show("Click YES to save the changes", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    connectionOBJ.GetConn().Open();
                    cmd = new SqlCommand("UPDATE Dealers SET name = @name, person = @person, email = @email, contact = @contact, address = @address, added_date = @added_date, added_by = @added_by WHERE DealID = @DealID", connectionOBJ.GetConn());

                    cmd.Parameters.AddWithValue("@name", dl.Name);
                    cmd.Parameters.AddWithValue("@person", dl.Person);
                    cmd.Parameters.AddWithValue("@email", dl.Email);
                    cmd.Parameters.AddWithValue("@contact", dl.Contact);
                    cmd.Parameters.AddWithValue("@address", dl.Address);
                    cmd.Parameters.AddWithValue("@added_date", dl.Added_date);
                    cmd.Parameters.AddWithValue("@DealID", dl.DealID);
                    cmd.Parameters.AddWithValue("@added_by", dl.Added_by);

                    _ = cmd.ExecuteNonQuery();

                    _ = MessageBox.Show("Delear Added Succesfully");
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
