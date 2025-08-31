using DotNetEnv;
using EmailService.Application;
using EmailService.Infrastructure;
using EmailService.Presentation.Endpoints;
using EmailService.Presentation.Middleware;

Env.Load();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails(configure =>
{
	configure.CustomizeProblemDetails = context =>
	{
		context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
		context.ProblemDetails.Extensions.TryAdd("timestamp", DateTimeOffset.Now);
		context.ProblemDetails.Extensions.Remove("exception");
	};
});
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationService();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.AddEndpointsEmail();

app.Run();
