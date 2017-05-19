using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Building_Company
{
    class CustomerNameConverter:IValueConverter
    {
        KR_BD2Entities buildingCompany = new KR_BD2Entities();
        private ObservableCollection<CUSTOMER> _buldCustomers;
      

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                value = 1;
            }
            _buldCustomers = new ObservableCollection<CUSTOMER>(buildingCompany.CUSTOMERS);
            int id = (int)value;
            var name = _buldCustomers.Where(f => f.customerId == id).Select(f => f.customerName).ToList();

            return name[0].ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            _buldCustomers = new ObservableCollection<CUSTOMER>(buildingCompany.CUSTOMERS);
            int id = (int)value;
            var name = _buldCustomers.Where(f => f.customerId == id).Select(f => f.customerName).ToList();

            return name[0].ToString();
        }
    }
}
