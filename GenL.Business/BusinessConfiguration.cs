using Microsoft.Extensions.DependencyInjection;
using GenL.DataAccess;
using GenL.Business.Services.Abstract;
using GenL.Business.Services;

namespace GenL.Business
{
	public static class BusinessConfiguration
	{
		public static IServiceCollection AddBusinessConfiguration(this IServiceCollection services, string connectionString)
		{
			services.AddDataAccessConfiguration(connectionString);

			services.AddScoped<IUserService, UserService>();

			return services;
		}

		public static IServiceCollection AddIdentity(this IServiceCollection services)
		{
			return services.AddUserIdentity();
		}
	}
}