using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LunchAndLearnMobile
{
  public class DataSourceConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value == null)
        return true;

      return ((IList)value).Count == 0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return value;
    }
  }
}
