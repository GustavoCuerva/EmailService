namespace EmailService.Application.Email.DTOs;
public record ReturnEmailViewModel
{
	public string Status { get; set; } = string.Empty;
	public DateTimeOffset DateTime { get; set; }
}
