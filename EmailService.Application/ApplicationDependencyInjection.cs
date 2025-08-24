using EmailService.Application.Email;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
namespace EmailService.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<SendEmailRequest>();
            return services;
        }
    }
}
