using System;
using System.Windows.Forms;

namespace POS_System.Screens.Admin.Products.Report
{
    public partial class Product_Report : Form
    {
        public Product_Report()
        {
            InitializeComponent();
        }

        private void Product_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Product_DataSet.Product' table. You can move, or remove it, as needed.
            this.ProductTableAdapter.Fill(this.Product_DataSet.Product);

            this.reportViewer1.RefreshReport();
        }
    }
}
