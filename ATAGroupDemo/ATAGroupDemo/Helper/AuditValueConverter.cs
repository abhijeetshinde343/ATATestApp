using System;
using System.Globalization;
using Xamarin.Forms;

namespace ATAGroupDemo.Helper
{
    public class AuditValueConverter : IValueConverter
    {
        public AuditValueConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString().ToLower() == "false")
                return "Audit Not Completed ";
            else
                return "Audit Completed";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
