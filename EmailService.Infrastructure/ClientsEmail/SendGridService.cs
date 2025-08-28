using EmailService.Application.Email;
using EmailService.Application.Email.DTOs;

namespace EmailService.Infrastructure.ClientsEmail;
public class SendGridService : IClientEmail
{
	public async Task<ReturnEmailViewModel> SendEmailAsync(SendEmailRequest request)
	{
		return new ReturnEmailViewModel();
	}
}