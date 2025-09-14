using EmailService.Application.Email.DTOs;
using EmailService.Common;

namespace EmailService.Application.Email;
public interface ISendEmailService
{
	public Task<Result<ReturnEmailViewModel>> SendEmail(SendEmailRequest request);
}
