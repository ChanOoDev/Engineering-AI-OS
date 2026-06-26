using ReferenceApi.Audit;
using ReferenceApi.Auth;
using ReferenceApi.Errors;
using ReferenceApi.Scheduler;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IUserStore, InMemoryUserStore>();
builder.Services.AddSingleton<IAuditSink, InMemoryAuditSink>();
builder.Services.AddSingleton<AuthService>();
builder.Services.AddSingleton<ISchedulerEventSink, InMemorySchedulerEventSink>();
builder.Services.AddSingleton<SchedulerService>();

var app = builder.Build();

app.Use(async (httpContext, next) =>
{
    try
    {
        await next(httpContext);
    }
    catch (BadHttpRequestException ex) when (!httpContext.Response.HasStarted)
    {
        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        await httpContext.Response.WriteAsJsonAsync(ErrorEnvelope.Create(
            "REQUEST_MALFORMED",
            "Request body is malformed or unreadable.",
            httpContext.TraceIdentifier,
            [ex.Message]));
    }
});

app.MapPost("/api/auth/login", async (
    LoginRequest request,
    AuthService authService,
    HttpContext httpContext) =>
{
    var correlationId = httpContext.TraceIdentifier;
    var result = await authService.LoginAsync(request, correlationId);

    return result.Status switch
    {
        LoginStatus.Success => Results.Ok(result.Response),
        LoginStatus.ValidationFailed => Results.BadRequest(ErrorEnvelope.Create(
            "AUTH_VALIDATION_FAILED",
            "Email and password are required.",
            correlationId,
            result.ValidationErrors)),
        LoginStatus.AuthenticationFailed => Results.Json(
            ErrorEnvelope.Create("AUTH_INVALID_CREDENTIALS", "Invalid email or password.", correlationId),
            statusCode: StatusCodes.Status401Unauthorized),
        _ => Results.Problem(statusCode: StatusCodes.Status500InternalServerError)
    };
});

app.Run();

public partial class Program;
