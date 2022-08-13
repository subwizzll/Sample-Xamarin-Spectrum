using Sample.Core.Framework.Attributes.SortAndFilter;

namespace Sample.Core.Models.TaxCalcStore
{
    public class Item
    {
        public string Image { get; set; }
        
        [SortAndFilterProperty]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [SortAndFilterProperty]
        public double Price { get; set; }
    }
}