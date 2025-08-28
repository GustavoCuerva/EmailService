namespace EmailService.Application.Email.DTOs
{
    public record SendEmailRequest
    {
        public string to { get; set; } = string.Empty;
        public string subject { get; set; } = string.Empty;
        public string body { get; set; } = string.Empty;
    }
}
