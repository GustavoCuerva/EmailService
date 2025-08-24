using FluentValidation;

namespace EmailService.Application.Email
{
    public class SendEmailRequestValidation : AbstractValidator<SendEmailRequest>
    {
        public SendEmailRequestValidation() 
        {
            RuleFor(x => x.to)
                .EmailAddress()
                    .WithMessage("Not is email")
                .When(x => x.to != null && x.to != "")
                .NotEmpty()
                    .WithMessage("Recipient (to) is required");

            RuleFor(x => x.subject)
                .NotEmpty()
                    .WithMessage("Subject is required")
                .MaximumLength(100)
                    .WithMessage("Max length is {MaxLength} characters");

            RuleFor(x => x.body)
                .NotEmpty()
                    .WithMessage("Body is required");
        }
    }
}
