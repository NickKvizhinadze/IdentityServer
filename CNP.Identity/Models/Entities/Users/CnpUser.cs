using Microsoft.AspNetCore.Identity;

namespace CNP.Identity.Models.Entities.Users
{
    public class CnpUser : IdentityUser
    {
        #region Constructors
        public CnpUser()
        {
        }
        public CnpUser(string userName) : base(userName)
        {
        }
        #endregion
    }
}
