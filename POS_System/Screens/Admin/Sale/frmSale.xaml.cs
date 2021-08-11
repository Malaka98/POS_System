using POS_System.Screens.Admin.Customers;
using POS_System.Screens.Admin.Products;
using POS_System.Screens.Admin.Sale.DB_Operations;
using getID = POS_System.Screens.Admin.Dealers.DB_Operations.Search;
using getpID = POS_System.Screens.Admin.Products.DB_Operations.Search;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WindowsInput;
using WindowsInput.Native;
using System.Transactions;

namespace POS_System.Screens.Admin.Sale
{
    /// <summary>
    /// Interaction logic for frmSale.xaml
    /// </summary>
    public partial class FrmSale : UserControl, IDisposable
    {
        private Control ActiveControl;
        private bool disposedValue;
        private string imgLoc = "laptop.png";
        private readonly DataTable transactionDT = new DataTable();

        private TransactionDAL transactionDAL = new TransactionDAL();


        public FrmSale()
        {
            InitializeComponent();
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
        // ~FrmSale()
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

        private void Card_Loaded(object sender, RoutedEventArgs e)
        {

            transactionDT.Columns.Add("Product Name");
            transactionDT.Columns.Add("Price");
            transactionDT.Columns.Add("Quantity");
            transactionDT.Columns.Add("Total");

            // tmrClock.Start();
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            lblDate.Text = DateTime.Now.ToLongDateString();
        }
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _ = Dispatcher.BeginInvoke(new Action(delegate ()
              {
                  lblTime.Text = DateTime.Now.ToString("T");
              }));
        }

        private void TxtDCSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            string sKey = txtDCSearch.Text;

            if (sKey == "")
            {
                txtDCName.Text = "";
                txtDCEmail.Text = "";
                txtDCMobile.Text = "";
                txtDCAddress.Text = "";
                txtSurname.Text = "";

                return;
            }

            using (Sale_C_Search obj = new Sale_C_Search(sKey))
            {
                Customer cus = obj.Search_query();
                txtDCName.Text = cus.Name;
                txtDCEmail.Text = cus.Email;
                txtDCMobile.Text = cus.Contact;
                txtDCAddress.Text = cus.Address;
                txtSurname.Text = cus.Surname;

            }
        }

        private void Btn_Nmb9_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _ = ActiveControl.Focus();
                InputSimulator sim = new InputSimulator();
                _ = sim.Keyboard.KeyPress(new VirtualKeyCode[] { VirtualKeyCode.VK_9 });
            }
            catch (Exception ex)
            {
                _ = System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Nmb8_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _ = ActiveControl.Focus();
                InputSimulator sim = new InputSimulator();
                _ = sim.Keyboard.KeyPress(new VirtualKeyCode[] { VirtualKeyCode.VK_8 });
            }
            catch (Exception ex)
            {
                _ = System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Nmb7_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _ = ActiveControl.Focus();
                InputSimulator sim = new InputSimulator();
                _ = sim.Keyboard.KeyPress(new VirtualKeyCode[] { VirtualKeyCode.VK_7 });
            }
            catch (Exception ex)
            {
                _ = System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Nmb6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _ = ActiveControl.Focus();
                InputSimulator sim = new InputSimulator();
                _ = sim.Keyboard.KeyPress(new VirtualKeyCode[] { VirtualKeyCode.VK_6 });
            }
            catch (Exception ex)
            {
                _ = System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Nmb4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _ = ActiveControl.Focus();
                InputSimulator sim = new InputSimulator();
                _ = sim.Keyboard.KeyPress(new VirtualKeyCode[] { VirtualKeyCode.VK_4 });
            }
            catch (Exception ex)
            {
                _ = System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Nmb3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _ = ActiveControl.Focus();
                InputSimulator sim = new InputSimulator();
                _ = sim.Keyboard.KeyPress(new VirtualKeyCode[] { VirtualKeyCode.VK_3 });
            }
            catch (Exception ex)
            {
                _ = System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Nmb2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _ = ActiveControl.Focus();
                InputSimulator sim = new InputSimulator();
                _ = sim.Keyboard.KeyPress(new VirtualKeyCode[] { VirtualKeyCode.VK_2 });
            }
            catch (Exception ex)
            {
                _ = System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Nmb1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _ = ActiveControl.Focus();
                InputSimulator sim = new InputSimulator();
                _ = sim.Keyboard.KeyPress(new VirtualKeyCode[] { VirtualKeyCode.VK_1 });
            }
            catch (Exception ex)
            {
                _ = System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Nmb5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _ = ActiveControl.Focus();
                InputSimulator sim = new InputSimulator();
                _ = sim.Keyboard.KeyPress(new VirtualKeyCode[] { VirtualKeyCode.VK_5 });
            }
            catch (Exception ex)
            {
                _ = System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Nmb10_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _ = ActiveControl.Focus();
                InputSimulator sim = new InputSimulator();
                _ = sim.Keyboard.KeyPress(new VirtualKeyCode[] { VirtualKeyCode.VK_0 });
            }
            catch (Exception ex)
            {
                _ = System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Nmb11_Click(object sender, RoutedEventArgs e)
        {
            //clear
        }

        private void Btn_Nmb0_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _ = ActiveControl.Focus();
                InputSimulator sim = new InputSimulator();
                _ = sim.Keyboard.KeyPress(new VirtualKeyCode[] { VirtualKeyCode.OEM_COMMA });
            }
            catch (Exception ex)
            {
                _ = System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_PreviewGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            ActiveControl = (Control)sender;
        }

        private void TxtPDSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string psKey = txtPDSearch.Text;

            try
            {
                if (psKey == "")
                {
                    txtPDName.Text = "";
                    txtPDInventory.Text = "";
                    txtPDPrice.Text = "";
                    txtPDQuantity.Text = "";

                    string pathhs = System.Windows.Forms.Application.StartupPath.Substring(0, System.Windows.Forms.Application.StartupPath.Length - 10);
                    string imagePath = pathhs + "\\Images\\Product\\laptop.png";
                    imgBox.ImageSource = new BitmapImage(new Uri(imagePath));
                    imgLoc = "laptop.png";
                    return;
                }

                using (Sale_P_Search obj = new Sale_P_Search(psKey))
                {
                    Product p = obj.Search_query();
                    txtPDName.Text = p.Full_Name;
                    txtPDInventory.Text = p.Quantity.ToString();
                    txtPDPrice.Text = p.Price.ToString();
                    imgLoc = p.Img;

                    string paths = System.Windows.Forms.Application.StartupPath.Substring(0, System.Windows.Forms.Application.StartupPath.Length - 10);
                    if (imgLoc != "laptop.png")
                    {
                        string imagePath = paths + "\\Images\\Product\\" + imgLoc;
                        imgBox.ImageSource = new BitmapImage(new Uri(imagePath));

                    }
                    else
                    {
                        string imagePath = paths + "\\Images\\Product\\laptop.png";
                        imgBox.ImageSource = new BitmapImage(new Uri(imagePath));
                    }
                }
            }catch(Exception ex)
            {
                _ = MessageBox.Show(ex.ToString());
            }
            
        }

        private void BtnADD_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Get Product Name, Rate and QTY customer wants to buy
                string productName = txtPDName.Text;
                decimal Rate = decimal.Parse(txtPDPrice.Text);
                decimal Qty = decimal.Parse(txtPDQuantity.Text);
                //string Img = imgLoc;
                decimal Total = Rate * Qty;//Total=Rate*Qty
                decimal subTotal = decimal.Parse(txtSubTotal.Text);
                subTotal += Total;

                if (productName == "")
                {
                    //Display error message
                    _ = MessageBox.Show("Select the product first.");
                }
                else
                {
                    //Add product to the data Grid View
                    transactionDT.Rows.Add(productName, Rate, Qty, Total);

                    //Show in Data Grid View
                    gridAddedProducts.ItemsSource = transactionDT.DefaultView;
                    //Sizing DataGridView Columns Width
                    gridAddedProducts.Columns[0].Width = 130;
                    gridAddedProducts.Columns[1].Width = 90;
                    gridAddedProducts.Columns[2].Width = 83;
                    gridAddedProducts.Columns[3].Width = 100;
                    //Display the subtotal in textbox
                    txtSubTotal.Text = subTotal.ToString();


                    //Clear the TextBoxes
                    txtPDSearch.Text = "";
                    txtPDName.Text = "";
                    txtPDInventory.Text = "0.00";
                    txtPDPrice.Text = "0.00";
                    txtPDQuantity.Text = "0";
                    string paths = System.Windows.Forms.Application.StartupPath.Substring(0, System.Windows.Forms.Application.StartupPath.Length - 10);

                    string imagePath = paths + "\\Images\\Product\\laptop.png";
                    imgBox.ImageSource = new BitmapImage(new Uri(imagePath));
                    imgLoc = "laptop.png";
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show("Error :- " + ex);
            }

        }

        private void TxtDiscount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                //Get the value from discount textbox
                string value = txtDiscount.Text;

                if (value == "")
                {
                    //Display Error Message
                    _ = MessageBox.Show("Please Add Discount First");
                }
                else
                {
                    //Get the discount in decimal value
                    decimal subTotal = decimal.Parse(txtSubTotal.Text);
                    decimal discount = decimal.Parse(txtDiscount.Text);

                    //Calculate the grandtotal based on discount
                    decimal grandTotal = ((100 - discount) / 100) * subTotal;

                    //Display the Grand Total in TextBox
                    txtGrandTotal.Text = grandTotal.ToString();
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }
        }

        private void TxtVAT_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                //Check if the grandTotal has value or not then calculate the discount first
                string check = txtGrandTotal.Text;
                if (check == "")
                {
                    //Display the error message to calculate discount
                    _ = MessageBox.Show("Calculate the discount and set the Grand Total First.");
                }
                else
                {
                    //Calculate VAT
                    //Getting the VAT Percent First
                    decimal previousGT = decimal.Parse(txtGrandTotal.Text);
                    decimal vat = decimal.Parse(txtVAT.Text);
                    decimal grandTotalWithVAT = ((100 + vat) / 100) * previousGT;

                    //Display new Grand Total with VAT
                    txtGrandTotal.Text = grandTotalWithVAT.ToString();
                }
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }
        }

        private void TxtPaidAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {

                //Get the paid amount and grand total
                decimal grandTotal = decimal.Parse(txtGrandTotal.Text);
                decimal paidAmount = decimal.Parse(txtPaidAmount.Text);
                decimal returnAmount = paidAmount - grandTotal;

                //Display the return amount

                if (paidAmount < grandTotal)
                {
                    txtPaidAmount.Foreground = new SolidColorBrush(Color.FromRgb(255, 106, 106));
                }
                else
                {

                    txtPaidAmount.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    txtReturnAmount.Text = returnAmount.ToString();
                }

            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }
        }

        private void BtnCheckout_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDCName.Text))
            {
                _ = MessageBox.Show("Plase enter Customer details");
            }
            else
            {
                Transaction transaction = new Transaction();
                getID dId = new getID();
                getpID getpID = new getpID();

                transaction.type = "Sale";
                transaction.DealCustID = dId.GetDealCustIDFromName(txtDCName.Text);
                transaction.grandTotal = Math.Round(decimal.Parse(txtGrandTotal.Text), 2);
                transaction.transaction_date = DateTime.Now;
                transaction.tax = decimal.Parse(txtVAT.Text);
                transaction.discount = decimal.Parse(txtDiscount.Text);

                bool success = false;

                using (TransactionScope tScope = new TransactionScope())
                {

                    bool t1 = transactionDAL.Insert_Transaction(transaction);

                    for (int i = 0; i < transactionDT.Rows.Count; i++)
                    {
                        TransDetails transDetails = new TransDetails();
                        string ProductName = transactionDT.Rows[i][0].ToString();

                        transDetails.ProdID = getpID.GetProductIDFromName(ProductName);
                        //transDetails.transno = lblTransNoUnit.Content.ToString();
                        transDetails.price = decimal.Parse(transactionDT.Rows[i][1].ToString());
                        transDetails.qty = decimal.Parse(transactionDT.Rows[i][2].ToString());
                        transDetails.total_price = Math.Round(decimal.Parse(transactionDT.Rows[i][3].ToString()), 2);
                        transDetails.type = "Sale";
                        transDetails.DealCustID = dId.GetDealCustIDFromName(txtDCName.Text);
                        transDetails.added_date = DateTime.Now;
                        string transactionType = lblTop.Text;
                    }
                }
            }

        }
    }
}
