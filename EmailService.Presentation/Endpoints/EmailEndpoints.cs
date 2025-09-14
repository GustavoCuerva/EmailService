using EmailService.Application.Email;
using EmailService.Application.Email.DTOs;
using EmailService.Common;
using EmailService.Presentation.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EmailService.Presentation.Endpoints;

public static class EmailEndpoints
{
    public static void AddEndpointsEmail(this IEndpointRouteBuilder app) 
    {
        var endpoints = app.MapGroup("api/email");

        endpoints.MapPost("/send", SendEmail);
    }

    public static async Task<Results<Ok<ReturnEmailViewModel>, BadRequest<List<Error>>>> SendEmail(
        SendEmailRequest request,
        IValidator<SendEmailRequest> validatorSendEmail,
		ISendEmailService sendEmailService
        )
    {
        var validationResult = await validatorSendEmail.ValidateAsync(request);
        if (!validationResult.IsValid)
            return TypedResults.BadRequest(validationResult.ToErrorList());

		var result = await sendEmailService.SendEmail(request);

		if (result.IsFailure)
			return TypedResults.BadRequest(result.Errors);

		return TypedResults.Ok(result.Data);
    }
}
