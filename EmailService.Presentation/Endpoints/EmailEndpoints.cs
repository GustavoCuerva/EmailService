using Microsoft.AspNetCore.Http.HttpResults;

namespace EmailService.Presentation.Endpoints
{
    public static class EmailEndpoints
    {
        public static void AddEndpointsEmail(this IEndpointRouteBuilder app) 
        {
            var endpoints = app.MapGroup("api/email");

            endpoints.MapGet("/send", SendEmail);
        }

        public static async Task<Results<Ok<string>, BadRequest<string>>> SendEmail()
        {
            return TypedResults.Ok("Ok");
        }
    }
}
