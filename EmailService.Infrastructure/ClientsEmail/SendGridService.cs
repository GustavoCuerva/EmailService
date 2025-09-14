using Affinity.WebServiceAPI.Common;
using DotNetEnv;
using EmailService.Application.Email;
using EmailService.Application.Email.DTOs;
using EmailService.Common;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;

namespace EmailService.Infrastructure.ClientsEmail;
public class SendGridService : IClientEmail
{
	private readonly SendGridClient _sendGridClient;
	private readonly string _fromEmail;
	private readonly string _fromName;

	public SendGridService() 
	{
		string apiKey = Env.GetString("SEND-GRID-API-KEY");

		_sendGridClient = new SendGridClient(apiKey);
		_fromEmail = Env.GetString("SEND-GRID-EMAIL-ADDRESS");
		_fromName = Env.GetString("SEND-GRID-EMAIL-NAME");
	}

	public async Task<Result<ReturnEmailViewModel>> SendEmailAsync(SendEmailRequest request)
	{
		var from = new EmailAddress(_fromEmail, _fromName);
		var to = new EmailAddress(request.to, "User");
		string subject = request.subject;

		string plainTextContent = string.Empty;
		string body = request.body;

		var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, body);
		var response = await _sendGridClient.SendEmailAsync(msg);

		string statusCode = response.StatusCode.ToString();

		if (response.StatusCode == HttpStatusCode.BadRequest)
			return new Error(statusCode, "Error in send email");

		return new ReturnEmailViewModel(){
			Status = statusCode,
			DateTime = DateTime.Now
		};
	}
}