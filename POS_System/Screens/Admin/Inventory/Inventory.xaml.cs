using POS_System.Screens.Admin.Inventory.DB_Operations;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Controls;
using Report = POS_System.Screens.Admin.Inventory.Report;

namespace POS_System.Screens.Admin.Inventory
{
    /// <summary>
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class Inventory : UserControl, IDisposable
    {
        private bool disposedValue;

        public Inventory()
        {
            InitializeComponent();
            DisplayData();
        }

        private void DisplayData()
        {
            Display dis = new Display();
            DataTable dt = dis.Display_query();
            grid_Inventry.ItemsSource = dt.DefaultView;
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
        // ~Inventory()
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

        private void Print_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Report::Inventry_Report obj = new Report.Inventry_Report();
            obj.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string category = (e.AddedItems[0] as ComboBoxItem).Content as string;
                Search obj = new Search();
                grid_Inventry.ItemsSource = obj.Search_Query(category).DefaultView;

            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
