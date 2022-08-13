using System.Linq;
using System.Threading.Tasks;
using Sample.Core.Framework.Attributes.SortAndFilter;
using Sample.Core.Framework.Enums;
using Sample.Core.Framework.Interfaces;
using Sample.Core.Framework.Models;

namespace Sample.Core.Framework
{
    public static partial class Extensions
    {
        public static async Task SortAndFilterItems<T>(this ISortAndFilterModel<T> instance)
        {
            var sortSelection = instance?.SortSelection ?? new();
            var filterSelection = instance?.FilterSelection ?? new();
            
            var result = instance.OriginalItems
                .FilterByPropertyName(filterSelection.Property, filterSelection.Criteria, filterSelection.CompareValue)
                .SortByPropertyName(sortSelection.Property, instance.SortAscending);
            
            if (sortSelection.Property == null)
                (instance.SortSelection, instance.SortAscending) 
                    = (null, true);

            if (filterSelection.Criteria == FilterCriteria.None)
                instance.FilterSelection = null;
            instance.DisplayItems = result;
        }
        
        public static SortOption[] InitDefaultSortOptions<T>(this ISortAndFilterModel<T> instance) =>
            typeof(T)
                .GetProperties()
                .Where(x => x.CustomAttributes.Any(x => x.AttributeType == typeof(SortAndFilterPropertyAttribute)))
                .Select(x => new SortOption{Property = x})
                .Prepend(new SortOption())
                .ToArray();
    }
}