using System;
namespace RajJewelsWebAPI.ViewModels
{
	public class UserDetails
	{
        public string UserId { get; set; } = null!;

        public string? UserName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }
	}
}

