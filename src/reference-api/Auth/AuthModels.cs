namespace ReferenceApi.Auth;

public sealed record LoginRequest(string? Email, string? Password);

public sealed record LoginResponse(
    string AccessToken,
    int ExpiresInSeconds,
    UserProfileResponse User);

public sealed record UserProfileResponse(
    string Id,
    string Email,
    string DisplayName,
    IReadOnlyList<string> Roles);

public enum AccountStatus
{
    Active,
    Locked,
    Disabled,
    Deleted
}

public enum LoginStatus
{
    Success,
    ValidationFailed,
    AuthenticationFailed
}

public sealed record LoginResult(
    LoginStatus Status,
    LoginResponse? Response = null,
    IReadOnlyList<string>? ValidationErrors = null);

public sealed record DemoUser(
    string Id,
    string Email,
    string DisplayName,
    IReadOnlyList<string> Roles,
    AccountStatus Status,
    byte[] PasswordSalt,
    byte[] PasswordHash);
