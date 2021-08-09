using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Screens.Admin.Customers.DB_Operactions
{
    internal class Insert : IDisposable
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlCommand cmd;
        //private int DealCustID;
        private string Name;
        private string Surname;
        private string Email;
        private string Contact;
        private string Address;
        private DateTime Added_date;
        private int Added_by;
        private bool disposedValue;

        public Insert(Customer obj)
        {
            connectionOBJ = DBConnection.GetConnection();
            Name = obj.Name;
            //DealCustID = obj.DealCustID;
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
                connectionOBJ.GetConn().Open();
                cmd = new SqlCommand("INSERT INTO DealCust (name, surname, email, contact, address, added_date, added_by) VALUES (@name, @surname, @email, @contact, @address, @added_date, @added_by)", connectionOBJ.GetConn());

                cmd.Parameters.AddWithValue("@name", Name);
                cmd.Parameters.AddWithValue("@surname", Surname);
                cmd.Parameters.AddWithValue("@email", Email);
                cmd.Parameters.AddWithValue("@contact", Contact);
                cmd.Parameters.AddWithValue("@address", Address);
                cmd.Parameters.AddWithValue("@added_date", Added_date);
                cmd.Parameters.AddWithValue("@added_by", Added_by);

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
