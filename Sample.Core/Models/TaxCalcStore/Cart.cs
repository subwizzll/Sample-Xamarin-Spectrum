using System.Linq;
using Xamarin.CommunityToolkit.ObjectModel;

namespace Sample.Core.Models.TaxCalcStore
{
    public class Cart
    {
        public ObservableRangeCollection<Item> Items { get; set; } = new();

        public ObservableRangeCollection<LineItemDetail> LineItems { get; set; } = new();

        public Address ToAddress { get; set; }

        public Address FromAddress { get; set; }

        public double Shipping { get; set; }
        
        public double TaxRate { get; set; }
        
        public double CollectedTax { get; set; }

        public double TotalPrice => LineItems.Sum(x => x.TotalPrice) + Shipping + CollectedTax;
    }
}