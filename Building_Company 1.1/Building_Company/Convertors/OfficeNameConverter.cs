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
    class OfficeNameConverter : IValueConverter
    {
        KR_BD2Entities buildingCompany = new KR_BD2Entities();
        private ObservableCollection<OFFICE> _buldOfficess;
      

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            _buldOfficess = new ObservableCollection<OFFICE>(buildingCompany.OFFICES);
            if (value == null)
            {
                value = 1;
            }
            int id = (int)value;
            var name = _buldOfficess.Where(f => f.officeId == id).Select(f => f.city).ToList();
            return name[0].ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
