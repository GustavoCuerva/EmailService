using EmailService.Application.Email;
using EmailService.Application.Email.DTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
namespace EmailService.Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services)
    {
		services.AddScoped<ISendEmailService, SendEmailService>();

        services.AddValidatorsFromAssemblyContaining<SendEmailRequest>();
        return services;
    }
}
