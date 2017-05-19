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
    public partial class Help : MetroFramework.Forms.MetroForm
    {
        public Help()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Help_Load(object sender, EventArgs e)
        {
            richTextBox1.Text =
                @"Дана програма призначена для роботи із базою даних будівельної компанії, у ній реалізовані усі стандартні" +
                @"функції - такі як: Додавання, Видалення, Редагування. Також є можливість виводити звіти до таблиць";
        }
    }
}
