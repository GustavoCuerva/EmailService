using EmailService.Application.Email.DTOs;

namespace EmailService.Application.Email;
public interface ISendEmailService
{
	public Task<ReturnEmailViewModel> SendEmail(SendEmailRequest request);
}
