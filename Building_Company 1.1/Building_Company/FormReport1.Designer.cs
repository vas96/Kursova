namespace Building_Company
{
    partial class FormObj
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
            this.OBJECTSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new Building_Company.DataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.OBJECTSTableAdapter = new Building_Company.DataSet1TableAdapters.OBJECTSTableAdapter();
            this.OBJECTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.OBJECTSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OBJECTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // OBJECTSBindingSource
            // 
            this.OBJECTSBindingSource.DataMember = "OBJECTS";
            this.OBJECTSBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.OBJECTSBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Building_Company.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 63);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(668, 399);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // OBJECTSTableAdapter
            // 
            this.OBJECTSTableAdapter.ClearBeforeFill = true;
            // 
            // OBJECTBindingSource
            // 
            this.OBJECTBindingSource.DataSource = typeof(Building_Company.OBJECT);
            // 
            // FormObj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 463);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormObj";
            this.Text = "FormObjReport";
            this.Load += new System.EventHandler(this.FormReport1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OBJECTSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OBJECTBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource OBJECTBindingSource;
        private System.Windows.Forms.BindingSource OBJECTSBindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.OBJECTSTableAdapter OBJECTSTableAdapter;
    }
}