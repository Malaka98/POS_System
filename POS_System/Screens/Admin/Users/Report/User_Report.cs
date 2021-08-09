using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Screens.Admin.Users.Report
{
    public partial class User_Report : Form
    {
        public User_Report()
        {
            InitializeComponent();
        }

        private void User_Report_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'User_Report_DataSet.Login' table. You can move, or remove it, as needed.
            this.LoginTableAdapter.Fill(this.User_Report_DataSet.Login);

            this.reportViewer1.RefreshReport();
        }
    }
}
