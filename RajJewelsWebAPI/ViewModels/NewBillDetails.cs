namespace RajJewelsWebAPI.ViewModels
{
    public class NewBillDetails
    {
        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public string? Address { get; set; }

        public int? PhoneNumber { get; set; }

        public List<JewelItem>? JewelItems { get; set; }

        public string? OldJewel { get; set; }

        public int? OldJewelWeight { get; set; }

        public int? oldJewelPrice { get; set; }

        public int? WastageAndGST { get; set; }

        public int? ManufacturingCost { get; set; }

        public int? Discount { get; set; }

        public int? TotalPrice { get; set; }
    }

    public class JewelItem
    {
        public string Jewel { get; set; } = null!;

        public string? QualityType { get; set; }

        public int? Weight { get; set; }

        public int? Price { get; set; }
    }
}

