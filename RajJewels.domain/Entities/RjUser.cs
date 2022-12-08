using System;
using System.Collections.Generic;

namespace RajJewels.domain.Entities;

public partial class RjUser
{
    public string UserId { get; set; } = null!;

    public string? UserName { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Pass { get; set; }
}
