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
    class UnitNameConverter:IValueConverter
    {
        KR_BD2Entities buildingCompany = new KR_BD2Entities();
        private ObservableCollection<UNIT> _buldUnits;
      

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            _buldUnits = new ObservableCollection<UNIT>(buildingCompany.UNITS);
            if (value == null)
            {
                value = 1;
            }
            int id = (int)value;
            var name = _buldUnits.Where(f => f.idUnit == id).Select(f => f.name).ToList();
            return name[0].ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
