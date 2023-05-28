using System;
using System.Collections.Generic;

namespace RajJewels.domain.Entities;

public partial class RjJewelitem
{
    public string? Name { get; set; }

    public string? Type { get; set; }

    public int? Weight { get; set; }

    public int? Price { get; set; }

    public int BillNumber { get; set; }
}
