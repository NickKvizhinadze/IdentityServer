using Microsoft.AspNetCore.Identity;

namespace CNP.Identity.Models.AppSettings
{
    public class PasswordOptionsContainer
    {
        public PasswordOptions Development { get; set; }
        public PasswordOptions Production { get; set; }
    }
}
