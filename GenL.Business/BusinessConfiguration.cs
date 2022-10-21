using Microsoft.Extensions.DependencyInjection;
using GenL.DataAccess;

namespace GenL.Business
{
	public static class BusinessConfiguration
	{
		public static IServiceCollection AddBusinessConfiguration(this IServiceCollection services, string connectionString)
		{
			services.AddDataAccessConfiguration(connectionString);

			return services;
		}

		public static IServiceCollection AddIdentity(this IServiceCollection services)
		{
			return services.AddUserIdentity();
		}
	}
}