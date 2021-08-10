using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POS_System.Screens.Admin.Dealers.DB_Operations
{
    internal class Insert
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlCommand cmd;
        private Dealer obj;

        public Insert()
        {
            connectionOBJ = DBConnection.GetConnection();
            
        }

        public void Insert_Query(Dealer obj)
        {
            this.obj = obj;
            try
            {
                connectionOBJ.GetConn().Open();
                cmd = new SqlCommand("INSERT INTO Dealers (name, person, email, contact, address, added_date, added_by) VALUES (@name, @person, @email, @contact, @address, @added_date, @added_by)", connectionOBJ.GetConn());

                _ = cmd.Parameters.AddWithValue("@name", obj.Name);
                _ = cmd.Parameters.AddWithValue("@person", obj.Person);
                _ = cmd.Parameters.AddWithValue("@email", obj.Email);
                _ = cmd.Parameters.AddWithValue("@contact", obj.Contact);
                _ = cmd.Parameters.AddWithValue("@address", obj.Address);
                _ = cmd.Parameters.AddWithValue("@added_date", obj.Added_date);
                _ = cmd.Parameters.AddWithValue("@added_by", obj.Added_by);

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

    }
}
