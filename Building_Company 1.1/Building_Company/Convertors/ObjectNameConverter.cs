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
    class ObjectNameConverter:IValueConverter
    {
        KR_BD2Entities buildingCompany = new KR_BD2Entities();
        private ObservableCollection<OBJECT> _buldObjectss;
      

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            _buldObjectss = new ObservableCollection<OBJECT>(buildingCompany.OBJECTS);
            if (value == null)
            {
                value = 1;
            }
            int id = (int)value;
            var name = _buldObjectss.Where(f => f.idObject == id).Select(f => f.comments).ToList();

            return name[0].ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int) value;
        }
    }
}
