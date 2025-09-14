namespace EmailService.Domain;

public class EmailEntity
{
	public string To { get; private set; } = string.Empty;
	public string Subject { get; private set; } = string.Empty;
	public string Body { get; private set; } = string.Empty;

	public static EmailEntity Create(string to, string subject, string body)
	{
		var email = new EmailEntity()
		{
			To = to,
			Subject = subject,
			Body = body
		};

		return email;
	}
}