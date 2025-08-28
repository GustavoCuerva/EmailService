using EmailService.Application.Email.DTOs;

namespace EmailService.Application.Email;
public interface IClientEmail
{
	public Task<ReturnEmailViewModel> SendEmailAsync(SendEmailRequest request);
}
