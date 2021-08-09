
namespace POS_System.Screens.Admin.Users.Report
{
    partial class User_Report
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
            this.User_Report_DataSet = new POS_System.Screens.Admin.Users.Report.User_Report_DataSet();
            this.LoginBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LoginTableAdapter = new POS_System.Screens.Admin.Users.Report.User_Report_DataSetTableAdapters.LoginTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.User_Report_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.DocumentMapWidth = 39;
            reportDataSource1.Name = "User_DataSet";
            reportDataSource1.Value = this.LoginBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "POS_System.Screens.Admin.Users.Report.User_Report.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // User_Report_DataSet
            // 
            this.User_Report_DataSet.DataSetName = "User_Report_DataSet";
            this.User_Report_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // LoginBindingSource
            // 
            this.LoginBindingSource.DataMember = "Login";
            this.LoginBindingSource.DataSource = this.User_Report_DataSet;
            // 
            // LoginTableAdapter
            // 
            this.LoginTableAdapter.ClearBeforeFill = true;
            // 
            // User_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "User_Report";
            this.Text = "User_Report";
            this.Load += new System.EventHandler(this.User_Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.User_Report_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource LoginBindingSource;
        private User_Report_DataSet User_Report_DataSet;
        private User_Report_DataSetTableAdapters.LoginTableAdapter LoginTableAdapter;
    }
}