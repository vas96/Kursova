using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Building_Company
{
    public partial class FormOfficeReport : MetroFramework.Forms.MetroForm
    {
        public FormOfficeReport()
        {
            InitializeComponent();
        }

        private void FormOfficeReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.EMPLOYEES' table. You can move, or remove it, as needed.
            this.EMPLOYEESTableAdapter.Fill(this.DataSet1.EMPLOYEES);
        
            this.reportViewer1.RefreshReport();
          
        }
    }
}
