using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Screens.Admin.Transactions.Report
{
    public partial class Report_Trancactions : Form
    {
        private readonly DBConnection connectionOBJ = null;
        private SqlDataAdapter adapt = null;
        private SqlCommand cmd = null;

        public Report_Trancactions()
        {
            InitializeComponent();
            connectionOBJ = DBConnection.GetConnection();
        }

        private void Report_Trancactions_Load(object sender, EventArgs e)
        {

            Report();
        }

        private void Report()
        {
            try
            {
                ReportDataSource rptDS;
                reportViewer1.LocalReport.ReportPath = @"C:\Users\rootx\Desktop\POS_System\POS_System\Screens\Admin\Transactions\Report\Trancactions_Report.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();

                connectionOBJ.GetConn().Open();
                cmd = new SqlCommand("SELECT id, type, DealCustID, grandTotal, transaction_date, tax, discount FROM tblTransaction", connectionOBJ.GetConn());
                adapt = new SqlDataAdapter(cmd);

                Transactions_DataSet ds = new Transactions_DataSet();
                _ = adapt.Fill(ds.Tables["dtTransaction"]);

                rptDS = new ReportDataSource("Transactions_DataSet", ds.Tables["dtTransaction"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                adapt.Dispose();
                connectionOBJ.GetConn().Close();
            }
        }
        
        public void Report2(string date1, string date2)
        {
            try
            {
                ReportDataSource rptDS;
                reportViewer1.LocalReport.ReportPath = @"C:\Users\rootx\Desktop\POS_System\POS_System\Screens\Admin\Transactions\Report\Trancactions_Report.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();

                connectionOBJ.GetConn().Open();
                cmd = new SqlCommand("SELECT id, type, DealCustID, grandTotal, transaction_date, tax, discount FROM tblTransaction WHERE transaction_date between @Date1 and @Date2", connectionOBJ.GetConn());

                _ = cmd.Parameters.AddWithValue("@Date1", date1);
                _ = cmd.Parameters.AddWithValue("@Date2", date2);

                adapt = new SqlDataAdapter(cmd);

                Transactions_DataSet ds = new Transactions_DataSet();
                _ = adapt.Fill(ds.Tables["dtTransaction"]);

                rptDS = new ReportDataSource("Transactions_DataSet", ds.Tables["dtTransaction"]);
                reportViewer1.LocalReport.DataSources.Add(rptDS);
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;

            }
            catch (Exception ex)
            {
                _ = MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
                adapt.Dispose();
                connectionOBJ.GetConn().Close();
            }
        }

    }
}
