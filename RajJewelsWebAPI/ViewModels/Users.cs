using System;
namespace RajJewelsWebAPI.ViewModels
{
    public class Users
    {
        public string UserId { get; set; } = null!;

        public string? UserName { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Pass { get; set; }
    }

}

