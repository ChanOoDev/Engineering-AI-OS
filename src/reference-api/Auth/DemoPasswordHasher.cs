using System.Security.Cryptography;
using System.Text;

namespace ReferenceApi.Auth;

public static class DemoPasswordHasher
{
    public static readonly byte[] DummySalt = "missing-user-salt"u8.ToArray();
    public static readonly byte[] DummyHash = Hash("missing-user-password", DummySalt);

    // Reference-only helper. Production code should use ASP.NET Core Identity PasswordHasher
    // or another modern adaptive password hashing algorithm.
    public static byte[] Hash(string password, byte[] salt)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        var input = new byte[salt.Length + passwordBytes.Length];
        Buffer.BlockCopy(salt, 0, input, 0, salt.Length);
        Buffer.BlockCopy(passwordBytes, 0, input, salt.Length, passwordBytes.Length);

        return SHA256.HashData(input);
    }

    public static bool Verify(string password, byte[] salt, byte[] expectedHash)
    {
        var actualHash = Hash(password, salt);
        return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
    }
}
