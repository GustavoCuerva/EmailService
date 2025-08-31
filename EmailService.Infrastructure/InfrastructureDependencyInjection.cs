using EmailService.Application.Email;
using EmailService.Infrastructure.ClientsEmail;
using Microsoft.Extensions.DependencyInjection;

namespace EmailService.Infrastructure;
public static class InfrastructureDependencyInjection
{
	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
	{
		services.AddScoped<IClientEmail, MaligunService>();

		return services;
	}
}
