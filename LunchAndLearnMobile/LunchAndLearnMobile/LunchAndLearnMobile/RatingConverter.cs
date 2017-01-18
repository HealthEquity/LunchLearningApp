using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LunchAndLearnMobile
{
  class RatingConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      var rating = (int)value;
      if (rating == 1)
        return "1";
      if (rating == 2)
        return "2";
      if (rating == 3)
        return "3";
      if (rating == 4)
        return "4";
      if (rating == 5)
        return "5";

      return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}