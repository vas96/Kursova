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
    class MaterialNameConverter : IValueConverter
    {
        KR_BD2Entities buildingCompany = new KR_BD2Entities();
        private ObservableCollection<MATERIAL> _buldMaterials;
      

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            _buldMaterials = new ObservableCollection<MATERIAL>(buildingCompany.MATERIALs);
            if (value == null)
            {
                value = 1;
            }
            int id = (int)value;
            var name = _buldMaterials.Where(f => f.idMatterial == id).Select(f => f.name).ToList();
            return name[0].ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
