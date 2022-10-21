using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GenL.DataAccess
{
	public static class DataAccessConfiguration
	{
		public static IServiceCollection AddDataAccessConfiguration(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

			return services;
		}

		public static IServiceCollection AddUserIdentity(this IServiceCollection services)
		{
			services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<ApplicationDbContext>();

			return services;
		}
	}
}