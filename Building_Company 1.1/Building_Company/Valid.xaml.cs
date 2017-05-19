using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace Building_Company
{
    /// <summary>
    /// Interaction logic for Valid.xaml
    /// </summary>
    public partial class Valid : MetroWindow
    {
        KR_BD2Entities buildingCompany = new KR_BD2Entities();

        private ObservableCollection<EMPLOYEE> _buildEmployees;
        public Valid()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            _buildEmployees = new ObservableCollection<EMPLOYEE>(buildingCompany.EMPLOYEES);
        }

   

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
             var myUser = buildingCompany.EMPLOYEES
            .FirstOrDefault(u => u.email == textBoxLoginUser.Text
                           && u.password == passwordBoxLoginUser.Password);
            
            if (myUser != null)    //User was found
            {
                MessageBox.Show("Ви успішно авторизувалися");
                string dt = DateTime.Now.ToString("yyyyMMddHHmmss");
                string dbBackUp = myUser.firstName.Trim() + myUser.lastName.Trim() + dt.ToString().Trim();
                string dbname = buildingCompany.Database.Connection.Database;
                string sqlCommand = @"BACKUP DATABASE [{0}] TO  DISK = N'{1}' WITH NOFORMAT, NOINIT,  NAME = N'MyAir-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
                buildingCompany.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, string.Format(sqlCommand, dbname, dbBackUp.Trim()));

                MainWindow window = new MainWindow(myUser.lastName, myUser.firstName, myUser.userType);
                window.Show();
                this.Close();
            }
            else    //User was not found
            {
                MessageBox.Show("Неправильний логін або пароль, перевірте правильність даних");
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBoxLoginUser.Text = "";
            passwordBoxLoginUser.Password = "";
        }
    }
}
