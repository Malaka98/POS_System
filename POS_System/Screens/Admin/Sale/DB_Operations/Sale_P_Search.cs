using POS_System.Screens.Admin.Products;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Screens.Admin.Sale.DB_Operations
{
    internal class Sale_P_Search : IDisposable
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlDataAdapter adapt = null;
        private bool disposedValue;
        private bool disposedValue1;
        private readonly string psKey;

        public Sale_P_Search(string psKey)
        {
            connectionOBJ = DBConnection.GetConnection();
            this.psKey = psKey;
        }

        public Product Search_query()
        {
            Product p = new Product();
            try
            {
                connectionOBJ.GetConn().Open();
                DataTable dt = new DataTable();
                adapt = new SqlDataAdapter("SELECT Full_Name, Price, Quantity, Img FROM Product WHERE Barcode LIKE '%" + psKey + "%' OR PCode Like '%" + psKey + "%' OR Full_Name LIKE '%" + psKey + "%'", connectionOBJ.GetConn());
                _ = adapt.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    p.Full_Name = dt.Rows[0]["Full_Name"].ToString();
                    p.Price = decimal.Parse(dt.Rows[0]["Price"].ToString());
                    p.Quantity = int.Parse(dt.Rows[0]["Quantity"].ToString());
                    p.Img = dt.Rows[0]["Img"].ToString();
                }
                return p;
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
            if (!disposedValue1)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue1 = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~Sale_P_Search()
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
