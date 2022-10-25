using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GenL.DataAccess.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Xml.Linq;

namespace GenL.DataAccess
{
	public class ApplicationDbContext : IdentityDbContext<UserEntity>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			// Customize the ASP.NET Identity model and override the defaults if needed.
			// For example, you can rename the ASP.NET Identity table names and more.
			// Add your customizations after calling base.OnModelCreating(builder);

			// rename the ASP.NET Identity table names
			builder.Entity<UserEntity>().ToTable("IdentityUsers", "dbo");
			builder.Entity<IdentityRole>().ToTable("IdentityRoles", "dbo");
			builder.Entity<IdentityUserRole<string>>().ToTable("IdentityUserRoles", "dbo");

			builder.Entity<IdentityUserClaim<string>>().ToTable("IdentityUserClaims", "dbo");
			builder.Entity<IdentityRoleClaim<string>>().ToTable("IdentityRoleClaims", "dbo");

			builder.Entity<IdentityUserLogin<string>>().ToTable("IdentityUserLogins", "dbo");
			builder.Entity<IdentityUserToken<string>>().ToTable("IdentityUserTokens", "dbo");
		}
	}
}