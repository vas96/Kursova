using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Windows.Media.Animation;
using DataGrid = System.Windows.Controls.DataGrid;

namespace Building_Company
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public static KR_BD2Entities BuildingCompany = new KR_BD2Entities();

        private ObservableCollection<CUSTOMER> _buldCustomers;
        private ObservableCollection<OBJECT> _buldObjecs;
        public static ObservableCollection<EMPLOYEE> _buildEmployees;
        private ObservableCollection<WorkSheldue> _buldWorkSheldues;
        private ObservableCollection<used_materials> _buldusedMaterials;
        private ObservableCollection<MATERIAL> _buldMaterials;
        private ObservableCollection<SPECIALITY> _buldSpecialitys;
        private ObservableCollection<OFFICE> _buldOfiOfficess;
        private ObservableCollection<SUPPLIER> _buldsSupplierss;
        private ObservableCollection<WorkType> _buldsTypes;
        private ObservableCollection<UNIT> _buldsUnits;
   
        private ObservableCollection<OBJECT> _buldObjecsSearchCollection;
        private ObservableCollection<WorkSheldue> _buldObjecsSearchCollectionWH;
        private ObservableCollection<EMPLOYEE> _buldOEmpSearchCollection;
        private ObservableCollection<WorkType> _buldWorkTypesSearchCollection;
        private ObservableCollection<SPECIALITY> _buldSpecialitySearchCollection;
        private ObservableCollection<CUSTOMER> _buldcCustomerssSearchCollection;
        private ObservableCollection<used_materials> _bulduUsedMaterialsesSearchCollection;
        private ObservableCollection<MATERIAL> _buldMaterialsCollection;
        private ObservableCollection<SUPPLIER> _buldSupplierssearchCollection;
        private ObservableCollection<OFFICE> _buldOfficessearchCollection;
        private ObservableCollection<UNIT> _buldUnitsearchCollection;


        public MainWindow()
        {
            InitializeComponent();

        }

        public MainWindow(string myUserLastName, string myUserFirstName, string myUserUserType)
        {
            InitializeComponent();

            Enter.Content = $"{myUserLastName} {myUserFirstName}";

            _buldCustomers = new ObservableCollection<CUSTOMER>(BuildingCompany.CUSTOMERS);
            _buldObjecs = new ObservableCollection<OBJECT>(BuildingCompany.OBJECTS);
            _buildEmployees = new ObservableCollection<EMPLOYEE>(BuildingCompany.EMPLOYEES);
            _buldWorkSheldues = new ObservableCollection<WorkSheldue>(BuildingCompany.WorkSheldues);
            _buldsTypes = new ObservableCollection<WorkType>(BuildingCompany.WorkTypes);
            _buldusedMaterials = new ObservableCollection<used_materials>(BuildingCompany.used_materials);
            _buldMaterials = new ObservableCollection<MATERIAL>(BuildingCompany.MATERIALs);
            _buldSpecialitys = new ObservableCollection<SPECIALITY>(BuildingCompany.SPECIALITies);
            _buldOfiOfficess = new ObservableCollection<OFFICE>(BuildingCompany.OFFICES);
            _buldsSupplierss = new ObservableCollection<SUPPLIER>(BuildingCompany.SUPPLIERS);
             _buldsUnits = new ObservableCollection<UNIT>(BuildingCompany.UNITS);
        
            GridObjects.ItemsSource = _buldObjecs;
            GridWorkScheldue.ItemsSource = _buldWorkSheldues;
            GridCustomers.ItemsSource = _buldCustomers;
            GridEmployees.ItemsSource = _buildEmployees;
            GridSUsedMaterials.ItemsSource = _buldusedMaterials;
            GridMaterials.ItemsSource = _buldMaterials;
            GridWorkTypes.ItemsSource = _buldsTypes;
            GridSpeciality.ItemsSource = _buldSpecialitys;
            GridSuppliers.ItemsSource = _buldsSupplierss;
            GridOffices.ItemsSource = _buldOfiOfficess;
            GridUnits.ItemsSource = _buldsUnits;

            var sourceTypes = _buldsTypes.Select(f => f.name);
            WHWorkType.ItemsSource = sourceTypes;

            var sourceOffices = _buldOfiOfficess.Select(f => f.city);
            empCombo2.ItemsSource = sourceOffices;
            empOfficeUpd.ItemsSource = sourceOffices;

            var sourceSuppiler = _buldsSupplierss.Select(f => f.companyName);
            UsedMaterrialsuppilers.ItemsSource = sourceSuppiler;

            var sourceMatterial = _buldMaterials.Select(f => f.name);
            UsedMaterrialMaterial.ItemsSource = sourceMatterial;

            var sourceCustomer = _buldCustomers.Select(f => f.customerName);
            CustomerListObj.ItemsSource = sourceCustomer;
            CustomerListObjUpd.ItemsSource = sourceCustomer;

            var sourceUnit = _buldsUnits.Select(f => f.name);
            WHWorkUnit.ItemsSource = sourceUnit;
            WHWorUnitUpd.ItemsSource = sourceUnit;
            UsedMaterrialUnit.ItemsSource = sourceUnit;
            comboBoxAddUnitEmp.ItemsSource = sourceUnit;

            var sourceSpeciality = _buldSpecialitys.Select(f => f.name);
            comboBoxAddSpecialityEmp.ItemsSource = sourceSpeciality;
            
            if (myUserUserType.Trim() == "managerEmployee".Trim())
            {
                tab1.Visibility = Visibility.Collapsed;
                tab2.Visibility = Visibility.Collapsed;
                tab3.Visibility = Visibility.Collapsed;
                tab4.Visibility = Visibility.Collapsed;
                tab5.Visibility = Visibility.Collapsed;
                tab6.Visibility = Visibility.Collapsed;
                tab7.Visibility = Visibility.Collapsed;
            }
            if (myUserUserType.Trim() == "managerBuilding".Trim())
            {
                tab8.Visibility = Visibility.Collapsed;
                tab9.Visibility = Visibility.Collapsed;
                tab10.Visibility = Visibility.Collapsed;
                tab11.Visibility = Visibility.Collapsed;
            }
        }

        
     

        private void addObj_Click(object sender, RoutedEventArgs e)
        {
            BorderUpdObj.Visibility = Visibility.Collapsed;
            BorderAddObj.Visibility = Visibility.Visible;

            ShowPanel(GridObjects);
        }

        private void ShowPanel(DataGrid grid)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.To = 526;
            da.Duration = TimeSpan.FromSeconds(2);
            grid.BeginAnimation(DataGrid.WidthProperty, da);
        }

        private void delObj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var itemsDeleted = (OBJECT) GridObjects.SelectedItem;
                BuildingCompany.OBJECTS.Remove(itemsDeleted);
                _buldObjecs.Remove(itemsDeleted);            
        }
            catch (Exception exception)
            {
                MessageBox.Show("Можливо, Ви не вибрали елемент");
            }
            BuildingCompany.SaveChanges();
        }

        private void UpdObj_Click(object sender, RoutedEventArgs e)
        {
            BorderAddObj.Visibility = Visibility.Collapsed;
            BorderUpdObj.Visibility = Visibility.Visible;
            GridObjects.Width = 526;

            ShowPanel(GridObjects);
        }

        private void SearchObjBut_OnClickObj_Click(object sender, RoutedEventArgs e)
        {

            if (ComboBoxSearchObj.SelectedItem != null && ComboBoxSearchObj.SelectedIndex == 0)
            {
                _buldObjecsSearchCollection =
                    new ObservableCollection<OBJECT>(_buldObjecs.Where(f => f.comments.Contains(TextBoxSearchObj.Text)));
                GridObjects.ItemsSource = _buldObjecsSearchCollection;
                if (_buldObjecsSearchCollection == null)
                {
                    GridObjects.ItemsSource = _buldObjecs;
                }
            }

            if (ComboBoxSearchObj.SelectedItem != null && ComboBoxSearchObj.SelectedIndex == 1)
            {
                DateTime txtObjOrderTime = DateTime.Parse(TextBoxSearchObj.Text);

                _buldObjecsSearchCollection =
                    new ObservableCollection<OBJECT>(_buldObjecs.Where(f => f.orderData.Value == txtObjOrderTime));
                GridObjects.ItemsSource = _buldObjecsSearchCollection;
                if (_buldObjecsSearchCollection == null)
                {
                    GridObjects.ItemsSource = _buldObjecs;
                }
            }

            if (ComboBoxSearchObj.SelectedItem != null && ComboBoxSearchObj.SelectedIndex == 2)
            {
                _buldObjecsSearchCollection =
                    new ObservableCollection<OBJECT>(
                        _buldObjecs.Where(f => f.addressLine.Contains(TextBoxSearchObj.Text)));
                GridObjects.ItemsSource = _buldObjecsSearchCollection;
                if (_buldObjecsSearchCollection == null)
                {
                    GridObjects.ItemsSource = _buldObjecs;
                }
            }

            if (ComboBoxSearchObj.SelectedItem != null && ComboBoxSearchObj.SelectedIndex == 3)
            {
                var SearchidCustomer =
                    new ObservableCollection<CUSTOMER>(
                        _buldCustomers.Where(f => f.customerName.Contains(TextBoxSearchObj.Text)));
                _buldObjecsSearchCollection = new ObservableCollection<OBJECT>();
                foreach (var VARIABLE in SearchidCustomer)
                {
                    var temp =
                        new ObservableCollection<OBJECT>(_buldObjecs.Where(f => f.customerId == VARIABLE.customerId));
                    //    _buldObjecsSearchCollection = temp;
                    for (var i = 0; i < temp.Count; i++)
                    {
                        _buldObjecsSearchCollection.Add(temp[i]);
                    }
                }

                // var temp = _buldObjecsSearchCollection.Where(f => f.customerId == 1);
                //   _buldObjecsSearchCollection.Add(temp);


                GridObjects.ItemsSource = _buldObjecsSearchCollection;
                if (_buldObjecsSearchCollection == null)
                {
                    GridObjects.ItemsSource = _buldObjecs;
                }
            }

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (adrText1_Obj.Text == "" || adrText2_Obj.Text == "" || textBoxNameObj.Text == "" ||
                textBoxCountryObj.Text == "")
            {
                MessageBox.Show("Заповність усі поля");
                return;
            }

            var newIdObj = BuildingCompany.OBJECTS.Max(u => u.idObject) + 1;

            DateTime date = DateTime.Today;

            var customerIdTemp =
                _buldCustomers.Where(f => f.customerName == CustomerListObj.Text).Select(f => f.customerId).ToList();

            CUSTOMER CustomerObj = _buldCustomers.FirstOrDefault(f=>f.customerId== customerIdTemp[0]);

            OBJECT temp = new OBJECT();
            try
            {
                temp.idObject = newIdObj;
                temp.addressLine = adrText1_Obj.Text + " вул." + adrText2_Obj.Text + " " + adrText2_Obj.Text + " ";
                temp.orderData = date;
                temp.comments = textBoxNameObj.Text;
                temp.status = "будівництво";
                temp.country = textBoxCountryObj.Text;
                temp.CUSTOMER = CustomerObj;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте дані");
            }

            try
            {
                {
                    BuildingCompany.OBJECTS.Add(temp);
                    BuildingCompany.SaveChanges();
                    _buldObjecs.Add(temp);
                    MessageBox.Show("Додано новий об'єкт будівництва" + "№" + newIdObj);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Вибачте, помилка у додаванні об'єкта будівництва перевірте правильність даних");
            }
        }


        private void addWH_Click(object sender, RoutedEventArgs e)
        {
            BorderUpdWH.Visibility = Visibility.Collapsed;
            BorderAddWH.Visibility = Visibility.Visible;

            ShowPanel(GridWorkScheldue);
        }

        private void UpdWH_Click(object sender, RoutedEventArgs e)
        {
            BorderAddWH.Visibility = Visibility.Collapsed;
            BorderUpdWH.Visibility = Visibility.Visible;

            ShowPanel(GridWorkScheldue);
        }

        private void delWH_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var itemsDeleted = (WorkSheldue) GridWorkScheldue.SelectedItem;
                BuildingCompany.WorkSheldues.Remove(itemsDeleted);
                _buldWorkSheldues.Remove(itemsDeleted);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Можливо, Ви не вибрали елемент");
            }
            BuildingCompany.SaveChanges();
        }

        private void addWH_Click_1(object sender, RoutedEventArgs e)
        {


            var unitTemp = _buldsUnits.First(f => f.name == WHWorkUnit.Text);
            var workType = _buldsTypes.FirstOrDefault(f => f.name == WHWorkType.Text);
            var ObjectTemp = _buldObjecs.FirstOrDefault(f => f.idObject == int.Parse(textBoxWHidoBJ.Text));
            var newIdWH = BuildingCompany.WorkSheldues.Max(u => u.idWorkShedule) + 1;

          
            WorkSheldue temp = new WorkSheldue();        
            try
            {
                temp.idWorkShedule = newIdWH;
                temp.name = WHName.Text;
                temp.startWork = WHstartWorkpick.SelectedDate;
                temp.finishWork = WHfinishWorkpick.SelectedDate;
                temp.UNIT = unitTemp;
                temp.WorkType = workType;
                temp.description = (WHdescription.Text);
                temp.OBJECT = ObjectTemp;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
            }
            if (WHName.Text == "" || textBoxWHidoBJ.Text == "")
            {
                MessageBox.Show("Заповність усі поля");
                return;
            }

            try
            {
                {
                    {
                        BuildingCompany.WorkSheldues.Add(temp);
                        BuildingCompany.SaveChanges();
                        _buldWorkSheldues.Add(temp);
                        MessageBox.Show("Додано новий графік робіт" + newIdWH.ToString());
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Вибачте, помилка у додаванні графіка роботи, перевірте правильність даних");
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            var newIdEmp = BuildingCompany.EMPLOYEES.Max(u => u.employeeId) + 1;

            DateTime date = DateTime.Today;

            var OfficeIdTemp = _buldOfiOfficess.FirstOrDefault(f => f.city == empCombo2.Text);

            EMPLOYEE temp = new EMPLOYEE();          
            try
            {
                temp.employeeId = newIdEmp;
                temp.firstName = empText1.Text;
                temp.lastName = empText2.Text;
                temp.homePhone = empText4.Text;
                temp.hereDate = date;
                temp.salary = decimal.Parse(empText3.Text, CultureInfo.InvariantCulture);
                temp.email = empEmail.Text;
                temp.birthDate = birthDateEmp.SelectedDate;
                temp.country = "Україна";
                temp.OFFICE = OfficeIdTemp;
                temp.addressLine = empText3_adress.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
                return;
            }

            try
            {
                {
                    BuildingCompany.EMPLOYEES.Add(temp);
                    _buildEmployees.Add(temp);
                    BuildingCompany.SaveChanges();
                    MessageBox.Show("Додано нового працівника" + " №" + newIdEmp.ToString());
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Вибачте, помилка у додаванні працівника, перевірте правильність даних");
            }

        }


        private void addSpecialityBut_Click(object sender, RoutedEventArgs e)
        {
            var newIdSpeciality = BuildingCompany.SPECIALITies.Max(u => u.idSpeciality) + 1;
            SPECIALITY temp = new SPECIALITY()
            {
                idSpeciality = newIdSpeciality,
                name = Specialityename.Text
            };
            
            try
            {
                {
                    BuildingCompany.SPECIALITies.Add(temp);
                    BuildingCompany.SaveChanges();
                    _buldSpecialitys.Add(temp);
                    GridSpeciality.ItemsSource = _buldSpecialitys;
                    MessageBox.Show("Додано нову спеціальність працівника" + " №" + newIdSpeciality.ToString());
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Вибачте, помилка у додаванні типу роботи, перевірте правильність даних");
            }
        }

        private void addCustomerBut_Click(object sender, RoutedEventArgs e)
        {

            var newIdCust = BuildingCompany.CUSTOMERS.Max(u => u.customerId) + 1;
            CUSTOMER temp = new CUSTOMER();
          
            try
            {
                temp.customerId = newIdCust;
                temp.customerName = custname.Text;
                temp.contactLastName = custSurname.Text;
                temp.contatctFirstName = custFirstName.Text;
                temp.contactPhone = custPhone.Text;
                temp.country = custCountry.Text;
                temp.city = custCity.Text;
                temp.addresLine = custAdress.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
                return;
            }

            try
            {
                {
                    BuildingCompany.CUSTOMERS.Add(temp);
                    BuildingCompany.SaveChanges();
                    _buldCustomers.Add(temp);
                    GridSpeciality.ItemsSource = _buldSpecialitys;
                    MessageBox.Show("Додано нового засовника" + " № " + newIdCust.ToString());
                    var sourceCustomer = _buldCustomers.Select(f => f.customerName);
                    CustomerListObj.ItemsSource = sourceCustomer;
                    CustomerListObjUpd.ItemsSource = sourceCustomer;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Вибачте, помилка у додаванні замовника, перевірте правильність даних");
            }


        }

        private void AddUsedMaterial_Click(object sender, RoutedEventArgs e)
        {
            var newIdUsedMaterial = BuildingCompany.used_materials.Max(u => u.used_Material_Id) + 1;
            var SuppliereIdTemp = _buldsSupplierss.FirstOrDefault(f =>f.companyName == UsedMaterrialsuppilers.Text);
            var MaterialIdTemp = _buldMaterials.FirstOrDefault(f => f.name == UsedMaterrialMaterial.Text);
            var unitIdTemp = _buldsUnits.FirstOrDefault(f => f.name == UsedMaterrialUnit.Text);
            var ObjectTemp = _buldObjecs.FirstOrDefault(f => f.idObject == int.Parse(UsedMaterrialOb1j.Text));

            used_materials temp = new used_materials();
            try
            {
                
                temp.used_Material_Id = newIdUsedMaterial;
                temp.MATERIAL = MaterialIdTemp;
                temp.OBJECT = ObjectTemp;
                temp.UNIT = unitIdTemp;
                temp.number = Int32.Parse(UsedMaterrial_KilkMaterial.Text);
                temp.uniPrice = Int32.Parse(UsedMaterrial_Price.Text);
                temp.SUPPLIER = SuppliereIdTemp;
                
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
            }
            
                  try
            {
                {
                    BuildingCompany.used_materials.Add(temp);
                    BuildingCompany.SaveChanges();
                    _buldusedMaterials.Add(temp);
                    MessageBox.Show("Додано нові матеріали для підрозділа № " + newIdUsedMaterial.ToString());

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Вибачте, помилка у додаванні запису. Перевірте правильність даних");
            }
        }

        private void addMaterialBu1t_Click(object sender, RoutedEventArgs e)
        {
            var newIdMaterial = BuildingCompany.MATERIALs.Max(u => u.idMatterial) + 1;

            DateTime date = DateTime.Today;

            MATERIAL temp = new MATERIAL()
            {
                idMatterial = newIdMaterial,
                name = materialName.Text,
                integer_ = WorkType1name_Copy.Text
            };

            try
            {
                {
                    _buldMaterials.Add(temp);
                    BuildingCompany.MATERIALs.Add(temp);
                    BuildingCompany.SaveChanges();
                    MessageBox.Show("Додано новий матерал №" + newIdMaterial);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Вибачте, помилка у додаванні запису");

            }
        }

        private void reportObjCustomer_Click(object sender, RoutedEventArgs e)
        {
            Valid window = new Valid();
            window.Show();
        }



        private void buttonUpdObj_Click(object sender, RoutedEventArgs e)
        {
            var itemsUpd = (OBJECT) GridObjects.SelectedItem;
            try
            {
                var customerIdTemp =
                    _buldCustomers.Where(f => f.customerName == CustomerListObjUpd.Text)
                        .Select(f => f.customerId)
                        .ToList();

                itemsUpd.addressLine = adrText3_ObjUpd.Text;
                itemsUpd.comments = textBoxNameUpd.Text;
                itemsUpd.country = textBoxCountryObjUpd.Text;

                if (statusBuild.SelectedItem != null)
                {
                    ComboBoxItem cbItem = (ComboBoxItem) statusBuild.SelectedItem;
                    itemsUpd.status = (cbItem.Content.ToString());
                }
                if (CustomerListObjUpd.SelectedItem != null)
                {
                    CUSTOMER CustomerObj = _buldCustomers.First(f => f.customerId == customerIdTemp[0]);
                    itemsUpd.CUSTOMER = CustomerObj;
                }
                BuildingCompany.Entry(itemsUpd).State = EntityState.Modified;
                BuildingCompany.SaveChanges();
                MessageBox.Show("Зміни прийнято");
                _buldObjecs = new ObservableCollection<OBJECT>(BuildingCompany.OBJECTS);
                GridObjects.ItemsSource = _buldObjecs;
                GridObjects.SelectedItem = customerIdTemp;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
            }

        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridObjects);
        }

        private void button1_CopyUpd_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridObjects);
        }

        private void UpdWHButt_Click(object sender, RoutedEventArgs e)
        {
            var itemsUpd = (WorkSheldue) GridWorkScheldue.SelectedItem;
            try
            {
                 var ObjectTemp = _buldObjecs.FirstOrDefault(f => f.idObject == int.Parse(textBoxWHidoBJ.Text));



                var unitTemp = _buldsUnits.FirstOrDefault(f => f.name == WHWorUnitUpd.Text);
                var workTypeTemp = _buldsTypes.FirstOrDefault(f => f.name == WHWorkTypeUpd.Text);

                itemsUpd.name = WHNameUpd.Text;
                itemsUpd.startWork = WHstartWorkpickUpd.SelectedDate;
                itemsUpd.finishWork = WHfinishWorkpickUpd.SelectedDate;

                if (WHWorUnitUpd.SelectedItem != null)
                {
                    itemsUpd.UNIT = unitTemp;
                }
                if (WHWorkTypeUpd.SelectedItem != null)
                {
                    itemsUpd.WorkType = workTypeTemp;
                }
                BuildingCompany.Entry(itemsUpd).State = EntityState.Modified;
                BuildingCompany.SaveChanges();
                MessageBox.Show("Зміни прийнято");
                //  _buldObjecs.Clear();
                _buldWorkSheldues = new ObservableCollection<WorkSheldue>(BuildingCompany.WorkSheldues);
                GridWorkScheldue.ItemsSource = _buldWorkSheldues;
                // GridObjects.SelectedItem = customerIdTemp;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
            }
        }

        private void closeAddWH_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridWorkScheldue);
        }

        private void HidenPanel(DataGrid grid)
        {
            DoubleAnimation da = new DoubleAnimation();
            da.To = 786;
            da.Duration = TimeSpan.FromSeconds(2);
            grid.BeginAnimation(DataGrid.WidthProperty, da);
        }

        private void UpdWH_Close_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridWorkScheldue);
        }

        private void SearchWHBut_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxSearchObj.SelectedItem != null && ComboBoxSearchObj.SelectedIndex == 0)
            {
                _buldObjecsSearchCollectionWH =
                    new ObservableCollection<WorkSheldue>(
                        _buldWorkSheldues.Where(f => f.name.Contains(TextBoxSearchWH.Text)));
                GridWorkScheldue.ItemsSource = _buldObjecsSearchCollectionWH;
                if (_buldObjecsSearchCollectionWH == null)
                {
                    GridWorkScheldue.ItemsSource = _buldWorkSheldues;
                }
            }

            if (ComboBoxSearchObj.SelectedItem != null && ComboBoxSearchObj.SelectedIndex == 1)
            {
                DateTime txtObjOrderTime = DateTime.Parse(TextBoxSearchObj.Text);

                _buldObjecsSearchCollection =
                    new ObservableCollection<OBJECT>(_buldObjecs.Where(f => f.orderData.Value == txtObjOrderTime));
                GridObjects.ItemsSource = _buldObjecsSearchCollection;
                if (_buldObjecsSearchCollection == null)
                {
                    GridObjects.ItemsSource = _buldObjecs;
                }
            }

            if (ComboBoxSearchObj.SelectedItem != null && ComboBoxSearchObj.SelectedIndex == 2)
            {
                _buldObjecsSearchCollection =
                    new ObservableCollection<OBJECT>(
                        _buldObjecs.Where(f => f.addressLine.Contains(TextBoxSearchObj.Text)));
                GridObjects.ItemsSource = _buldObjecsSearchCollection;
                if (_buldObjecsSearchCollection == null)
                {
                    GridObjects.ItemsSource = _buldObjecs;
                }
            }
        }

        private void TextBoxSearchWH_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ComboBoxWHsearchOption.SelectedItem != null && ComboBoxWHsearchOption.SelectedIndex == 0)
            {
                _buldObjecsSearchCollectionWH =
                   new ObservableCollection<WorkSheldue>(
                        BuildingCompany.WorkSheldues.Where(x => SqlFunctions.StringConvert((double)x.idWorkShedule)
                            .TrimStart().StartsWith(TextBoxSearchWH.Text)));
                GridWorkScheldue.ItemsSource = _buldObjecsSearchCollectionWH;
                if (_buldObjecsSearchCollectionWH == null)
                {
                    GridWorkScheldue.ItemsSource = _buldWorkSheldues;
                }
            }
            if (ComboBoxWHsearchOption.SelectedItem != null && ComboBoxWHsearchOption.SelectedIndex == 1)
            {
                _buldObjecsSearchCollectionWH =
                    new ObservableCollection<WorkSheldue>(
                        _buldWorkSheldues.Where(f => f.name.Contains(TextBoxSearchWH.Text)));
                GridWorkScheldue.ItemsSource = _buldObjecsSearchCollectionWH;
                if (_buldObjecsSearchCollectionWH == null)
                {
                    GridWorkScheldue.ItemsSource = _buldWorkSheldues;
                }
            }

            if (ComboBoxWHsearchOption.SelectedItem != null && ComboBoxWHsearchOption.SelectedIndex == 2)
            {
                string tempTime = (TextBoxSearchWH.Text);

                _buldObjecsSearchCollectionWH =
                   new ObservableCollection<WorkSheldue>(
                       _buldWorkSheldues.Where(f => f.startWork.ToString().Contains(tempTime)));
                GridWorkScheldue.ItemsSource = _buldObjecsSearchCollectionWH;

                if (_buldObjecsSearchCollectionWH == null)
                {
                    GridWorkScheldue.ItemsSource = _buldWorkSheldues;
                }
            }

            if (ComboBoxWHsearchOption.SelectedItem != null && ComboBoxWHsearchOption.SelectedIndex == 3)
            {

                string tempTime = (TextBoxSearchWH.Text);

                _buldObjecsSearchCollectionWH =
                   new ObservableCollection<WorkSheldue>(
                       _buldWorkSheldues.Where(f => f.finishWork.ToString().Contains(tempTime)));
                GridWorkScheldue.ItemsSource = _buldObjecsSearchCollectionWH;

                if (_buldObjecsSearchCollectionWH == null)
                {
                    GridWorkScheldue.ItemsSource = _buldWorkSheldues;
                }
            }
            if (ComboBoxSearchObj.SelectedItem != null && ComboBoxSearchObj.SelectedIndex == 4)
            {
                _buldObjecsSearchCollectionWH =
                    new ObservableCollection<WorkSheldue>(
                        _buldWorkSheldues.Where(f => f.description.Contains(TextBoxSearchWH.Text)));
                GridWorkScheldue.ItemsSource = _buldObjecsSearchCollectionWH;
                if (_buldObjecsSearchCollectionWH == null)
                {
                    GridWorkScheldue.ItemsSource = _buldWorkSheldues;
                }
            }
        }

        private void TextBoxSearchObj_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (ComboBoxSearchObj.SelectedItem != null && ComboBoxSearchObj.SelectedIndex == 0)
            {
                _buldObjecsSearchCollection =
                    new ObservableCollection<OBJECT>(
                         BuildingCompany.OBJECTS.Where(x => SqlFunctions.StringConvert((double)x.idObject)
                            .TrimStart().StartsWith(TextBoxSearchObj.Text)));
                GridObjects.ItemsSource = _buldObjecsSearchCollection;
                if (_buldObjecsSearchCollection == null)
                {
                    GridObjects.ItemsSource = _buldObjecs;
                }
            }

            if (ComboBoxSearchObj.SelectedItem != null && ComboBoxSearchObj.SelectedIndex == 1)
            {
                _buldObjecsSearchCollection =
                    new ObservableCollection<OBJECT>(_buldObjecs.Where(f => f.comments.Contains(TextBoxSearchObj.Text)));
                GridObjects.ItemsSource = _buldObjecsSearchCollection;
                if (_buldObjecsSearchCollection == null)
                {
                    GridObjects.ItemsSource = _buldObjecs;
                }
            }

            if (ComboBoxSearchObj.SelectedItem != null && ComboBoxSearchObj.SelectedIndex == 2)
            {
                DateTime txtObjOrderTime = DateTime.Parse(TextBoxSearchObj.Text);

                _buldObjecsSearchCollection =
                    new ObservableCollection<OBJECT>(_buldObjecs.Where(f => f.orderData.Value == txtObjOrderTime));
                GridObjects.ItemsSource = _buldObjecsSearchCollection;
                if (_buldObjecsSearchCollection == null)
                {
                    GridObjects.ItemsSource = _buldObjecs;
                }
            }

            if (ComboBoxSearchObj.SelectedItem != null && ComboBoxSearchObj.SelectedIndex == 3)
            {
                _buldObjecsSearchCollection =
                    new ObservableCollection<OBJECT>(
                        _buldObjecs.Where(f => f.addressLine.Contains(TextBoxSearchObj.Text)));
                GridObjects.ItemsSource = _buldObjecsSearchCollection;
                if (_buldObjecsSearchCollection == null)
                {
                    GridObjects.ItemsSource = _buldObjecs;
                }
            }
        }

        private void UpdateEmpButt_Click(object sender, RoutedEventArgs e)
        {

            var itemsUpd = (EMPLOYEE) GridEmployees.SelectedItem;
            var OfficeIdTemp = _buldOfiOfficess.FirstOrDefault(f => f.city == empOfficeUpd.Text);
            //     var workTypeIdTemp =
            //         _buldsTypes.Where(f => f.name == WHWorkTypeUpd.Text).Select(f => f.workTypeId).ToList();

            itemsUpd.firstName = empNameUpd.Text;
            itemsUpd.lastName = empSurnameUpd.Text;
            itemsUpd.homePhone = empPhoneUpd.Text;
            itemsUpd.email = empEmailUpd.Text;
            itemsUpd.salary = decimal.Parse(empSalaryUpd.Text, CultureInfo.InvariantCulture);
            if (birthDateEmpUpd.SelectedDate != null)
            {
                itemsUpd.birthDate = birthDateEmpUpd.SelectedDate;
            }
            if (empOfficeUpd.SelectedItem != null)
            {
                itemsUpd.OFFICE = OfficeIdTemp;
            }
            itemsUpd.addressLine = emp_adressUpd.Text;

            try
            {
                BuildingCompany.Entry(itemsUpd).State = EntityState.Modified;
                BuildingCompany.SaveChanges();
                MessageBox.Show("Зміни прийнято");
                _buildEmployees = new ObservableCollection<EMPLOYEE>(BuildingCompany.EMPLOYEES);
                GridEmployees.ItemsSource = _buildEmployees;
                // GridObjects.SelectedItem = customerIdTemp;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
            }

        }

        private void hidenAddEmp_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridEmployees);
        }

        private void hidenEmpUpd_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridEmployees);
        }

        private void updEmpShow_Click(object sender, RoutedEventArgs e)
        {
            BorderAddEmp.Visibility = Visibility.Collapsed;
            BorderUpdAddSpeciality.Visibility = Visibility.Collapsed;
            BorderUpdAddSpeciality_Copy.Visibility = Visibility.Collapsed;
            BorderUpdAddSpeciality_Copy1.Visibility = Visibility.Collapsed;
            BorderUpdEmp.Visibility = Visibility.Visible;

            ShowPanel(GridEmployees);
        }

        private void addEmpButtShow_Click(object sender, RoutedEventArgs e)
        {
            BorderUpdEmp.Visibility = Visibility.Collapsed;
            BorderUpdAddSpeciality.Visibility = Visibility.Collapsed;
            BorderUpdAddSpeciality_Copy.Visibility = Visibility.Collapsed;
            BorderUpdAddSpeciality_Copy1.Visibility = Visibility.Collapsed;
            BorderAddEmp.Visibility = Visibility.Visible;

            ShowPanel(GridEmployees);
        }

        private void TextBoxSearchEmployee_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (ComboBoxSearchOptionEmp.SelectedItem != null && ComboBoxSearchOptionEmp.SelectedIndex == 0)
            {
                _buldOEmpSearchCollection =
                    new ObservableCollection<EMPLOYEE>(
                        _buildEmployees.Where(f => f.employeeId == (Int32.Parse(TextBoxSearchEmployee.Text))));
                GridEmployees.ItemsSource = _buldOEmpSearchCollection;
                if (_buldOEmpSearchCollection == null)
                {
                    GridWorkScheldue.ItemsSource = _buildEmployees;
                }
            }

            if (ComboBoxSearchOptionEmp.SelectedItem != null && ComboBoxSearchOptionEmp.SelectedIndex == 1)
            {
                _buldOEmpSearchCollection =
                    new ObservableCollection<EMPLOYEE>(
                        _buildEmployees.Where(f => f.firstName.Contains(TextBoxSearchEmployee.Text)));
                GridEmployees.ItemsSource = _buldOEmpSearchCollection;
                if (_buldOEmpSearchCollection == null)
                {
                    GridWorkScheldue.ItemsSource = _buildEmployees;
                }
            }

            if (ComboBoxSearchOptionEmp.SelectedItem != null && ComboBoxSearchOptionEmp.SelectedIndex == 2)
            {
                _buldOEmpSearchCollection =
                    new ObservableCollection<EMPLOYEE>(
                        _buildEmployees.Where(f => f.lastName.Contains(TextBoxSearchEmployee.Text)));
                GridEmployees.ItemsSource = _buldOEmpSearchCollection;
                if (_buldOEmpSearchCollection == null)
                {
                    GridWorkScheldue.ItemsSource = _buildEmployees;
                }
            }
            if (ComboBoxSearchOptionEmp.SelectedItem != null && ComboBoxSearchOptionEmp.SelectedIndex == 3)
            {
                _buldOEmpSearchCollection =
                    new ObservableCollection<EMPLOYEE>(
                        _buildEmployees.Where(f => f.homePhone.Contains(TextBoxSearchEmployee.Text)));
                GridEmployees.ItemsSource = _buldOEmpSearchCollection;
                if (_buldOEmpSearchCollection == null)
                {
                    GridWorkScheldue.ItemsSource = _buildEmployees;
                }
            }
            if (ComboBoxSearchOptionEmp.SelectedItem != null && ComboBoxSearchOptionEmp.SelectedIndex == 4)
            {
                _buldOEmpSearchCollection =
                    new ObservableCollection<EMPLOYEE>(
                        _buildEmployees.Where(f => f.email.Contains(TextBoxSearchEmployee.Text)));
                GridEmployees.ItemsSource = _buldOEmpSearchCollection;
                if (_buldOEmpSearchCollection == null)
                {
                    GridWorkScheldue.ItemsSource = _buildEmployees;
                }
            }
            if (ComboBoxSearchOptionEmp.SelectedItem != null && ComboBoxSearchOptionEmp.SelectedIndex == 5)
            {
                string tempTime = (TextBoxSearchEmployee.Text);

                _buldOEmpSearchCollection =
                    new ObservableCollection<EMPLOYEE>(
                        _buildEmployees.Where(f => f.birthDate.ToString().Contains(tempTime)));
                GridEmployees.ItemsSource = _buldOEmpSearchCollection;
                if (_buldOEmpSearchCollection == null)
                {
                    GridWorkScheldue.ItemsSource = _buildEmployees;
                }
            }
            if (ComboBoxSearchOptionEmp.SelectedItem != null && ComboBoxSearchOptionEmp.SelectedIndex == 6)
            {
                var tempTime = (TextBoxSearchEmployee.Text);

                _buldOEmpSearchCollection =
                    new ObservableCollection<EMPLOYEE>(
                        _buildEmployees.Where(f => f.hereDate.ToString().Contains(tempTime)));
                GridEmployees.ItemsSource = _buldOEmpSearchCollection;
                if (_buldOEmpSearchCollection == null)
                {
                    GridWorkScheldue.ItemsSource = _buildEmployees;
                }
            }
            if (ComboBoxSearchOptionEmp.SelectedItem != null && ComboBoxSearchOptionEmp.SelectedIndex == 7)
            {
                _buldOEmpSearchCollection =
                    new ObservableCollection<EMPLOYEE>(
                        _buildEmployees.Where(f => f.salary.ToString().Contains(TextBoxSearchEmployee.Text)));
                GridEmployees.ItemsSource = _buldOEmpSearchCollection;
                if (_buldOEmpSearchCollection == null)
                {
                    GridWorkScheldue.ItemsSource = _buildEmployees;
                }
            }

        }

        private void delEmp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var itemsDeleted = (EMPLOYEE)GridEmployees.SelectedItem;
                BuildingCompany.EMPLOYEES.Remove(itemsDeleted);
                _buildEmployees.Remove(itemsDeleted);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Можливо, Ви не вибрали елемент");
            }
            BuildingCompany.SaveChanges();
        }

        private void HiddenAddWorkTypeBut_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridWorkTypes);
        }

        private void HiddenUpdWorkTypeBut_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridWorkTypes);
        }

        private void delWt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var itemsDeleted = (WorkType)GridWorkTypes.SelectedItem;
                BuildingCompany.WorkTypes.Remove(itemsDeleted);
                _buldsTypes.Remove(itemsDeleted);
                GridWorkTypes.ItemsSource = _buldsTypes;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Можливо, Ви не вибрали елемент");
            }
            BuildingCompany.SaveChanges();
        }

        private void addWtButt_Click(object sender, RoutedEventArgs e)
        {
            BorderUpdWt.Visibility = Visibility.Collapsed;
            BorderAddWt.Visibility = Visibility.Visible;

            ShowPanel(GridWorkTypes);
        }

        private void updWtButt_Click(object sender, RoutedEventArgs e)
        {
            BorderAddWt.Visibility = Visibility.Collapsed;
            BorderUpdWt.Visibility = Visibility.Visible;

            ShowPanel(GridWorkTypes);
        }

        private void addWorkTypeBut_Click(object sender, RoutedEventArgs e)
        {
            var newIdWorkType = BuildingCompany.WorkTypes.Max(u => u.workTypeId) + 1;
            WorkType temp = new WorkType()
            {
                workTypeId = newIdWorkType,
                name = WorkTypeNameAdd.Text
            };
            try
            {
                {
                    BuildingCompany.WorkTypes.Add(temp);
                    BuildingCompany.SaveChanges();
                    _buldsTypes.Add(temp);
                    MessageBox.Show("Додано новий тип роботи" + " №" + newIdWorkType.ToString());
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Вибачте, помилка у додаванні типу роботи, перевірте правильність даних");
            }
        }

        private void updWorkTypeBut1_Click(object sender, RoutedEventArgs e)
        {
            var itemsUpd = (WorkType)GridWorkTypes.SelectedItem;
          
            itemsUpd.name = WorkTypenameUpd.Text;

            try
            {
                BuildingCompany.Entry(itemsUpd).State = EntityState.Modified;
                BuildingCompany.SaveChanges();
                MessageBox.Show("Зміни прийнято");
                _buldsTypes = new ObservableCollection<WorkType>(BuildingCompany.WorkTypes);
                GridWorkTypes.ItemsSource = _buldsTypes;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
            }
        }

        private void TextBoxSearchWt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ComboBoxWtOption.SelectedItem != null && ComboBoxWtOption.SelectedIndex == 0)
            {
                _buldWorkTypesSearchCollection =
                    new ObservableCollection<WorkType>(
                        BuildingCompany.WorkTypes.Where(x => SqlFunctions.StringConvert((double) x.workTypeId)
                            .TrimStart().StartsWith(TextBoxSearchWt.Text)));
                    GridWorkTypes.ItemsSource = _buldWorkTypesSearchCollection;
                
                if (_buldWorkTypesSearchCollection == null)
                {
                    GridWorkScheldue.ItemsSource = _buldsTypes;
                }
            }

            if (ComboBoxWtOption.SelectedItem != null && ComboBoxWtOption.SelectedIndex == 1)
            {
                _buldWorkTypesSearchCollection =
                    new ObservableCollection<WorkType>(
                        BuildingCompany.WorkTypes.Where(x =>x.name.Contains(TextBoxSearchWt.Text)));
                GridWorkTypes.ItemsSource = _buldWorkTypesSearchCollection;

                if (_buldWorkTypesSearchCollection == null)
                {
                    GridWorkScheldue.ItemsSource = _buldsTypes;
                }
            }
        }

        private void HidenSpecialityBut_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridSpeciality);
        }

        private void HidenUpdSpecialityBut1_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridSpeciality);
        }

        private void UpdSpecialityBut_Click(object sender, RoutedEventArgs e)
        {
            var itemsUpd = (SPECIALITY)GridSpeciality.SelectedItem;

            itemsUpd.name = updSpecialityename.Text;

            try
            {
                BuildingCompany.Entry(itemsUpd).State = EntityState.Modified;
                BuildingCompany.SaveChanges();
                MessageBox.Show("Зміни прийнято");
                _buldSpecialitys = new ObservableCollection<SPECIALITY>(BuildingCompany.SPECIALITies);
                GridSpeciality.ItemsSource = _buldSpecialitys;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
            }
        }

        private void TextBoxSearchSpeciality_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ComboBoxSpecialityOption.SelectedItem != null && ComboBoxSpecialityOption.SelectedIndex == 0)
            {
                _buldSpecialitySearchCollection =
                    new ObservableCollection<SPECIALITY>(
                        BuildingCompany.SPECIALITies.Where(x => SqlFunctions.StringConvert((double)x.idSpeciality)
                            .TrimStart().StartsWith(TextBoxSearchSpeciality.Text)));
                GridSpeciality.ItemsSource = _buldSpecialitySearchCollection;

                if (_buldSpecialitySearchCollection == null)
                {
                    GridSpeciality.ItemsSource = _buldSpecialitys;
                }
            }

            if (ComboBoxSpecialityOption.SelectedItem != null && ComboBoxSpecialityOption.SelectedIndex == 1)
            {
                _buldSpecialitySearchCollection =
                    new ObservableCollection<SPECIALITY>(
                        BuildingCompany.SPECIALITies.Where(x => x.name.Contains(TextBoxSearchSpeciality.Text)));
                GridSpeciality.ItemsSource = _buldSpecialitySearchCollection;

                if (_buldSpecialitySearchCollection == null)
                {
                    GridSpeciality.ItemsSource = _buldSpecialitys;
                }
            }
        }

        private void addSpecialityButt_Click(object sender, RoutedEventArgs e)
        {
            BorderUpdSpeciality.Visibility = Visibility.Collapsed;
            BorderAddSpeciality.Visibility = Visibility.Visible;

            ShowPanel(GridSpeciality);
        }

        private void updSpecialityButt_Click(object sender, RoutedEventArgs e)
        {
            BorderAddSpeciality.Visibility = Visibility.Collapsed;
            BorderUpdSpeciality.Visibility = Visibility.Visible;

            ShowPanel(GridSpeciality);
        }

        private void HidenAddCustomerButt_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridCustomers);
        }

        private void HidenUpdCustomerButt_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridCustomers);
        }

        private void delCustomerBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var itemsDeleted = (CUSTOMER)GridCustomers.SelectedItem;
                BuildingCompany.CUSTOMERS.Remove(itemsDeleted);
                _buldCustomers.Remove(itemsDeleted);
                GridCustomers.ItemsSource = _buldCustomers;
                MessageBox.Show("Видалено замовника № " + itemsDeleted.customerId.ToString());
            }
            catch (Exception exception)
            {
                MessageBox.Show("Можливо, Ви не вибрали елемент");
            }
            BuildingCompany.SaveChanges();
        }

        private void addCustomerButt_Click(object sender, RoutedEventArgs e)
        {
            BorderUpdCustomer.Visibility = Visibility.Collapsed;
            BorderAddCustomer.Visibility = Visibility.Visible;

            ShowPanel(GridCustomers);
        }

        private void updCustomerBut_Click(object sender, RoutedEventArgs e)
        {
            BorderAddCustomer.Visibility = Visibility.Collapsed;
            BorderUpdCustomer.Visibility = Visibility.Visible;

            ShowPanel(GridCustomers);
        }

        private void TextBoxSearchCustomer_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ComboBoxSearchCust.SelectedItem != null && ComboBoxSearchCust.SelectedIndex == 0)
            {
                _buldcCustomerssSearchCollection =
                    new ObservableCollection<CUSTOMER>(
                        BuildingCompany.CUSTOMERS.Where(x => SqlFunctions.StringConvert((double)x.customerId)
                            .TrimStart().StartsWith(TextBoxSearchCustomer.Text)));
                GridCustomers.ItemsSource = _buldcCustomerssSearchCollection;

                if (_buldcCustomerssSearchCollection == null)
                {
                    GridCustomers.ItemsSource = _buldCustomers;
                }
            }

            if (ComboBoxSearchCust.SelectedItem != null && ComboBoxSearchCust.SelectedIndex == 1)
            {
                _buldcCustomerssSearchCollection =
                    new ObservableCollection<CUSTOMER>(
                        BuildingCompany.CUSTOMERS.Where(x => x.customerName.Contains(TextBoxSearchCustomer.Text)));
                GridCustomers.ItemsSource = _buldcCustomerssSearchCollection;

                if (_buldcCustomerssSearchCollection == null)
                {
                    GridCustomers.ItemsSource = _buldCustomers;
                }
            }
            if (ComboBoxSearchCust.SelectedItem != null && ComboBoxSearchCust.SelectedIndex == 2)
            {
                _buldcCustomerssSearchCollection =
                    new ObservableCollection<CUSTOMER>(
                        BuildingCompany.CUSTOMERS.Where(x => x.contatctFirstName.Contains(TextBoxSearchCustomer.Text)));
                GridCustomers.ItemsSource = _buldcCustomerssSearchCollection;

                if (_buldcCustomerssSearchCollection == null)
                {
                    GridCustomers.ItemsSource = _buldCustomers;
                }
            }
            if (ComboBoxSearchCust.SelectedItem != null && ComboBoxSearchCust.SelectedIndex == 3)
            {
                _buldcCustomerssSearchCollection =
                    new ObservableCollection<CUSTOMER>(
                        BuildingCompany.CUSTOMERS.Where(x => x.contactLastName.Contains(TextBoxSearchCustomer.Text)));
                GridCustomers.ItemsSource = _buldcCustomerssSearchCollection;

                if (_buldcCustomerssSearchCollection == null)
                {
                    GridCustomers.ItemsSource = _buldCustomers;
                }
            }
            if (ComboBoxSearchCust.SelectedItem != null && ComboBoxSearchCust.SelectedIndex == 4)
            {
                _buldcCustomerssSearchCollection =
                    new ObservableCollection<CUSTOMER>(
                        BuildingCompany.CUSTOMERS.Where(x => x.country.Contains(TextBoxSearchCustomer.Text)));
                GridCustomers.ItemsSource = _buldcCustomerssSearchCollection;

                if (_buldcCustomerssSearchCollection == null)
                {
                    GridCustomers.ItemsSource = _buldCustomers;
                }
            }
            if (ComboBoxSearchCust.SelectedItem != null && ComboBoxSearchCust.SelectedIndex == 5)
            {
                _buldcCustomerssSearchCollection =
                    new ObservableCollection<CUSTOMER>(
                        BuildingCompany.CUSTOMERS.Where(x => x.city.Contains(TextBoxSearchCustomer.Text)));
                GridCustomers.ItemsSource = _buldcCustomerssSearchCollection;

                if (_buldcCustomerssSearchCollection == null)
                {
                    GridCustomers.ItemsSource = _buldCustomers;
                }
            }
            if (ComboBoxSearchCust.SelectedItem != null && ComboBoxSearchCust.SelectedIndex == 6)
            {
                _buldcCustomerssSearchCollection =
                    new ObservableCollection<CUSTOMER>(
                        BuildingCompany.CUSTOMERS.Where(x => x.addresLine.Contains(TextBoxSearchCustomer.Text)));
                GridCustomers.ItemsSource = _buldcCustomerssSearchCollection;

                if (_buldcCustomerssSearchCollection == null)
                {
                    GridCustomers.ItemsSource = _buldCustomers;
                }
            }
            if (ComboBoxSearchCust.SelectedItem != null && ComboBoxSearchCust.SelectedIndex == 7)
            {
                _buldcCustomerssSearchCollection =
                    new ObservableCollection<CUSTOMER>(
                        BuildingCompany.CUSTOMERS.Where(x => x.addresLine.Contains(TextBoxSearchCustomer.Text)));
                GridCustomers.ItemsSource = _buldcCustomerssSearchCollection;

                if (_buldcCustomerssSearchCollection == null)
                {
                    GridCustomers.ItemsSource = _buldCustomers;
                }
            }
        }

        private void updCustomerButton_Click(object sender, RoutedEventArgs e)
        {

            var itemsUpd = (CUSTOMER)GridCustomers.SelectedItem;
            try
            {
                itemsUpd.customerName = updCustname.Text;
                itemsUpd.contatctFirstName = updCustFirstName.Text;
                itemsUpd.contactLastName = updCustSurname.Text;
                itemsUpd.contactPhone = empEmailUpd.Text;
                itemsUpd.country = (updCustCountry.Text);
                itemsUpd.city = (updCustCity.Text);
                itemsUpd.addresLine = updCustAdress.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевіоте дані");
                return;
            }
          
            try
            {
                BuildingCompany.Entry(itemsUpd).State = EntityState.Modified;
                BuildingCompany.SaveChanges();
                MessageBox.Show("Зміни прийнято");
                _buldCustomers = new ObservableCollection<CUSTOMER>(BuildingCompany.CUSTOMERS);
                GridCustomers.ItemsSource = _buldCustomers;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
            }

        }

        private void delSpecialityButt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var itemsDeleted = (SPECIALITY)GridSpeciality.SelectedItem;
                BuildingCompany.SPECIALITies.Remove(itemsDeleted);
                _buldSpecialitys.Remove(itemsDeleted);
                GridSpeciality.ItemsSource = _buldSpecialitys;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Можливо, Ви не вибрали елемент");
            }
            BuildingCompany.SaveChanges();
        }

        private void delUsedMaterialButt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var itemsDeleted = (used_materials)GridSUsedMaterials.SelectedItem;
                BuildingCompany.used_materials.Remove(itemsDeleted);
                _buldusedMaterials.Remove(itemsDeleted);
                GridSUsedMaterials.ItemsSource = _buldusedMaterials;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Можливо, Ви не вибрали елемент");
            }
            BuildingCompany.SaveChanges();
        }

        private void UpdUsedMaterial_Click(object sender, RoutedEventArgs e)
        {

            var itemsUpd = (used_materials)GridSUsedMaterials.SelectedItem;
            var UnitIdTemp = _buldsUnits.FirstOrDefault(f => f.name == UpdUsedMaterrialUnit.Text);
            var SupplierIdTemp = _buldsSupplierss.FirstOrDefault(f => f.companyName == UpdUsedMaterrialsuppilers.Text);
            var MaterialIdTemp = _buldMaterials.FirstOrDefault(f => f.name == UpdUsedMaterrialMaterial.Text);
            var ObjectTemp = _buldObjecs.FirstOrDefault(f => f.idObject == int.Parse(UpdUsedMaterrialObj.Text));

            try
            {
                if (UpdUsedMaterrialObj.Text != "")
                {
                    itemsUpd.OBJECT = ObjectTemp;
                }
                if (UpdUsedMaterrial_KilkMaterial.Text != "")
                {
                    itemsUpd.number = Int32.Parse(UpdUsedMaterrial_KilkMaterial.Text);
                }
                if (UpdUsedMaterrial_Price.Text != "")
                {
                    itemsUpd.uniPrice = Int32.Parse(UpdUsedMaterrial_Price.Text); ;
                }

                if (UpdUsedMaterrialUnit != null)
                {
                    itemsUpd.UNIT = UnitIdTemp;
                }
                if (UpdUsedMaterrialsuppilers.SelectedItem != null)
                {
                    itemsUpd.SUPPLIER = SupplierIdTemp;
                }
                if (UpdUsedMaterrialMaterial.SelectedItem != null)
                {
                    itemsUpd.MATERIAL = MaterialIdTemp;
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
            }
           
            try
            {
                BuildingCompany.Entry(itemsUpd).State = EntityState.Modified;
                BuildingCompany.SaveChanges();
                MessageBox.Show("Зміни прийнято");
                _buldusedMaterials = new ObservableCollection<used_materials>(BuildingCompany.used_materials);
                GridEmployees.ItemsSource = _buldusedMaterials;
                // GridObjects.SelectedItem = customerIdTemp;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
            }

        }

        private void AddUsedMaterialHiden_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridSUsedMaterials);
        }

        private void AddUsedMaterialHiden1_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridSUsedMaterials);
        }

        private void addUsedMaterialButt_Click(object sender, RoutedEventArgs e)
        {
            BorderUpdUsedMaterial.Visibility = Visibility.Collapsed;
            BorderAddUsedMaterial.Visibility = Visibility.Visible;

            ShowPanel(GridSUsedMaterials);
        }

        private void updUsedMaterialButt_Click(object sender, RoutedEventArgs e)
        {
            BorderUpdUsedMaterial.Visibility = Visibility.Visible;
            BorderAddUsedMaterial.Visibility = Visibility.Collapsed;

            ShowPanel(GridSUsedMaterials);
        }

        private void TextBoxSearchUsedMaerial_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ComboBoxSpecialityOption.SelectedItem != null && ComboBoxSpecialityOption.SelectedIndex == 0)
            {
                _bulduUsedMaterialsesSearchCollection =
                    new ObservableCollection<used_materials>(
                        BuildingCompany.used_materials.Where(x => SqlFunctions.StringConvert((double)x.used_Material_Id)
                            .TrimStart().StartsWith(TextBoxSearchUsedMaerial.Text)));
                GridSUsedMaterials.ItemsSource = _bulduUsedMaterialsesSearchCollection;

                if (_bulduUsedMaterialsesSearchCollection == null)
                {
                    GridSUsedMaterials.ItemsSource = _buldusedMaterials;
                }
            }
            if (ComboBoxSpecialityOption.SelectedItem != null && ComboBoxSpecialityOption.SelectedIndex == 1)
            {
                _bulduUsedMaterialsesSearchCollection =
                    new ObservableCollection<used_materials>(
                        BuildingCompany.used_materials.Where(x => SqlFunctions.StringConvert((double)x.idObject)
                            .TrimStart().StartsWith(TextBoxSearchUsedMaerial.Text)));
                GridSUsedMaterials.ItemsSource = _bulduUsedMaterialsesSearchCollection;

                if (_bulduUsedMaterialsesSearchCollection == null)
                {
                    GridSUsedMaterials.ItemsSource = _buldusedMaterials;
                }
            }
            if (ComboBoxSpecialityOption.SelectedItem != null && ComboBoxSpecialityOption.SelectedIndex == 2)
            {
                _bulduUsedMaterialsesSearchCollection =
                    new ObservableCollection<used_materials>(
                        BuildingCompany.used_materials.Where(x => SqlFunctions.StringConvert((double)x.idUnit)
                            .TrimStart().StartsWith(TextBoxSearchUsedMaerial.Text)));
                GridSUsedMaterials.ItemsSource = _bulduUsedMaterialsesSearchCollection;

                if (_bulduUsedMaterialsesSearchCollection == null)
                {
                    GridSUsedMaterials.ItemsSource = _buldusedMaterials;
                }
            }
            if (ComboBoxSpecialityOption.SelectedItem != null && ComboBoxSpecialityOption.SelectedIndex == 3)
            {
                _bulduUsedMaterialsesSearchCollection =
                    new ObservableCollection<used_materials>(
                        BuildingCompany.used_materials.Where(x => SqlFunctions.StringConvert((double)x.number)
                            .TrimStart().StartsWith(TextBoxSearchUsedMaerial.Text)));
                GridSUsedMaterials.ItemsSource = _bulduUsedMaterialsesSearchCollection;

                if (_bulduUsedMaterialsesSearchCollection == null)
                {
                    GridSUsedMaterials.ItemsSource = _buldusedMaterials;
                }
            }
            if (ComboBoxSpecialityOption.SelectedItem != null && ComboBoxSpecialityOption.SelectedIndex == 4)
            {
                _bulduUsedMaterialsesSearchCollection =
                    new ObservableCollection<used_materials>(
                        BuildingCompany.used_materials.Where(x => SqlFunctions.StringConvert((double)x.uniPrice)
                            .TrimStart().StartsWith(TextBoxSearchUsedMaerial.Text)));
                GridSUsedMaterials.ItemsSource = _bulduUsedMaterialsesSearchCollection;

                if (_bulduUsedMaterialsesSearchCollection == null)
                {
                    GridSUsedMaterials.ItemsSource = _buldusedMaterials;
                }
            }
            if (ComboBoxSpecialityOption.SelectedItem != null && ComboBoxSpecialityOption.SelectedIndex == 5)
            {
                _bulduUsedMaterialsesSearchCollection =
                    new ObservableCollection<used_materials>(
                        BuildingCompany.used_materials.Where(x => SqlFunctions.StringConvert((double)x.supplierID)
                            .TrimStart().StartsWith(TextBoxSearchUsedMaerial.Text)));
                GridSUsedMaterials.ItemsSource = _bulduUsedMaterialsesSearchCollection;

                if (_bulduUsedMaterialsesSearchCollection == null)
                {
                    GridSUsedMaterials.ItemsSource = _buldusedMaterials;
                }
            }
            if (ComboBoxSpecialityOption.SelectedItem != null && ComboBoxSpecialityOption.SelectedIndex == 6)
            {
                _bulduUsedMaterialsesSearchCollection =
                    new ObservableCollection<used_materials>(
                        BuildingCompany.used_materials.Where(x => SqlFunctions.StringConvert((double)x.idMatterial)
                            .TrimStart().StartsWith(TextBoxSearchUsedMaerial.Text)));
                GridSUsedMaterials.ItemsSource = _bulduUsedMaterialsesSearchCollection;

                if (_bulduUsedMaterialsesSearchCollection == null)
                {
                    GridSUsedMaterials.ItemsSource = _buldusedMaterials;
                }
            }
        }

        private void updMaterialBu1t1_Click(object sender, RoutedEventArgs e)
        {
            var itemsUpd = (MATERIAL)GridMaterials.SelectedItem;

            itemsUpd.name = UpdmaterialName1.Text;
            itemsUpd.integer_ = UpdIntger.Text;

            try
            {
                BuildingCompany.Entry(itemsUpd).State = EntityState.Modified;
                BuildingCompany.SaveChanges();
                MessageBox.Show("Зміни прийнято");
                _buldMaterials = new ObservableCollection<MATERIAL>(BuildingCompany.MATERIALs);
                GridMaterials.ItemsSource = _buldMaterials;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
            }
        }

        private void delMaterialButt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var itemsDeleted = (MATERIAL)GridMaterials.SelectedItem;
                BuildingCompany.MATERIALs.Remove(itemsDeleted);
                _buldMaterials.Remove(itemsDeleted);
                GridMaterials.ItemsSource = _buldMaterials;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Можливо, Ви не вибрали елемент");
            }
            BuildingCompany.SaveChanges();
        }

        private void addMaterialBu1t_Hiden_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridMaterials);
        }

        private void UpdMaterialBu1t_Hiden1_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridMaterials);
        }

        private void addMaterialButt_Click(object sender, RoutedEventArgs e)
        {
            BorderUpdMaterial.Visibility = Visibility.Collapsed;
            BorderAddMaterial.Visibility = Visibility.Visible;

            ShowPanel(GridMaterials);
        }

        private void updMaterialButt_Click(object sender, RoutedEventArgs e)
        {
            BorderUpdMaterial.Visibility = Visibility.Visible;
            BorderAddMaterial.Visibility = Visibility.Collapsed;

            ShowPanel(GridMaterials);
        }

        private void addNewSuppliersBut_Click(object sender, RoutedEventArgs e)
        {
            var newIdSupp = BuildingCompany.SUPPLIERS.Max(u => u.supplierID) + 1;
            
            SUPPLIER temp = new SUPPLIER();
            try
            {
                if (UsedMaterrialOb1j.Text != "" || UsedMaterrial_KilkMaterial.Text == "" || UsedMaterrial_Price.Text == "")
                {
                    MessageBox.Show("Заповність усі поля");
                    return;
                }

                temp.supplierID = newIdSupp;
                temp.companyName = SupplierCompanyName.Text;
                temp.contactName = SupplierContatName.Text;
                temp.contactPhone = empText2.Text;
                temp.country = SupplierCountry.Text;
                temp.address = SupplierPhone.Text;
                temp.fax = SupplierFax.Text;
                temp.homePage = SupplierWebPage.Text;

            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
            }
            try
            {
                {
                    BuildingCompany.SUPPLIERS.Add(temp);
                    _buldsSupplierss.Add(temp);
                    BuildingCompany.SaveChanges();
                    MessageBox.Show("Додано нового постачальника" + " №" + newIdSupp.ToString());
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Вибачте, помилка у додаванні працівника, перевірте правильність даних");
            }

        }

        private void addNewSuppliersBut1_Click(object sender, RoutedEventArgs e)
        {

            var itemsUpd = (SUPPLIER)GridSuppliers.SelectedItem;

            itemsUpd.companyName = UpdSupplierCompanyName1.Text;
            itemsUpd.contactName = UpdSupplierContatName1.Text;
            itemsUpd.contactPhone = UpdSupplierPhone1.Text;
            itemsUpd.country = (UpdSupplierCountry1.Text);
            itemsUpd.address = (UpdSupplierAddres1.Text);
            itemsUpd.homePage = UpdSupplierWebPage1.Text;
            itemsUpd.fax = UpdSupplierFax1.Text;
            try
            {
                BuildingCompany.Entry(itemsUpd).State = EntityState.Modified;
                BuildingCompany.SaveChanges();
                MessageBox.Show("Зміни прийнято");
                _buldsSupplierss = new ObservableCollection<SUPPLIER>(BuildingCompany.SUPPLIERS);
                GridSuppliers.ItemsSource = _buldsSupplierss;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
            }

        }

        private void UpdNewSuppliersBut_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridSuppliers);
        }

        private void UpdNewSuppliersBut1_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridSuppliers);
        }

        private void addSuppliersBut_Click(object sender, RoutedEventArgs e)
        {
            BorderUpdSupplier.Visibility = Visibility.Collapsed;
            BorderAddSupplier.Visibility = Visibility.Visible;

            ShowPanel(GridSuppliers);
        }

        private void updSuppliersBut_Click(object sender, RoutedEventArgs e)
        {
            BorderUpdSupplier.Visibility = Visibility.Visible;
            BorderAddSupplier.Visibility = Visibility.Collapsed;

            ShowPanel(GridSuppliers);
        }

        private void delSuppliersBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var itemsDeleted = (SUPPLIER)GridSuppliers.SelectedItem;
                BuildingCompany.SUPPLIERS.Remove(itemsDeleted);
                _buldsSupplierss.Remove(itemsDeleted);
                GridSuppliers.ItemsSource = _buldsSupplierss;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Можливо, Ви не вибрали елемент");
            }
            BuildingCompany.SaveChanges();
        }

        private void TextBoxSearchSuppliers_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (ComboBoxOptionSupplierSearch.SelectedItem != null && ComboBoxOptionSupplierSearch.SelectedIndex == 0)
            {
                _buldSupplierssearchCollection =
                    new ObservableCollection<SUPPLIER>(
                         BuildingCompany.SUPPLIERS.Where(x => SqlFunctions.StringConvert((double)x.supplierID)
                            .TrimStart().StartsWith(TextBoxSearchSuppliers.Text)));
                GridSuppliers.ItemsSource = _buldSupplierssearchCollection;
                if (_buldSupplierssearchCollection == null)
                {
                    GridSuppliers.ItemsSource = _buldsSupplierss;
                }
            }

            if (ComboBoxOptionSupplierSearch.SelectedItem != null && ComboBoxOptionSupplierSearch.SelectedIndex == 1)
            {
                _buldSupplierssearchCollection =
                    new ObservableCollection<SUPPLIER>(
                        _buldsSupplierss.Where(f => f.companyName.Contains(TextBoxSearchSuppliers.Text)));
                GridSuppliers.ItemsSource = _buldSupplierssearchCollection;
                if (_buldSupplierssearchCollection == null)
                {
                    GridSuppliers.ItemsSource = _buldsSupplierss;
                }
            }

            if (ComboBoxOptionSupplierSearch.SelectedItem != null && ComboBoxOptionSupplierSearch.SelectedIndex == 2)
            {
                _buldSupplierssearchCollection =
                    new ObservableCollection<SUPPLIER>(
                        _buldsSupplierss.Where(f => f.contactName.Contains(TextBoxSearchSuppliers.Text)));
                GridSuppliers.ItemsSource = _buldSupplierssearchCollection;
                if (_buldSupplierssearchCollection == null)
                {
                    GridSuppliers.ItemsSource = _buldsSupplierss;
                }
            }
            if (ComboBoxOptionSupplierSearch.SelectedItem != null && ComboBoxOptionSupplierSearch.SelectedIndex == 3)
            {
                _buldSupplierssearchCollection =
                    new ObservableCollection<SUPPLIER>(
                        _buldsSupplierss.Where(f => f.country.Contains(TextBoxSearchSuppliers.Text)));
                GridSuppliers.ItemsSource = _buldSupplierssearchCollection;
                if (_buldSupplierssearchCollection == null)
                {
                    GridSuppliers.ItemsSource = _buldsSupplierss;
                }
            }
            if (ComboBoxOptionSupplierSearch.SelectedItem != null && ComboBoxOptionSupplierSearch.SelectedIndex == 4)
            {
                _buldSupplierssearchCollection =
                    new ObservableCollection<SUPPLIER>(
                        _buldsSupplierss.Where(f => f.address.Contains(TextBoxSearchSuppliers.Text)));
                GridSuppliers.ItemsSource = _buldSupplierssearchCollection;
                if (_buldSupplierssearchCollection == null)
                {
                    GridSuppliers.ItemsSource = _buldsSupplierss;
                }
            }
            if (ComboBoxOptionSupplierSearch.SelectedItem != null && ComboBoxOptionSupplierSearch.SelectedIndex == 5)
            {
                _buldSupplierssearchCollection =
                    new ObservableCollection<SUPPLIER>(
                        _buldsSupplierss.Where(f => f.contactPhone.Contains(TextBoxSearchSuppliers.Text)));
                GridSuppliers.ItemsSource = _buldSupplierssearchCollection;
                if (_buldSupplierssearchCollection == null)
                {
                    GridSuppliers.ItemsSource = _buldsSupplierss;
                }
            }
            if (ComboBoxOptionSupplierSearch.SelectedItem != null && ComboBoxOptionSupplierSearch.SelectedIndex == 6)
            {
                _buldSupplierssearchCollection =
                    new ObservableCollection<SUPPLIER>(
                        _buldsSupplierss.Where(f => f.fax.Contains(TextBoxSearchSuppliers.Text)));
                GridSuppliers.ItemsSource = _buldSupplierssearchCollection;
                if (_buldSupplierssearchCollection == null)
                {
                    GridSuppliers.ItemsSource = _buldsSupplierss;
                }
            }
            if (ComboBoxOptionSupplierSearch.SelectedItem != null && ComboBoxOptionSupplierSearch.SelectedIndex == 7)
            {
                _buldSupplierssearchCollection =
                    new ObservableCollection<SUPPLIER>(
                        _buldsSupplierss.Where(f => f.homePage.Contains(TextBoxSearchSuppliers.Text)));
                GridSuppliers.ItemsSource = _buldSupplierssearchCollection;
                if (_buldSupplierssearchCollection == null)
                {
                    GridSuppliers.ItemsSource = _buldsSupplierss;
                }
            }
        }

        private void addOfficeBut_Click(object sender, RoutedEventArgs e)
        {
            var newIdCust = BuildingCompany.OFFICES.Max(u => u.officeId) + 1;
            OFFICE temp = new OFFICE();

            try
            {
                temp.officeId = newIdCust;
                temp.city = OfficeNameAdd.Text;           
                temp.country = OfficeNameAdd_Copy.Text;
                temp.adressLine = OfficeNameAdd_Copy1.Text;
                temp.phone = OfficeNameAdd_Copy2.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
                return;
            }

            try
            {
                {
                    BuildingCompany.OFFICES.Add(temp);
                    BuildingCompany.SaveChanges();
                    _buldOfiOfficess.Add(temp);
                    GridOffices.ItemsSource = _buldOfiOfficess;
                    MessageBox.Show("Додано новий офіс" + " №" + newIdCust.ToString());
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Вибачте, помилка у додаванні замовника, перевірте правильність даних");
            }
        }

        private void addOfficeBut1_Click(object sender, RoutedEventArgs e)
        {
            var itemsUpd = (OFFICE)GridOffices.SelectedItem;
            try
            {
                itemsUpd.city = OfficeNameAdd1.Text;
                itemsUpd.country = OfficeNameAdd_Copy3.Text;
                itemsUpd.adressLine = OfficeNameAdd_Copy4.Text;             
                itemsUpd.phone = OfficeNameAdd_Copy5.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевіоте дані");
                return;
            }

            try
            {
                BuildingCompany.Entry(itemsUpd).State = EntityState.Modified;
                BuildingCompany.SaveChanges();
                MessageBox.Show("Зміни прийнято");
                _buldOfiOfficess = new ObservableCollection<OFFICE>(BuildingCompany.OFFICES);
                GridOffices.ItemsSource = _buldOfiOfficess;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
            }
        }

        private void Hidd1enAddWorkTypeBut_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridOffices);
        }

        private void Hidd1enAddWorkTypeBut1_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridOffices);
        }

        private void addWtBu1tt_Click(object sender, RoutedEventArgs e)
        {
            Border1AddWt.Visibility = Visibility.Collapsed;
            Border1AddWt_Copy.Visibility = Visibility.Visible;

            ShowPanel(GridOffices);
        }

        private void updWtB1utt_Click(object sender, RoutedEventArgs e)
        {
            Border1AddWt.Visibility = Visibility.Visible;
            Border1AddWt_Copy.Visibility = Visibility.Collapsed;

            ShowPanel(GridOffices);
        }

        private void TextBoxSea11rchWt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ComboBoxW11tOption.SelectedItem != null && ComboBoxW11tOption.SelectedIndex == 0)
            {
                _buldOfficessearchCollection =
                    new ObservableCollection<OFFICE>(
                        BuildingCompany.OFFICES.Where(x => SqlFunctions.StringConvert((double)x.officeId)
                            .TrimStart().StartsWith(TextBoxSea11rchWt.Text)));
                GridOffices.ItemsSource = _buldOfficessearchCollection;

                if (_buldOfficessearchCollection == null)
                {
                    GridOffices.ItemsSource = _buldOfiOfficess;
                }
            }

            if (ComboBoxWtOption.SelectedItem != null && ComboBoxWtOption.SelectedIndex == 1)
            {
                _buldOfficessearchCollection =
                    new ObservableCollection<OFFICE>(
                        BuildingCompany.OFFICES.Where(x => x.city.Contains(TextBoxSea11rchWt.Text)));
                GridOffices.ItemsSource = _buldOfficessearchCollection;

                if (_buldOfficessearchCollection == null)
                {
                    GridOffices.ItemsSource = _buldOfiOfficess;
                }
            }
        }

        private void addEmpButt_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxAddSpecialityEmp.SelectedItem == null)
            {
                MessageBox.Show("Виберіть спеціальність");
                return;
            }
            
            var itemsUpd = (EMPLOYEE)GridEmployees.SelectedItem;
            var specialityTemp = _buldSpecialitys.ToList().First(f => f.name == comboBoxAddSpecialityEmp.Text);
            try
            {
               
                itemsUpd.SPECIALITies.Add(specialityTemp);

                _buildEmployees = new ObservableCollection<EMPLOYEE>(BuildingCompany.EMPLOYEES);
                // GridEmployees.ItemsSource = _buildEmployees;

                BuildingCompany.Entry(itemsUpd).State = EntityState.Modified;
                BuildingCompany.SaveChanges();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність");
            }
    

            // GridEmployees.SelectedItem = buildingCompany.EMPLOYEES.ToList().First(f => f.employeeId == itemsUpd.employeeId);
            _buildEmployees = new ObservableCollection<EMPLOYEE>(BuildingCompany.EMPLOYEES);
            GridEmployees.ItemsSource = _buildEmployees;
            MessageBox.Show("Додано спеціальність " + specialityTemp.name);

                GridEmployees.Items.Refresh();
            }

        private void EmpClearSpeiality_Click(object sender, RoutedEventArgs e)
        {
            var itemsUpd = (EMPLOYEE)GridEmployees.SelectedItem;

            try
            {
                _buildEmployees = new ObservableCollection<EMPLOYEE>(BuildingCompany.EMPLOYEES);

                itemsUpd.SPECIALITies.Clear();
                BuildingCompany.Entry(itemsUpd).State = EntityState.Modified;
                BuildingCompany.SaveChanges();

                GridEmployees.ItemsSource = _buildEmployees;
               
                MessageBox.Show("Видалено спеціальністі");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
                return;
            }
        }

        private void addUnitButt1_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxAddUnitEmp.SelectedItem == null)
            {
                MessageBox.Show("Виберіть підрозділ");
                return;
            }

            var itemsUpd = (EMPLOYEE)GridEmployees.SelectedItem;

            var unitTemp = _buldsUnits.ToList().First(f => f.name == comboBoxAddUnitEmp.Text);

            itemsUpd.UNITS.Add(unitTemp);

            BuildingCompany.Entry(itemsUpd).State = EntityState.Modified;
            BuildingCompany.SaveChanges();

            _buildEmployees = new ObservableCollection<EMPLOYEE>(BuildingCompany.EMPLOYEES);
            //    GridEmployees.DataContext = _buildEmployees;
            //     GridEmployees.Items.Refresh();
            GridEmployees.SelectedItem = BuildingCompany.EMPLOYEES.ToList().First(f => f.employeeId == itemsUpd.employeeId);
            //  GridEmployees.SelectedItem = buildingCompany.EMPLOYEES.ToList().First(f => f.employeeId == itemsUpd.employeeId);
            MessageBox.Show("Додано працівника у підрозділ" + unitTemp.name);
            GridEmployees.Items.Refresh();
        }

        private void EmpClearUnit_Click(object sender, RoutedEventArgs e)
        {
            var itemsUpd = (EMPLOYEE)GridEmployees.SelectedItem;
            try
            {
                _buildEmployees = new ObservableCollection<EMPLOYEE>(BuildingCompany.EMPLOYEES);

                itemsUpd.UNITS.Clear();
                BuildingCompany.Entry(itemsUpd).State = EntityState.Modified;
                BuildingCompany.SaveChanges();

                GridEmployees.ItemsSource = _buildEmployees;

                MessageBox.Show("Видалено підрозділи");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
                return;
            }

        }

        private void addBDuser_Click(object sender, RoutedEventArgs e)
        {

            if (empNameUpd3.Text == "")
            {
                MessageBox.Show("Виберіть елемент");
                return;
            }

            var itemsUpd = (EMPLOYEE)GridEmployees.SelectedItem;

            if (emPasswp.Text == "")
            {
                MessageBox.Show("Заповніть дані");
                return;
            }
           
                itemsUpd.userType = comboBDwork.Text.Trim();
           
            itemsUpd.password = emPasswp.Text;

            try
            {
                BuildingCompany.Entry(itemsUpd).State = EntityState.Modified;
                BuildingCompany.SaveChanges();
                MessageBox.Show("Зміни прийнято");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
            }
        }

        private void EmpClearUnit1_Click(object sender, RoutedEventArgs e)
        {
            var itemsUpd = (EMPLOYEE)GridEmployees.SelectedItem;
           
            
                itemsUpd.userType = null;
                itemsUpd.password = null;

            try
            {
                BuildingCompany.Entry(itemsUpd).State = EntityState.Modified;
                BuildingCompany.SaveChanges();
                MessageBox.Show("Зміни прийнято");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
            }
        }

        private void add1OfficeBut_Click(object sender, RoutedEventArgs e)
        {
            var newIdCust = BuildingCompany.UNITS.Max(u => u.idUnit) + 1;
            UNIT temp = new UNIT();

            try
            {
                temp.idUnit = newIdCust;
                temp.name = Of1ficeNameAdd.Text;
                temp.comments = Off1iceNameAdd_Copy.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
                return;
            }

            try
            {
                {
                    BuildingCompany.UNITS.Add(temp);
                    BuildingCompany.SaveChanges();
                    _buldsUnits.Add(temp);
                    GridUnits.ItemsSource = _buldsUnits;
                    MessageBox.Show("Додано новий підрозділ" + " №" + newIdCust.ToString());
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Вибачте, помилка у додаванні, перевірте правильність даних");
            }
        }

        private void addOfficeBu1t1_Click(object sender, RoutedEventArgs e)
        {
            var itemsUpd = (UNIT)GridUnits.SelectedItem;
            try
            {
                itemsUpd.name = Office1NameAdd1.Text;
                itemsUpd.comments = OfficeNameA1dd_Copy3.Text;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте дані");
                return;
            }

            try
            {
                BuildingCompany.Entry(itemsUpd).State = EntityState.Modified;
                BuildingCompany.SaveChanges();
                MessageBox.Show("Зміни прийнято");
                _buldsUnits = new ObservableCollection<UNIT>(BuildingCompany.UNITS);
                GridUnits.ItemsSource = _buldsUnits;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Перевірте правильність даних");
            }
        }

        private void TextBoxSearcUnit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ComboxUnitOption.SelectedItem != null && ComboxUnitOption.SelectedIndex == 0)
            {
                _buldUnitsearchCollection =
                    new ObservableCollection<UNIT>(
                        BuildingCompany.UNITS.Where(x => SqlFunctions.StringConvert((double)x.idUnit)
                            .TrimStart().StartsWith(TextBoxSearcUnit.Text)));
                GridUnits.ItemsSource = _buldUnitsearchCollection;

                if (_buldUnitsearchCollection == null)
                {
                    GridUnits.ItemsSource = _buldsUnits;
                }
            }

            if (ComboxUnitOption.SelectedItem != null && ComboxUnitOption.SelectedIndex == 1)
            {
                _buldUnitsearchCollection =
                    new ObservableCollection<UNIT>(
                        BuildingCompany.UNITS.Where(x => x.name.Contains(TextBoxSearcUnit.Text)));
                GridUnits.ItemsSource = _buldUnitsearchCollection;

                if (_buldUnitsearchCollection == null)
                {
                    GridUnits.ItemsSource = _buldsUnits;
                }
            }
        }

        private void Hid1d1enAddWorkTypeBut_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridUnits);
        }

        private void Hidd1enAdd1WorkTypeBut1_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridUnits);
        }

        private void addUnitBu1tt_Click(object sender, RoutedEventArgs e)
        {
            BorderUnitAdd.Visibility = Visibility.Collapsed;
            BorderUpdUnit.Visibility = Visibility.Visible;

            ShowPanel(GridUnits);
        }

        private void updUnitB1utt_Click(object sender, RoutedEventArgs e)
        {
            BorderUnitAdd.Visibility = Visibility.Visible;
            BorderUpdUnit.Visibility = Visibility.Collapsed;

            ShowPanel(GridUnits);
        }

        private void hidenEmpUpd1_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridEmployees);
        }

        private void hidenEmpUpd2_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridEmployees);
        }

        private void hidenEmpUpd3_Click(object sender, RoutedEventArgs e)
        {
            HidenPanel(GridEmployees);
        }

        private void addSpecialityEmpShow_Click(object sender, RoutedEventArgs e)
        {
            BorderAddEmp.Visibility = Visibility.Collapsed;
            BorderUpdAddSpeciality.Visibility = Visibility.Visible;
            BorderUpdAddSpeciality_Copy.Visibility = Visibility.Collapsed;
            BorderUpdAddSpeciality_Copy1.Visibility = Visibility.Collapsed;
            BorderUpdEmp.Visibility = Visibility.Collapsed;

            ShowPanel(GridEmployees);
        }

        private void addUnitEmpShow_Click(object sender, RoutedEventArgs e)
        {
            BorderAddEmp.Visibility = Visibility.Collapsed;
            BorderUpdAddSpeciality.Visibility = Visibility.Collapsed;
            BorderUpdAddSpeciality_Copy.Visibility = Visibility.Visible;
            BorderUpdAddSpeciality_Copy1.Visibility = Visibility.Collapsed;
            BorderUpdEmp.Visibility = Visibility.Collapsed;

            ShowPanel(GridEmployees);
        }

        private void addInBDEmpShow_Click(object sender, RoutedEventArgs e)
        {
            BorderAddEmp.Visibility = Visibility.Collapsed;
            BorderUpdAddSpeciality.Visibility = Visibility.Collapsed;
            BorderUpdAddSpeciality_Copy.Visibility = Visibility.Collapsed;
            BorderUpdAddSpeciality_Copy1.Visibility = Visibility.Visible;
            BorderUpdEmp.Visibility = Visibility.Collapsed;

            ShowPanel(GridEmployees);
        }

        private void priceObj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var item = (OBJECT)GridObjects.SelectedItem;
                decimal tempPriceDecimal = 0;
                foreach (var material in _buldusedMaterials.Where(f => f.idObject == item.idObject))
                {
                    var temp = ((double) material.uniPrice * 0.28 + (double) material.uniPrice);
                    tempPriceDecimal += (decimal)temp;
                }
                item.price = tempPriceDecimal;
                item.income = decimal.Parse(((double)tempPriceDecimal * 0.07).ToString());
            }
            catch (Exception exception)
            {
                MessageBox.Show("Можливо, ви не вибрали елемент");
            }
            BuildingCompany.SaveChanges();
            //GridObjects.Items.Refresh();
        }

        private void reportObjManager_Click(object sender, RoutedEventArgs e)
        {
            FormObj neFormReport1 = new FormObj();
            neFormReport1.Show();
        }

        private void reportCustomers_Click(object sender, RoutedEventArgs e)
        {
            FormCustReport neFormReport1 = new FormCustReport();
            neFormReport1.Show();
        }

        private void reportsUP_Click(object sender, RoutedEventArgs e)
        {
            FormSuppliersReport neFormReport1 = new FormSuppliersReport();
            neFormReport1.Show();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Help neFormReport1 = new Help();
            neFormReport1.Show();
        }

        private void priceObj_Copy_Click(object sender, RoutedEventArgs e)
        {
            foreach (var VARIABLE in _buldObjecs)
            {
                decimal tempPriceDecimal = 0;
                foreach (var material in _buldusedMaterials.Where(f => f.idObject == VARIABLE.idObject))
                {
                    var temp = ((double)material.uniPrice * 0.28 + (double)material.uniPrice);
                    tempPriceDecimal += (decimal)temp;
                }
                VARIABLE.price = tempPriceDecimal;
                VARIABLE.income = decimal.Parse(((double)tempPriceDecimal * 0.07).ToString());
            }
            BuildingCompany.SaveChanges();
            GridObjects.Items.Refresh();
        }

        private void ReportEmp_Click(object sender, RoutedEventArgs e)
        {
            FormOfficeReport neFormReport1 = new FormOfficeReport();
            neFormReport1.Show();
        }
    }
    }
    
    
    

    
    

