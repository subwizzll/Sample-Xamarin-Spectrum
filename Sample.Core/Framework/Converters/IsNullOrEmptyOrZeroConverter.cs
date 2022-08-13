using System;
using System.Globalization;
using Xamarin.CommunityToolkit.Extensions.Internals;
using Xamarin.Forms;

namespace Sample.Core.Framework.Converters
{
    public class IsNullOrEmptyOrZeroConverter : ValueConverterExtension, IValueConverter
    {
        public virtual object Convert(object? value, Type? targetType, object? parameter, CultureInfo? culture) => ConvertInternal(value);

        internal static bool ConvertInternal(object? value)
        {
            if (value == null)
                return true;
            var result = value is string str && (string.IsNullOrWhiteSpace(str) || str == "0");
            return result;
        }
        
        public object ConvertBack(object? value, Type? targetType, object? parameter, CultureInfo? culture)
            => throw new NotImplementedException();
    }    
    
    public class IsNotNullOrEmptyOrZeroConverter : IsNullOrEmptyOrZeroConverter
    {
        public override object Convert(object? value, Type? targetType, object? parameter, CultureInfo? culture) => !ConvertInternal(value);
    }
}
