using EmailService.Application.Email.DTOs;

namespace EmailService.Application.Email;

public class SendEmailService : ISendEmailService
{
	private readonly IClientEmail _clientEmail;

	public SendEmailService(IClientEmail clientEmail) => _clientEmail = clientEmail;

	public async Task<ReturnEmailViewModel> SendEmail(SendEmailRequest request)
    {
		var response = await _clientEmail.SendEmailAsync(request);
        return response;
    }
}