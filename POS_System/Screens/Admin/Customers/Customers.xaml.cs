using POS_System.Screens.Admin.Customers.DB_Operactions;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Report = POS_System.Screens.Admin.Customers.Report;

namespace POS_System.Screens.Admin.Customers
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers : UserControl, IDisposable
    {
        private bool disposedValue;

        public Customers()
        {
            InitializeComponent();
            DisplayData();
        }

        private void DisplayData()
        {
            Display dis = new Display();
            DataTable dt = dis.Display_query();
            grid_Customers.ItemsSource = dt.DefaultView;
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
        // ~Customers()
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

        private void Print_Button_Click(object sender, RoutedEventArgs e)
        {
            Report::Customer_Report obj = new Report.Customer_Report();
            obj.Show();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = txtSearch.Text;
            if (keyword != null)
            {
                //Search the Dealer or Customer
                using (Search obj = new Search(keyword))
                {
                    DataTable dt = obj.Search_Query();
                    grid_Customers.ItemsSource = dt.DefaultView;
                }
            }
            else
            {
                //Show all the Dealer or Customer
                DisplayData();
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Customer newCus = new Customer()
            {
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Email = txtEmail.Text,
                Contact = txtMobile.Text,
                Address = txtAddress.Text,
                Added_date = DateTime.Now,
                Added_by = 0
        };
            using (Insert obj = new Insert(newCus))
            {
                obj.Insert_Query();
                DisplayData();

            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Customer newCus = new Customer()
            {
                DealCustID = int.Parse(txtID.Text),
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Email = txtEmail.Text,
                Contact = txtMobile.Text,
                Address = txtAddress.Text,
                Added_date = DateTime.Now,
                Added_by = 0
            };
            using (Insert obj = new Insert(newCus))
            {
                obj.Insert_Query();
                DisplayData();

            }
        }

        private void Grid_Customers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                txtID.Text = row_selected[0].ToString();
                txtName.Text = row_selected[1].ToString();
                txtSurname.Text = row_selected[2].ToString();
                txtEmail.Text = row_selected[3].ToString();
                txtMobile.Text = row_selected[4].ToString();
                txtAddress.Text = row_selected[5].ToString();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            using (Delete obj = new Delete(int.Parse(txtID.Text)))
            {
                obj.Insert_Query();
                DisplayData();

            }
        }
    }
}
