using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace OrderEntrySystem
{
    public class DecimalToStringConverter : IValueConverter
    {
        /// <summary>
        /// Store the last value which was entered by the user.
        /// </summary>
        private string lastEnteredValue;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string result = this.lastEnteredValue ?? value.ToString();

            this.lastEnteredValue = null;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal decimalValue = 0.00m;

            string stringValue = (string)value;

           if ( decimal.TryParse(stringValue, out decimalValue))
            {
                this.lastEnteredValue = stringValue;
            }

            return decimalValue;
        }
    }
}
