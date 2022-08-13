using Sample.Core.Models.TaxCalcStore;

namespace Sample.Core.Data
{
    public static class MockItemData
    {
        static MockItemData()
        {
            MockCart = new();
            (MockCart.ToAddress, MockCart.FromAddress) 
                = (MockToAddress, MockFromAddress);
        }

        public static Cart MockCart { get; set; }

        public static Item[] MockItems => new[]
        {
            new Item
            {
                Image = "CoffeeBag",
                Name = "Tasty Coffee",
                Description = "The best coffee in town!",
                Price = 15.99
            },
            new Item
            {
                Image = "MatchaBag",
                Name = "Love Matcha Tea",
                Description = "Japanese matcha.",
                Price = 39.99
            },
            new Item
            {
                Image = "MatchaChasen",
                Name = "Matcha Chasen",
                Description = "A bamboo matcha whisk.",
                Price = 10.99
            }
        };
        
        public static Address MockFromAddress => new()
        {
            City = "Arden",
            State = "NC",
            Zip = "28704",
            Country = "US",
            Type = AddressType.From
        };
        
        public static Address MockToAddress => new()
        {
            City = "Asheville",
            State = "NC",
            Zip = "28801",
            Country = "US",
            Type = AddressType.To
        };
    }
}