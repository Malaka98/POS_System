using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS_System.Screens.Admin.Customers;

namespace POS_System.Screens.Admin.Sale.DB_Operations
{
    internal class Sale_C_Search : IDisposable
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlDataAdapter adapt = null;
        private bool disposedValue;
        private readonly string sKey;

        public Sale_C_Search(string sKey)
        {
            connectionOBJ = DBConnection.GetConnection();
            this.sKey = sKey;
        }

        public Customer Search_query()
        {
            Customer cus = new Customer();
            try
            {
                connectionOBJ.GetConn().Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("SELECT name [Name], surname [Surname], email [Email], contact [Contact], address [Address] from DealCust WHERE DealCustID LIKE '%" + sKey + "%' OR name LIKE '%" + sKey + "%' OR surname LIKE '%" + sKey + "%'", connectionOBJ.GetConn());
                _ = adapt.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    cus.Name = dt.Rows[0]["name"].ToString();
                    cus.Surname = dt.Rows[0]["Surname"].ToString();
                    cus.Email = dt.Rows[0]["email"].ToString();
                    cus.Contact = dt.Rows[0]["contact"].ToString();
                    cus.Address = dt.Rows[0]["address"].ToString();
                }
                return cus;
            }
            catch (SqlException e)
            {
                _ = MessageBox.Show(e.ToString());
                return null;
            }
            finally
            {
                adapt.Dispose();
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
        // ~Sale_C_Search()
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
