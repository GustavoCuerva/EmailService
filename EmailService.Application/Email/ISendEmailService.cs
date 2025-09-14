using Affinity.WebServiceAPI.Common;
using EmailService.Application.Email.DTOs;

namespace EmailService.Application.Email;
public interface ISendEmailService
{
	public Task<Result<ReturnEmailViewModel>> SendEmail(SendEmailRequest request);
}
