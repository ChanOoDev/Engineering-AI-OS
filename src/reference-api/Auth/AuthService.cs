using ReferenceApi.Audit;

namespace ReferenceApi.Auth;

public sealed class AuthService(IUserStore users, IAuditSink auditSink)
{
    public async Task<LoginResult> LoginAsync(LoginRequest request, string correlationId)
    {
        var validationErrors = Validate(request);
        if (validationErrors.Count > 0)
        {
            return new LoginResult(LoginStatus.ValidationFailed, ValidationErrors: validationErrors);
        }

        var normalizedEmail = NormalizeEmail(request.Email!);
        var user = await users.FindByEmailAsync(normalizedEmail);
        var passwordMatches = user is null
            ? DemoPasswordHasher.Verify(request.Password!, DemoPasswordHasher.DummySalt, DemoPasswordHasher.DummyHash)
            : DemoPasswordHasher.Verify(request.Password!, user.PasswordSalt, user.PasswordHash);

        if (user is null || !passwordMatches)
        {
            auditSink.Record(AuditEvent.Create(
                "auth.login.failed",
                correlationId,
                "failure",
                "authentication",
                user?.Id));

            return new LoginResult(LoginStatus.AuthenticationFailed);
        }

        if (user.Status is AccountStatus.Locked)
        {
            auditSink.Record(AuditEvent.Create(
                "auth.login.locked_out",
                correlationId,
                "failure",
                "locked_out",
                user.Id));

            return new LoginResult(LoginStatus.AuthenticationFailed);
        }

        if (user.Status is AccountStatus.Disabled or AccountStatus.Deleted)
        {
            auditSink.Record(AuditEvent.Create(
                "auth.login.failed",
                correlationId,
                "failure",
                "account_status",
                user.Id));

            return new LoginResult(LoginStatus.AuthenticationFailed);
        }

        // Reference-only token. Production code must issue signed, validated, expiring tokens.
        var response = new LoginResponse(
            AccessToken: $"demo-token-{Guid.NewGuid():N}",
            ExpiresInSeconds: 900,
            User: new UserProfileResponse(user.Id, user.Email, user.DisplayName, user.Roles));

        auditSink.Record(AuditEvent.Create(
            "auth.login.succeeded",
            correlationId,
            "success",
            "none",
            user.Id));

        return new LoginResult(LoginStatus.Success, response);
    }

    private static List<string> Validate(LoginRequest request)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.Email))
        {
            errors.Add("Email is required.");
        }

        if (string.IsNullOrWhiteSpace(request.Password))
        {
            errors.Add("Password is required.");
        }

        return errors;
    }

    private static string NormalizeEmail(string email)
    {
        return email.Trim().ToUpperInvariant();
    }
}
