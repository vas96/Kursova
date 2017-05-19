namespace Building_Company
{
    partial class FormOfficeReport
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
            this.EMPLOYEESBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new Building_Company.DataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.EMPLOYEESTableAdapter = new Building_Company.DataSet1TableAdapters.EMPLOYEESTableAdapter();
            this.CUSTOMERSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CUSTOMERSTableAdapter = new Building_Company.DataSet1TableAdapters.CUSTOMERSTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.EMPLOYEESBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CUSTOMERSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // EMPLOYEESBindingSource
            // 
            this.EMPLOYEESBindingSource.DataMember = "EMPLOYEES";
            this.EMPLOYEESBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.EMPLOYEESBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Building_Company.Report4.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 63);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(742, 419);
            this.reportViewer1.TabIndex = 0;
            // 
            // EMPLOYEESTableAdapter
            // 
            this.EMPLOYEESTableAdapter.ClearBeforeFill = true;
            // 
            // CUSTOMERSBindingSource
            // 
            this.CUSTOMERSBindingSource.DataMember = "CUSTOMERS";
            this.CUSTOMERSBindingSource.DataSource = this.DataSet1;
            // 
            // CUSTOMERSTableAdapter
            // 
            this.CUSTOMERSTableAdapter.ClearBeforeFill = true;
            // 
            // FormOfficeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 482);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormOfficeReport";
            this.Text = "FormEmpReport";
            this.Load += new System.EventHandler(this.FormOfficeReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EMPLOYEESBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CUSTOMERSBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource EMPLOYEESBindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.EMPLOYEESTableAdapter EMPLOYEESTableAdapter;
        private System.Windows.Forms.BindingSource CUSTOMERSBindingSource;
        private DataSet1TableAdapters.CUSTOMERSTableAdapter CUSTOMERSTableAdapter;
    }
}