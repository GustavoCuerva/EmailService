using EmailService.Application.Email;
using EmailService.Common;
using EmailService.Presentation.Extensions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EmailService.Presentation.Endpoints
{
    public static class EmailEndpoints
    {
        public static void AddEndpointsEmail(this IEndpointRouteBuilder app) 
        {
            var endpoints = app.MapGroup("api/email");

            endpoints.MapPost("/send", SendEmail);
        }

        public static async Task<Results<Ok<string>, BadRequest<List<Error>>>> SendEmail(
            SendEmailRequest request,
            IValidator<SendEmailRequest> validatorSendEmail
            )
        {
            var validationResult = await validatorSendEmail.ValidateAsync(request);
            if (!validationResult.IsValid)
                return TypedResults.BadRequest(validationResult.ToErrorList());

            return TypedResults.Ok("Ok");
        }
    }
}
