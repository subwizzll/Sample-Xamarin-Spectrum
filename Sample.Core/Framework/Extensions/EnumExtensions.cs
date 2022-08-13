using System.ComponentModel;

namespace Sample.Core.Framework
{
    public static partial class Extensions
    {
        public static string GetDescriptionAttribute<T>(this T source)
        {
            var fi = source.GetType().GetField(source.ToString());

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            return attributes is { Length: > 0 } 
                ? attributes[0].Description
                : source.ToString();
        }
    }
}