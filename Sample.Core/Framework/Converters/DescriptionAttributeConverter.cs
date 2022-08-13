using System;
using System.Globalization;
using Xamarin.CommunityToolkit.Extensions.Internals;
using Xamarin.Forms;

namespace Sample.Core.Framework.Converters
{
    public class DescriptionAttributeConverter : ValueConverterExtension, IValueConverter
    {
        public virtual object Convert(object? value, Type? targetType, object? parameter, CultureInfo? culture) => ConvertInternal(value);

        static string ConvertInternal(object? value)
            => value.GetDescriptionAttribute();
        
        public object ConvertBack(object? value, Type? targetType, object? parameter, CultureInfo? culture)
            => value;
    }
}