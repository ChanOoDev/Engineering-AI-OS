using System.Net;
using System.Text;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using ReferenceApi.Audit;
using Xunit;

namespace ReferenceApi.Tests;

public sealed class AuthLoginTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public AuthLoginTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Login_WithValidActiveUser_ReturnsTokenAndSafeProfile()
    {
        using var client = _factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/auth/login", new
        {
            email = " USER@example.com ",
            password = "Password123!"
        });

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        using var body = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());
        var root = body.RootElement;

        Assert.StartsWith("demo-token-", root.GetProperty("accessToken").GetString());
        Assert.Equal(900, root.GetProperty("expiresInSeconds").GetInt32());
        Assert.Equal("usr_123", root.GetProperty("user").GetProperty("id").GetString());
        Assert.Equal("user@example.com", root.GetProperty("user").GetProperty("email").GetString());
        Assert.False(root.GetRawText().Contains("Password123!", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public async Task Login_WithMissingEmail_ReturnsStandardValidationEnvelope()
    {
        using var client = _factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/auth/login", new
        {
            email = "",
            password = "Password123!"
        });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        var text = await response.Content.ReadAsStringAsync();
        Assert.Contains("AUTH_VALIDATION_FAILED", text);
        Assert.Contains("correlationId", text);
        Assert.Contains("Email is required.", text);
        Assert.DoesNotContain("Password123!", text);
    }

    [Fact]
    public async Task Login_WithMissingPassword_ReturnsStandardValidationEnvelope()
    {
        using var client = _factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/auth/login", new
        {
            email = "user@example.com",
            password = ""
        });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        var text = await response.Content.ReadAsStringAsync();
        Assert.Contains("AUTH_VALIDATION_FAILED", text);
        Assert.Contains("Password is required.", text);
    }

    [Fact]
    public async Task Login_WithInvalidCredentials_ReturnsGenericUnauthorizedEnvelope()
    {
        using var client = _factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/auth/login", new
        {
            email = "user@example.com",
            password = "wrong-password"
        });

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);

        var text = await response.Content.ReadAsStringAsync();
        Assert.Contains("AUTH_INVALID_CREDENTIALS", text);
        Assert.Contains("Invalid email or password.", text);
        Assert.DoesNotContain("wrong-password", text);
        Assert.DoesNotContain("exists", text, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task Login_WithUnknownUser_ReturnsGenericUnauthorizedEnvelope()
    {
        using var client = _factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/auth/login", new
        {
            email = "missing@example.com",
            password = "Password123!"
        });

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);

        var text = await response.Content.ReadAsStringAsync();
        Assert.Contains("AUTH_INVALID_CREDENTIALS", text);
        Assert.DoesNotContain("missing@example.com", text);
        Assert.DoesNotContain("exists", text, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task Login_WithMalformedJson_ReturnsStandardErrorEnvelope()
    {
        using var client = _factory.CreateClient();
        using var content = new StringContent("{\"email\":\"user@example.com\",", Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/api/auth/login", content);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        var text = await response.Content.ReadAsStringAsync();
        Assert.Contains("REQUEST_MALFORMED", text);
        Assert.Contains("correlationId", text);
        Assert.DoesNotContain("user@example.com", text);
    }

    [Theory]
    [InlineData("locked@example.com")]
    [InlineData("disabled@example.com")]
    public async Task Login_WithUnavailableAccount_ReturnsSameGenericUnauthorizedEnvelope(string email)
    {
        using var client = _factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/auth/login", new
        {
            email,
            password = "Password123!"
        });

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);

        var text = await response.Content.ReadAsStringAsync();
        Assert.Contains("AUTH_INVALID_CREDENTIALS", text);
        Assert.DoesNotContain("locked", text, StringComparison.OrdinalIgnoreCase);
        Assert.DoesNotContain("disabled", text, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task Login_RecordsSafeAuditEventsForSuccessAndFailure()
    {
        var auditSink = new InMemoryAuditSink();
        var factory = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IAuditSink>(auditSink);
            });
        });

        using var client = factory.CreateClient();

        await client.PostAsJsonAsync("/api/auth/login", new
        {
            email = "user@example.com",
            password = "Password123!"
        });

        await client.PostAsJsonAsync("/api/auth/login", new
        {
            email = "user@example.com",
            password = "wrong-password"
        });

        Assert.Contains(auditSink.Events, item => item.EventType == "auth.login.succeeded");
        Assert.Contains(auditSink.Events, item => item.EventType == "auth.login.failed");

        var auditText = JsonSerializer.Serialize(auditSink.Events);
        Assert.DoesNotContain("Password123!", auditText);
        Assert.DoesNotContain("wrong-password", auditText);
        Assert.DoesNotContain("demo-token", auditText);
    }

    [Fact]
    public async Task Login_WithLockedUser_RecordsLockedOutAuditEvent()
    {
        var auditSink = new InMemoryAuditSink();
        var factory = _factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IAuditSink>(auditSink);
            });
        });

        using var client = factory.CreateClient();

        await client.PostAsJsonAsync("/api/auth/login", new
        {
            email = "locked@example.com",
            password = "Password123!"
        });

        Assert.Contains(auditSink.Events, item => item.EventType == "auth.login.locked_out");
    }
}
