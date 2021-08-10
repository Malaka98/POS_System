using POS_System.Screens.Admin.Dealers.DB_Operations;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Report = POS_System.Screens.Admin.Dealers.Report;

namespace POS_System.Screens.Admin.Dealers
{
    /// <summary>
    /// Interaction logic for Dealers.xaml
    /// </summary>
    public partial class Dealers : UserControl, IDisposable
    {
        private bool disposedValue;
        private Search sObj;

        public Dealers()
        {
            InitializeComponent();
            DisplayData();
        }

        private void DisplayData()
        {
            Display dis = new Display();
            DataTable dt = dis.Display_query();
            grid_Dealers.ItemsSource = dt.DefaultView;
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
        // ~Dealers()
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
            Report::Dealers_Report obj = new Report::Dealers_Report();
            obj.Show();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dealer newDealer = new Dealer()
                {
                    Name = txtName.Text,
                    Person = txtPerson.Text,
                    Email = txtEmail.Text,
                    Contact = txtMobile.Text,
                    Address = txtAddress.Text,
                    Added_date = DateTime.Now,
                    Added_by = MainWindow._uID,
                };

                Insert obj = new Insert();
                obj.Insert_Query(newDealer);

            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dealer uDealer = new Dealer()
                {
                    DealID = int.Parse(txtID.Text),
                    Name = txtName.Text,
                    Person = txtPerson.Text,
                    Email = txtEmail.Text,
                    Contact = txtMobile.Text,
                    Address = txtAddress.Text,
                    Added_date = DateTime.Now,
                    Added_by = MainWindow._uID,
                };

                Update obj = new Update();
                obj.Update_Query(uDealer);
                DisplayData();

            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                //Get the keyword from text box
                string keyword = txtSearch.Text;

                if (keyword != null)
                {
                    //Search the Dealer
                    DataTable dt = sObj.Search_Query(keyword);
                    grid_Dealers.ItemsSource = dt.DefaultView;
                }
                else
                {
                    DisplayData();
                }
            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            sObj = new Search();
        }

        private void Grid_Dealers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                txtID.Text = row_selected[0].ToString();
                txtName.Text = row_selected[1].ToString();
                txtPerson.Text = row_selected[2].ToString();
                txtEmail.Text = row_selected[3].ToString();
                txtMobile.Text = row_selected[4].ToString();
                txtAddress.Text = row_selected[5].ToString();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Delete obj = new Delete();
                obj.Delete_Query(int.Parse(txtID.Text));
                DisplayData();
            }catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
