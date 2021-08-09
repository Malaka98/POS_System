using POS_System.Screens.Admin.Categories.DB_Operations;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace POS_System.Screens.Admin.Categories
{
    /// <summary>
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class Categories : UserControl, IDisposable
    {
        private bool disposedValue;

        public Categories()
        {
            InitializeComponent();
            DisplayData();
        }

        private void DisplayData()
        {
            Display dis = new Display();
            DataTable dt = dis.Display_query();
            grid_Category.ItemsSource = dt.DefaultView;
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
        // ~Categories()
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

        private void Insert_BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Category cObj = new Category
            {
                Title = txtTitle.Text,
                Description = txtDescription.Text
            };
            using (Insert obj = new Insert(cObj))
            {
                obj.Insert_Query();
            }
            DisplayData();
        }

        private void Grid_Category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid gd = (DataGrid)sender;
            DataRowView row_selected = gd.SelectedItem as DataRowView;
            if (row_selected != null)
            {
                txtCatID.Text = row_selected[0].ToString();
                txtTitle.Text = row_selected[1].ToString();
                txtDescription.Text = row_selected[2].ToString();
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Category cObj = new Category
            {
                CatID = int.Parse(txtCatID.Text),
                Title = txtTitle.Text,
                Description = txtDescription.Text
            };
            using (Update obj = new Update(cObj))
            {
                obj.Update_Query();
            }
            DisplayData();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Category cObj = new Category
            {
                CatID = int.Parse(txtCatID.Text),
            };

            using (Delete obj = new Delete(cObj.CatID))
            {
                obj.Delete_Query();
            }
            DisplayData();
        }
    }
}
