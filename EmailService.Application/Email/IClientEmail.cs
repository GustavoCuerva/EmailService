using EmailService.Application.Email.DTOs;
using EmailService.Common;
using EmailService.Domain;

namespace EmailService.Application.Email;
public interface IClientEmail
{
	public Task<Result<ReturnEmailViewModel>> SendEmailAsync(EmailEntity email);
}
