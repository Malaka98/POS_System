using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Screens.Admin.Customers.DB_Operactions
{
    internal class Update
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlCommand cmd;
        private int DealCustID;
        private string Name;
        private string Surname;
        private string Email;
        private string Contact;
        private string Address;
        private DateTime Added_date;
        private int Added_by;

        public Update(Customer obj)
        {
            connectionOBJ = DBConnection.GetConnection();
            Name = obj.Name;
            DealCustID = obj.DealCustID;
            Surname = obj.Surname;
            Email = obj.Email;
            Contact = obj.Contact;
            Address = obj.Address;
            Added_by = 0;
            Added_date = DateTime.Now;
        }

        public void Insert_Query()
        {

            try
            {
                if (MessageBox.Show("Click YES to save the changes", "CONFIRM", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    connectionOBJ.GetConn().Open();
                    cmd = new SqlCommand("UPDATE DealCust SET name=@name, surname=@surname, email=@email, contact=@contact, address=@address, added_date=@added_date, added_by=@added_by WHERE DealCustID=@DealCustID", connectionOBJ.GetConn());

                    cmd.Parameters.AddWithValue("@name", Name);
                    cmd.Parameters.AddWithValue("@surname", Surname);
                    cmd.Parameters.AddWithValue("@email", Email);
                    cmd.Parameters.AddWithValue("@contact", Contact);
                    cmd.Parameters.AddWithValue("@address", Address);
                    cmd.Parameters.AddWithValue("@added_date", Added_date);
                    cmd.Parameters.AddWithValue("@added_by", Added_by);
                    cmd.Parameters.AddWithValue("@DealCustID", DealCustID);

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
    }
}
