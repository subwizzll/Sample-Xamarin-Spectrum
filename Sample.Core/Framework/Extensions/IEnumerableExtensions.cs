using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sample.Core.Framework.Enums;

namespace Sample.Core.Framework
{
    public static partial class Extensions
    {
        public static IEnumerable<T> RepeatedDefault<T>(this T item, int count) where T : class => default(T).Repeated(count);

        public static IEnumerable<T> Repeated<T>(this T item, int count) where T : class => Enumerable.Repeat(item, count).ToList();

        public static IEnumerable<T> SortByPropertyName<T>(this IEnumerable<T> items, PropertyInfo propertyInfo, bool ascending)
            => propertyInfo == null || !typeof(T).GetProperties().Contains(propertyInfo)
                ? items
                : ascending
                    ? items.OrderBy(x => propertyInfo.GetValue(x))
                    : items.OrderByDescending(x => propertyInfo.GetValue(x));
        
        public static IEnumerable<T> FilterByPropertyName<T>(this IEnumerable<T> items, PropertyInfo propertyInfo, FilterCriteria criteria, object compareValue)
        {
            return !typeof(T).GetProperties().Contains(propertyInfo) || criteria == FilterCriteria.None
                ? items
                : items.Where(item => propertyInfo.ComparePropertyValueWithFilterValue(item, criteria, compareValue));
        }
    }
}