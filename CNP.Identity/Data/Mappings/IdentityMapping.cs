using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CNP.Identity.Models.Entities.Users;

namespace CNP.Identity.Data.Mappings
{
    public static class IdentityMapping
    {
        public static void MapIdentity(this ModelBuilder builder)
        {
            builder.Entity<CnpUser>(entity =>
            {
                entity.ToTable(name: "Users");
                entity.Property(p => p.Id).HasColumnName("UserId");
            });
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable(name: "UserRoles");
                entity.HasKey(key => new { key.UserId, key.RoleId });
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable(name: "UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable(name: "UserLogins");
                entity.HasKey(key => new { key.ProviderKey, key.LoginProvider });
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable(name: "RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable(name: "UserTokens");
                entity.HasKey(key => new { key.UserId, key.LoginProvider, key.Name });
            });
        }
    }
}
