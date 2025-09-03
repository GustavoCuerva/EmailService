using EmailService.Application.Email;
using EmailService.Infrastructure.ClientsEmail;
using EmailService.Infrastructure.Failover;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Fallback;

namespace EmailService.Infrastructure;
public static class InfrastructureDependencyInjection
{
	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
	{
		services.AddScoped<SendGridService>();
		services.AddScoped<MaligunService>();
		services.AddScoped<IClientEmail, FailoverEmailService>();

		return services;
	}
}
