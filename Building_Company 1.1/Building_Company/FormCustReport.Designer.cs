namespace Building_Company
{
    partial class FormCustReport
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
            this.SUPPLIERSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new Building_Company.DataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SUPPLIERSTableAdapter = new Building_Company.DataSet1TableAdapters.SUPPLIERSTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.SUPPLIERSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // SUPPLIERSBindingSource
            // 
            this.SUPPLIERSBindingSource.DataMember = "SUPPLIERS";
            this.SUPPLIERSBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.SUPPLIERSBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Building_Company.Report2.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 63);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(689, 398);
            this.reportViewer1.TabIndex = 0;
            // 
            // SUPPLIERSTableAdapter
            // 
            this.SUPPLIERSTableAdapter.ClearBeforeFill = true;
            // 
            // FormCustReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 463);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormCustReport";
            this.Text = "FormCustReport";
            this.Load += new System.EventHandler(this.FormCustReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SUPPLIERSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource SUPPLIERSBindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.SUPPLIERSTableAdapter SUPPLIERSTableAdapter;
    }
}