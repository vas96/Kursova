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
    public partial class FormObj : MetroFramework.Forms.MetroForm
    {
        public FormObj()
        {
            InitializeComponent();
        }

        private void FormReport1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.OBJECTS' table. You can move, or remove it, as needed.
            this.OBJECTSTableAdapter.Fill(this.DataSet1.OBJECTS);

            this.reportViewer1.RefreshReport();
           
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
