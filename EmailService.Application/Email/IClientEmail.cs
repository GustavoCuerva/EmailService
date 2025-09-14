using Affinity.WebServiceAPI.Common;
using EmailService.Application.Email.DTOs;

namespace EmailService.Application.Email;
public interface IClientEmail
{
	public Task<Result<ReturnEmailViewModel>> SendEmailAsync(SendEmailRequest request);
}
