
namespace POS_System.Screens.Admin.Inventory.Report
{
    partial class Inventry_Report
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
            this.Inventory_DataSet = new POS_System.Screens.Admin.Inventory.Report.Inventory_DataSet();
            this.ProductBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProductTableAdapter = new POS_System.Screens.Admin.Inventory.Report.Inventory_DataSetTableAdapters.ProductTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Inventory_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Inventry_DataSet";
            reportDataSource1.Value = this.ProductBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS_System.Screens.Admin.Inventory.Report.Inventry_Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // Inventory_DataSet
            // 
            this.Inventory_DataSet.DataSetName = "Inventory_DataSet";
            this.Inventory_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ProductBindingSource
            // 
            this.ProductBindingSource.DataMember = "Product";
            this.ProductBindingSource.DataSource = this.Inventory_DataSet;
            // 
            // ProductTableAdapter
            // 
            this.ProductTableAdapter.ClearBeforeFill = true;
            // 
            // Inventry_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Inventry_Report";
            this.Text = "Inventry_Report";
            this.Load += new System.EventHandler(this.Inventry_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Inventory_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ProductBindingSource;
        private Inventory_DataSet Inventory_DataSet;
        private Inventory_DataSetTableAdapters.ProductTableAdapter ProductTableAdapter;
    }
}