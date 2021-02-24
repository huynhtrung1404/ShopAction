using System;
using Microsoft.AspNetCore.Identity;

namespace ShopAction.Infrastructure.Identity.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
    }
}