using POS_System.Screens.Admin.Transactions.DB_Operations;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Controls;
using Report = POS_System.Screens.Admin.Transactions.Report;

namespace POS_System.Screens.Admin.Transactions
{
    /// <summary>
    /// Interaction logic for Transactions.xaml
    /// </summary>
    public partial class Transactions : UserControl, IDisposable
    {
        private bool disposedValue;

        public Transactions()
        {
            InitializeComponent();
            DisplayData();
        }

        private void DisplayData()
        {
            Display dis = new Display();
            DataTable dt = dis.Display_query();
            grid_Transactions.ItemsSource = dt.DefaultView;
            dis.Dispose();
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
        // ~Transactions()
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

        private void Load_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            using(Filter_Search ft = new Filter_Search())
            {
                DataTable dt = ft.Filter_query(Date1.Text, Date2.Text);
                grid_Transactions.ItemsSource = dt.DefaultView;
            }
        }

        private void Print_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Report::Report_Trancactions obj = new Report.Report_Trancactions();
            _ = obj.ShowDialog();
        }

        private void Filter_Print_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Report::Report_Trancactions obj = new Report.Report_Trancactions();
            obj.Report2(Date1.Text, Date2.Text);
            _ = obj.ShowDialog();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string type = (e.AddedItems[0] as ComboBoxItem).Content as string;
                Filter_Search obj = new Filter_Search();
                grid_Transactions.ItemsSource = obj.DisplayTransactionByType(type).DefaultView;

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DisplayData();
        }
    }
}
