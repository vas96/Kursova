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
    public partial class FormCustReport : MetroFramework.Forms.MetroForm
    {
        public FormCustReport()
        {
            InitializeComponent();
        }

        private void FormCustReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.SUPPLIERS' table. You can move, or remove it, as needed.
            this.SUPPLIERSTableAdapter.Fill(this.DataSet1.SUPPLIERS);

            this.reportViewer1.RefreshReport();
        }
    }
}
