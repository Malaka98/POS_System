
namespace POS_System.Screens.Admin.Customers.Report
{
    partial class Customer_Report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Customer_DataSet = new POS_System.Screens.Admin.Customers.Report.Customer_DataSet();
            this.DealCustBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DealCustTableAdapter = new POS_System.Screens.Admin.Customers.Report.Customer_DataSetTableAdapters.DealCustTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Customer_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealCustBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Customer_DataSet";
            reportDataSource1.Value = this.DealCustBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS_System.Screens.Admin.Customers.Report.Customer_Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // Customer_DataSet
            // 
            this.Customer_DataSet.DataSetName = "Customer_DataSet";
            this.Customer_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DealCustBindingSource
            // 
            this.DealCustBindingSource.DataMember = "DealCust";
            this.DealCustBindingSource.DataSource = this.Customer_DataSet;
            // 
            // DealCustTableAdapter
            // 
            this.DealCustTableAdapter.ClearBeforeFill = true;
            // 
            // Customer_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Customer_Report";
            this.Text = "Customer_Report";
            this.Load += new System.EventHandler(this.Customer_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Customer_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealCustBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DealCustBindingSource;
        private Customer_DataSet Customer_DataSet;
        private Customer_DataSetTableAdapters.DealCustTableAdapter DealCustTableAdapter;
    }
}