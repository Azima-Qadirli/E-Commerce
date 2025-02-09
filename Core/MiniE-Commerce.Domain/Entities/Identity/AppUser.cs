using Microsoft.AspNetCore.Identity;

namespace MiniE_Commerce.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string NameSurname { get; set; }
    }
}
