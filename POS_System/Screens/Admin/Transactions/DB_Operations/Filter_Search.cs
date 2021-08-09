using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Screens.Admin.Transactions.DB_Operations
{
    internal class Filter_Search : IDisposable
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlCommand cmd = null;
        private SqlDataAdapter adapt = null;
        private bool disposedValue;
        private readonly string d1;
        private readonly string d2;

        public Filter_Search(string d1, string d2)
        {
            connectionOBJ = DBConnection.GetConnection();
            this.d1 = d1;
            this.d2 = d2;
        }

        public DataTable Filter_query()
        {
            try
            {
                connectionOBJ.GetConn().Open();
                DataTable dt = new DataTable();
                cmd = new SqlCommand("SELECT id [ID], type [Type], DealCustID, grandTotal [Grand Total], transaction_date [Transaction Time], tax [TAX], discount [Discount] FROM tblTransaction WHERE transaction_date between @Date1 and @Date2", connectionOBJ.GetConn());

                _ = cmd.Parameters.AddWithValue("@Date1", d1);
                _ = cmd.Parameters.AddWithValue("@Date2", d2);

                adapt = new SqlDataAdapter(cmd);

                _ = adapt.Fill(dt);
                return dt;

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
        // ~Filter_Search()
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
