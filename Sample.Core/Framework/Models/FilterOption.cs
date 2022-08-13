using System.Reflection;
using Sample.Core.Framework.Enums;

namespace Sample.Core.Framework.Models
{
    public class FilterOption
    {
        public FilterOption()
        {
            Property = default;
            Criteria = FilterCriteria.None;
            CompareValue = default;
        }
        
        public PropertyInfo Property { get; set; }
        public FilterCriteria Criteria { get; set; }
        public object CompareValue { get; set; }

        public string DisplayString => ToString();

        public override string ToString() 
            => Property != null
            && Criteria != null
            && Criteria != FilterCriteria.None
            && CompareValue != null
                ? $"{Property.Name} {Criteria.GetDescriptionAttribute()} {CompareValue}"
                : FilterCriteria.None.GetDescriptionAttribute();
    }
}