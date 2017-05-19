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
    class unityListConverter : IValueConverter
    {
       

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
          
            if (value == null)
            {
                value = 1;
            }
            int id = (int)value;
            var unityStr = MainWindow._buildEmployees.ToList().First(l=>l.employeeId==(int)value).UNITS;
            string result = "";
            foreach (var unit in unityStr)
            {
                result += unit.name;
                if (unit.idUnit != unityStr.ToList()[unityStr.Count()-1].idUnit)
                    result += ", ";
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int) value;
        }
    }
}
