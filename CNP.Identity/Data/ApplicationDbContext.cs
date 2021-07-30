using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CNP.Identity.Data.Mappings;
using CNP.Identity.Models.Entities.Users;

namespace CNP.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<CnpUser>
    {
        #region Constructors
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        #endregion

        #region Overrides
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.MapIdentity();
            #endregion
        }
    }
}
