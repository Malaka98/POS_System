using System;
using System.Data.SqlClient;

namespace POS_System.Screens.Admin
{
    internal class GetDetails : IDisposable
    {
        private double dailysales;
        private double monthlysales;
        private double totalsales;
        private int productline;
        private int productstock;
        private int critical;

        private SqlCommand cm = null;
        private SqlConnection cn = null;
        private bool disposedValue;
        private readonly DBConnection connectionOBJ = null;
       

        public GetDetails()
        {
            connectionOBJ = DBConnection.GetConnection();
        }
        

        public double DailySales()
        {
            cn = connectionOBJ.GetConn();
            string transaction_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime dt = DateTime.Now;
            dt = dt.AddDays(-1);
            string s2 = dt.ToString("yyyy-MM-dd HH:mm:ss");

            cn.Open();
            cm = new SqlCommand("select isnull(sum(grandTotal), 0) as grandTotal from tblTransaction where transaction_date between '" + s2 + "' and '" + transaction_date + "' and type like 'Sale'", cn);
            dailysales = double.Parse(cm.ExecuteScalar().ToString());
            cm.Dispose();
            cn.Close();
            return dailysales;
        }


        public double MonthlySales()
        {
            cn = connectionOBJ.GetConn();
            string trans_date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime dtm = DateTime.Now;
            dtm = dtm.AddDays(-30);
            string st2 = dtm.ToString("yyyy-MM-dd HH:mm:ss");

            cn.Open();
            cm = new SqlCommand("select isnull(sum(grandTotal), 0) as grandTotal from tblTransaction where transaction_date between '" + st2 + "' and '" + trans_date + "' and type like 'Sale'", cn);
            monthlysales = double.Parse(cm.ExecuteScalar().ToString());
            cm.Dispose();
            cn.Close();
            return monthlysales;
        }

        public double TotalSales()
        {
            cn = connectionOBJ.GetConn();
            cn.Open();
            cm = new SqlCommand("select isnull(sum(grandTotal), 0) as grandTotal from tblTransaction where type like 'Sale'", cn);
            totalsales = double.Parse(cm.ExecuteScalar().ToString());
            cm.Dispose();
            cn.Close();
            return totalsales;
        }


        public double ProductLine()
        {
            cn = connectionOBJ.GetConn();
            cn.Open();
            cm = new SqlCommand("select count(*) from Product", cn);
            productline = int.Parse(cm.ExecuteScalar().ToString());
            cm.Dispose();
            cn.Close();
            return productline;
        }

        public double ProductStock()
        {
            cn = connectionOBJ.GetConn();
            cn.Open();
            cm = new SqlCommand("select isnull(sum(Quantity),0)  as Quantity from Product", cn);
            productstock = int.Parse(cm.ExecuteScalar().ToString());
            cm.Dispose();
            cn.Close();
            return productstock;
        }

        public double CriticalProduct()
        {
            cn = connectionOBJ.GetConn();
            cn.Open();
            cm = new SqlCommand("select count(*) from vwCriticalItems", cn);
            critical = int.Parse(cm.ExecuteScalar().ToString());
            cm.Dispose();
            cn.Close();
            return critical;
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
        // ~GetDetails()
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
