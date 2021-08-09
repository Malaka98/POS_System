using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Screens.Admin.Customers.Report
{
    public partial class Customer_Report : Form
    {
        public Customer_Report()
        {
            InitializeComponent();
        }

        private void Customer_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Customer_DataSet.DealCust' table. You can move, or remove it, as needed.
            this.DealCustTableAdapter.Fill(this.Customer_DataSet.DealCust);

            this.reportViewer1.RefreshReport();
        }
    }
}
