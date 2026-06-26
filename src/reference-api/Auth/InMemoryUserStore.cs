using System.Collections.Concurrent;

namespace ReferenceApi.Auth;

public interface IUserStore
{
    Task<DemoUser?> FindByEmailAsync(string normalizedEmail);
}

public sealed class InMemoryUserStore : IUserStore
{
    private static readonly byte[] ActiveUserSalt = "active-user-salt"u8.ToArray();
    private static readonly byte[] LockedUserSalt = "locked-user-salt"u8.ToArray();
    private static readonly byte[] DisabledUserSalt = "disabled-user-salt"u8.ToArray();

    private readonly ConcurrentDictionary<string, DemoUser> _users = new(StringComparer.OrdinalIgnoreCase);

    public InMemoryUserStore()
    {
        AddUser(new DemoUser(
            "usr_123",
            "user@example.com",
            "Example User",
            ["User"],
            AccountStatus.Active,
            ActiveUserSalt,
            DemoPasswordHasher.Hash("Password123!", ActiveUserSalt)));

        AddUser(new DemoUser(
            "usr_locked",
            "locked@example.com",
            "Locked User",
            ["User"],
            AccountStatus.Locked,
            LockedUserSalt,
            DemoPasswordHasher.Hash("Password123!", LockedUserSalt)));

        AddUser(new DemoUser(
            "usr_disabled",
            "disabled@example.com",
            "Disabled User",
            ["User"],
            AccountStatus.Disabled,
            DisabledUserSalt,
            DemoPasswordHasher.Hash("Password123!", DisabledUserSalt)));
    }

    public Task<DemoUser?> FindByEmailAsync(string normalizedEmail)
    {
        _users.TryGetValue(normalizedEmail, out var user);
        return Task.FromResult(user);
    }

    private void AddUser(DemoUser user)
    {
        _users[user.Email.ToUpperInvariant()] = user;
    }
}
