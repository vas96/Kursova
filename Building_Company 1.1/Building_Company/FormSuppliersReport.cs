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
    public partial class FormSuppliersReport : MetroFramework.Forms.MetroForm
    {
        public FormSuppliersReport()
        {
            InitializeComponent();
        }

        private void FormSuppliersReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.CUSTOMERS' table. You can move, or remove it, as needed.
            this.CUSTOMERSTableAdapter.Fill(this.DataSet1.CUSTOMERS);

            this.reportViewer1.RefreshReport();
        }
    }
}
