namespace Sample.Core.Models.TaxCalcStore
{
    public class LineItemDetail
    {
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice => Item.Price * Quantity;
    }
}