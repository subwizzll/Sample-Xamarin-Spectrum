using System;
using System.Collections.Generic;
using System.Reflection;
using Sample.Core.Framework.Enums;
using Sample.Core.Framework.Models;
using Sample.Core.Models.TaxCalcStore;

namespace Sample.Core.Data
{
    public static class Constants
    {
        public static class TaxRateApi
        {
            public static Uri BaseAddress => new("https://api.taxjar.com/");
            public static string PublicKey => "5da2f821eee4035db4771edab942a4cc";
        } 
        
        public static class StoreSettings
        {
            public static Dictionary<string, object> SortAndFilterArguments = new()
            {
                ["initialItems"] = MockItemData.MockItems,
                ["sortOptions"] = new SortOption[]{},
                ["filterOptions"] = FilterOptions
            };
            
            static PropertyInfo itemPriceProperty => typeof(Item).GetProperty(nameof(Item.Price));
            
            static FilterOption[] FilterOptions => new FilterOption[]
            {
                new(),
                new ()
                {
                    Property = itemPriceProperty,
                    Criteria = FilterCriteria.LessThan,
                    CompareValue = 20d
                },
                new ()
                {
                    Property = itemPriceProperty,
                    Criteria = FilterCriteria.GreaterThanOrEqual,
                    CompareValue = 20d
                }
            };
        }
    }
}