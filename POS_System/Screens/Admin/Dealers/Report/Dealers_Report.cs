using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Screens.Admin.Dealers.Report
{
    public partial class Dealers_Report : Form
    {
        public Dealers_Report()
        {
            InitializeComponent();
        }

        private void Dealers_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'Dealers_DataSet.Dealers' table. You can move, or remove it, as needed.
            this.DealersTableAdapter.Fill(this.Dealers_DataSet.Dealers);

            this.reportViewer1.RefreshReport();
        }
    }
}
