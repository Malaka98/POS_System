using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace POS_System.Screens.Admin
{
    /// <summary>
    /// Interaction logic for SummerDetails.xaml
    /// </summary>
    public partial class SummerDetails : UserControl, IDisposable
    {
        private readonly GetDetails obj;
        private bool disposedValue;

        public SummerDetails()
        {
            InitializeComponent();
            obj = new GetDetails();
            MyDashboard();
            ChartLoad();
            obj.Dispose();
        }

        public void MyDashboard()
        {
            lblUnit.Content = obj.DailySales().ToString("Rs#,##0.00");
            lblLastMonthUnit.Content = obj.MonthlySales().ToString("Rs#,##0.00");
            lblTotalSalesUnit.Content = obj.TotalSales().ToString("Rs#,##0.00");
            lblProductLineUnit.Content = obj.ProductLine().ToString("#,##0");
            lblProductStockUnit.Content = obj.ProductStock().ToString("#,##0");
            lblCriticalUnits.Content = obj.CriticalProduct().ToString("#,##0");

        }

        public void ChartLoad()
        {
            DBConnection connectionOBJ = DBConnection.GetConnection();

            PieChart1.InnerRadius = 30;
            PieChart1.LegendLocation = LegendLocation.Bottom;

            connectionOBJ.GetConn().Open();

            SqlCommand command = new SqlCommand("select Year(transaction_date) as year, isnull(sum(grandTotal),0.00) as grandTotal from tblTransaction where type like 'Sale' group by Year(transaction_date)", connectionOBJ.GetConn());
            SqlDataReader dr = command.ExecuteReader();

            PieChart1.Series = new SeriesCollection { };

            while (dr.Read())
            {
                PieChart1.Series.Add(
                    new PieSeries
                    {
                        Title = dr["year"].ToString(),
                        Values = new ChartValues<double> { Convert.ToDouble(dr["grandTotal"].ToString()) },
                        DataLabels = true
                    }
                );
            }
            command.Dispose();
            connectionOBJ.GetConn().Close();
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
        // ~SummerDetails()
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
