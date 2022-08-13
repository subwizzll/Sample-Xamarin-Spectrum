using System.Reflection;
using Sample.Core.Framework.Enums;

namespace Sample.Core.Framework
{
    public static partial class Extensions
    {
        public static bool ComparePropertyValueWithFilterValue(this PropertyInfo propertyInfo, dynamic valueObj, FilterCriteria criteria, dynamic compareValue)
        {
            var objValue = propertyInfo.GetValue(valueObj);
            var typesAreEqual = objValue.GetType() == compareValue.GetType();
            
            if (objValue == null || !typesAreEqual)
                return false;

            return criteria switch
            {
                FilterCriteria.None => true,
                FilterCriteria.LessThan => objValue < compareValue,
                FilterCriteria.LessThanOrEqual => objValue <= compareValue,
                FilterCriteria.Equal => objValue.Equals(compareValue),
                FilterCriteria.NotEqual => !objValue.Equals(compareValue),
                FilterCriteria.GreaterThan => objValue > compareValue,
                FilterCriteria.GreaterThanOrEqual => objValue >= compareValue,
            };
        }
    }
}