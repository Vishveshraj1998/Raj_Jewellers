using System;
using System.Collections.Generic;

namespace RajJewels.domain.Entities;

public partial class RjNewbilldetail
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public string? OldJewel { get; set; }

    public int? OldJewelWeight { get; set; }

    public int? OldJewelPrice { get; set; }

    public int? WastageAndGst { get; set; }

    public int? ManufacturingCost { get; set; }

    public int? Discount { get; set; }

    public int? TotalPrice { get; set; }

    public int BillNumber { get; set; }
}
