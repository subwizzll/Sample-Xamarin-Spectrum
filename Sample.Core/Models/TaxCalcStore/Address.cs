namespace Sample.Core.Models.TaxCalcStore
{
    public class Address
    {
        public AddressType Type { get; set; }  
        
        public string City { get; set; }
        
        public string State { get; set; }
        
        public string Zip { get; set; }
        
        public string Country { get; set; }
    }

    public enum AddressType
    {
        None = 0,
        To,
        From
    }
}