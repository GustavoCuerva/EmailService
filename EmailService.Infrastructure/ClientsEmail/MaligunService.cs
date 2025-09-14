using DotNetEnv;
using EmailService.Application.Email;
using EmailService.Application.Email.DTOs;
using EmailService.Common;
using EmailService.Domain;
using System.Net;
using System.Text;

namespace EmailService.Infrastructure.ClientsEmail;
public class MaligunService : IClientEmail
{
	private readonly string _apiKey;
	private readonly string _fromEmail;
	private readonly string _auth;
	private readonly string _domain;
	private readonly HttpClient _httpClient;

	public MaligunService(HttpClient httpClient) {
		_apiKey = Env.GetString("MALIGUN-API-KEY");
		_fromEmail = Env.GetString("MALIGUN-EMAIL-ADDRESS");

		_auth = Convert.ToBase64String(Encoding.ASCII.GetBytes($"api:{_apiKey}"));
		_domain = Env.GetString("MALIGUN-SANDBOX-DOMAIN");

		_httpClient = httpClient;
		_httpClient.BaseAddress = new Uri(Env.GetString("MALIGUN-URL"));
		_httpClient.DefaultRequestHeaders.Authorization = 
			new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", _auth);
	}

	public async Task<Result<ReturnEmailViewModel>> SendEmailAsync(EmailEntity email)
	{
		var data = new FormUrlEncodedContent(new[]
		{
			new KeyValuePair<string, string>("from", _fromEmail),
			new KeyValuePair<string, string>("to", email.To),
			new KeyValuePair<string, string>("subject", email.Subject),
			new KeyValuePair<string, string>("text", email.Body)
		});

		var response = await _httpClient.PostAsync($"/v3/{_domain}/messages", data);
		string statusCode = response.StatusCode.ToString();

		if (response.StatusCode == HttpStatusCode.BadRequest)
			return new Error(statusCode, "Error in send email");

		return new ReturnEmailViewModel
		{
			Status = statusCode,
			DateTime = DateTimeOffset.Now
		};
	}
	
}
