using Affinity.WebServiceAPI.Common;
using EmailService.Application.Email;
using EmailService.Application.Email.DTOs;
using EmailService.Infrastructure.ClientsEmail;
using Polly;

namespace EmailService.Infrastructure.Failover;
public class FailoverEmailService: IClientEmail
{
	private readonly SendGridService _primaryEmailClient;
	private readonly MaligunService _secondaryEmailClient;

	public FailoverEmailService(SendGridService primaryEmailClient, MaligunService secondaryEmailClient)
	{
		_primaryEmailClient = primaryEmailClient;
		_secondaryEmailClient = secondaryEmailClient;
	}

	public async Task<Result<ReturnEmailViewModel>> SendEmailAsync(SendEmailRequest request)
	{
		var fallbackPolicy = Policy<Result<ReturnEmailViewModel>>
			   .Handle<Exception>()
			   .FallbackAsync(
				   async (ct) => await _secondaryEmailClient.SendEmailAsync(request),
				   async (ex) =>
				   {
					   Console.WriteLine($"[Failover] Tentando fallback por erro: {ex.Exception.Message}");
				   });

		return await fallbackPolicy.ExecuteAsync(() => _primaryEmailClient.SendEmailAsync(request));
	}
}
