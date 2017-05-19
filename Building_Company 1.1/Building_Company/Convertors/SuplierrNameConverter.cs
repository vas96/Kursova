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
    class SuplierrNameConverter : IValueConverter
    {
        KR_BD2Entities buildingCompany = new KR_BD2Entities();
        private ObservableCollection<SUPPLIER> _buldsSuppliers;
      

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                value = 1;
            }
            _buldsSuppliers = new ObservableCollection<SUPPLIER>(buildingCompany.SUPPLIERS);
            int id = (int)value;
            var name = _buldsSuppliers.Where(f => f.supplierID == id).Select(f => f.companyName).ToList();

            return name[0].ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
