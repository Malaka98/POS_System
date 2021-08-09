
namespace POS_System.Screens.Admin.Dealers.Report
{
    partial class Dealers_Report
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
            this.Dealers_DataSet = new POS_System.Screens.Admin.Dealers.Report.Dealers_DataSet();
            this.DealersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DealersTableAdapter = new POS_System.Screens.Admin.Dealers.Report.Dealers_DataSetTableAdapters.DealersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Dealers_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Dealers_DataSet";
            reportDataSource1.Value = this.DealersBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS_System.Screens.Admin.Dealers.Report.Dealers_Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // Dealers_DataSet
            // 
            this.Dealers_DataSet.DataSetName = "Dealers_DataSet";
            this.Dealers_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DealersBindingSource
            // 
            this.DealersBindingSource.DataMember = "Dealers";
            this.DealersBindingSource.DataSource = this.Dealers_DataSet;
            // 
            // DealersTableAdapter
            // 
            this.DealersTableAdapter.ClearBeforeFill = true;
            // 
            // Dealers_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Dealers_Report";
            this.Text = "Dealers_Report";
            this.Load += new System.EventHandler(this.Dealers_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dealers_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DealersBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DealersBindingSource;
        private Dealers_DataSet Dealers_DataSet;
        private Dealers_DataSetTableAdapters.DealersTableAdapter DealersTableAdapter;
    }
}