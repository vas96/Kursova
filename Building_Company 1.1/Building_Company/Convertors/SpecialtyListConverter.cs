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
    class SpecialtyListConverter : IValueConverter
    {
      

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value == null)
            {
                value = 1;
            }
            int id = (int)value;
            var specialityStr = MainWindow._buildEmployees.ToList().First(l=>l.employeeId==(int)value).SPECIALITies;
            string result = "";
            foreach (var speciality in specialityStr)
            {
                result += speciality.name;
                if (speciality.idSpeciality != specialityStr.ToList()[specialityStr.Count()-1].idSpeciality)
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
