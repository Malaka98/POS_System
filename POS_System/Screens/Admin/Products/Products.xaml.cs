using POS_System.Screens.Admin.Products.DB_Operations;
using System;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Media.Imaging;
using Report = POS_System.Screens.Admin.Products.Report;

namespace POS_System.Screens.Admin.Products
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : UserControl, IDisposable
    {

        private string imgLoc = "laptop.png";
        private string sourcePath = null;
        private string destinationPath = null;
        private bool disposedValue;

        public Products()
        {
            InitializeComponent();
            DisplayData();
        }

        private void DisplayData()
        {
            Display dis = new Display();
            DataTable dt = dis.Display_query();
            grid_Product.ItemsSource = dt.DefaultView;
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
        // ~Products()
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
            Report::Product_Report obj = new Report::Product_Report();
            obj.Show();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search obj = new Search();
            grid_Product.ItemsSource = obj.Search_Query(txtSearch.Text).DefaultView; 
        }

        private void BtnSelect_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog open = new System.Windows.Forms.OpenFileDialog();

            open.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.PNG; *gifs;)|*.jpg; *.jpeg; *.png; *.PNG; *gifs";

            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (open.CheckFileExists)
                {
                    imgBox.ImageSource = new BitmapImage(new Uri(open.FileName));

                    string ext = System.IO.Path.GetExtension(open.FileName);

                    Random random = new Random();
                    int RandInt = random.Next(0, 1000);

                    imgLoc = "Prod" + RandInt + ext;

                    sourcePath = open.FileName;

                    string paths = System.Windows.Forms.Application.StartupPath.Substring(0, System.Windows.Forms.Application.StartupPath.Length - 10);

                    destinationPath = paths + "\\Images\\Product\\" + imgLoc;

                    //File.Copy(sourcePath, destinationPath);

                }
            }
        }

        private void BtnInsert_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Product pobj = null;
            try
            {
                pobj = new Product
                {
                    PCode = txtCode.Text,
                    Barcode = txtBarcode.Text,
                    Manufactor = txtManufactor.Text,
                    Model = txtModel.Text,
                    Full_Name = txtName.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    Category = cmbCategory.Text,
                    Description = txtDescription.Text,
                    Year = txtReleaseYear.Text,
                    Warranty = int.Parse(txtWarranty.Text),
                    Quantity = 0,
                    Dealer = cmbDealer.Text,
                    Img = imgLoc,
                    Added_time = DateTime.Now,
                    //Getting username of logged in user
                    //string loggedUsr = frmLogin.loggedIn;
                    //loginBLL usr = udal.GetIDFromUsername(loggedUsr);

                    Added_by = 0,
                    Reorder = int.Parse(txtReorder.Text)
            };

                Insert insertObj = new Insert(pobj);


                insertObj.Insert_Query();
                File.Copy(sourcePath, destinationPath);

                DisplayData();
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.ToString());
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Product pobj = null;
            try
            {
                pobj = new Product
                {
                    ProdID = int.Parse(txtCode.Text),
                    PCode = txtCode.Text,
                    Barcode = txtBarcode.Text,
                    Manufactor = txtManufactor.Text,
                    Model = txtModel.Text,
                    Full_Name = txtName.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    Category = cmbCategory.Text,
                    Description = txtDescription.Text,
                    Year = txtReleaseYear.Text,
                    Warranty = int.Parse(txtWarranty.Text),
                    Quantity = 0,
                    Dealer = cmbDealer.Text,
                    Img = imgLoc,
                    Added_time = DateTime.Now,
                    //Getting username of logged in user
                    //string loggedUsr = frmLogin.loggedIn;
                    //loginBLL usr = udal.GetIDFromUsername(loggedUsr);

                    Added_by = 0,
                    Reorder = int.Parse(txtReorder.Text)
                };

                Update updateObj = new Update(pobj);


                updateObj.Update_Query();
                //File.Copy(sourcePath, destinationPath);

                DisplayData();
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.ToString());
            }
        }

        private void Grid_Product_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid gd = (DataGrid)sender;
                DataRowView row_selected = gd.SelectedItem as DataRowView;
                if (row_selected != null)
                {
                    //txtProdID.Text = row_selected[0].ToString();
                    txtCode.Text = row_selected[0].ToString();
                    txtBarcode.Text = row_selected[1].ToString();
                    txtManufactor.Text = row_selected[2].ToString();
                    txtModel.Text = row_selected[4].ToString();
                    txtName.Text = row_selected[4].ToString();
                    txtPrice.Text = row_selected[5].ToString();
                    cmbCategory.Text = row_selected[7].ToString();
                    txtDescription.Text = row_selected[7].ToString();
                    txtReleaseYear.Text = row_selected[9].ToString();
                    txtWarranty.Text = row_selected[9].ToString();
                    txtQuantity.Text = row_selected[10].ToString();
                    cmbDealer.Text = row_selected[13].ToString();
                    txtReorder.Text = row_selected[11].ToString();
                    imgLoc = row_selected[13].ToString();

                    //Update the Value of Global Variable rowheaderImage
                    //rowHeaderImage = imgLoc;

                    string paths = System.Windows.Forms.Application.StartupPath.Substring(0, System.Windows.Forms.Application.StartupPath.Length - 10);
                    if (imgLoc != "computer.png")
                    {
                        string imagePath = paths + "\\Images\\Product\\" + imgLoc;
                        //MessageBox.Show(imagePath);
                        imgBox.ImageSource = new BitmapImage(new Uri(imagePath));

                    }
                    else
                    {
                        string imagePath = paths + "\\Images\\Product\\laptop.png";
                        imgBox.ImageSource = new BitmapImage(new Uri(imagePath));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
