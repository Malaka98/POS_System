using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Screens.Admin.Inventory.Report
{
    public partial class Inventry_Report : Form
    {
        public Inventry_Report()
        {
            InitializeComponent();
        }

        private void Inventry_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Inventory_DataSet.Product' table. You can move, or remove it, as needed.
            this.ProductTableAdapter.Fill(this.Inventory_DataSet.Product);

            this.reportViewer1.RefreshReport();
        }
    }
}
