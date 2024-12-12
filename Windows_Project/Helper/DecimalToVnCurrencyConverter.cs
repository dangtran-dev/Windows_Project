using Microsoft.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Project
{
    public class DecimalToVnCurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is decimal price)
            {
                CultureInfo vietnameseCulture = new CultureInfo("vi-VN");
                string formattedAmount = price.ToString("#,0", vietnameseCulture) + " VNĐ";
                return formattedAmount;
            }
            return "Invalid amount";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

}
