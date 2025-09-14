using EmailService.Application.Email.DTOs;
using EmailService.Common;
using EmailService.Domain;

namespace EmailService.Application.Email;

public class SendEmailService : ISendEmailService
{
	private readonly IClientEmail _clientEmail;

	public SendEmailService(IClientEmail clientEmail) => _clientEmail = clientEmail;

	public async Task<Result<ReturnEmailViewModel>> SendEmail(SendEmailRequest request)
    {
		var email = EmailEntity.Create(request.to, request.subject, request.body);
		var response = await _clientEmail.SendEmailAsync(email);

		if (response.IsFailure)
			return response.Errors;

        return response;
    }
}