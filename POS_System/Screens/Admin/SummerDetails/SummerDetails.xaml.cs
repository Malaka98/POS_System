﻿using System;
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
            obj.Dispose();
        }

        public void MyDashboard()
        {
            lblUnit.Content = obj.DailySales().ToString("$#,##0.00");
            lblLastMonthUnit.Content = obj.MonthlySales().ToString("$#,##0.00");
            lblTotalSalesUnit.Content = obj.TotalSales().ToString("$#,##0.00");
            lblProductLineUnit.Content = obj.ProductLine().ToString("#,##0");
            lblProductStockUnit.Content = obj.ProductStock().ToString("#,##0");
            lblCriticalUnits.Content = obj.CriticalProduct().ToString("#,##0");

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
