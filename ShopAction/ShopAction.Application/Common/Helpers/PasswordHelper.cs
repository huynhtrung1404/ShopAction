using System.Security.Cryptography;

namespace ShopAction.Application.Common.Helpers;

public class PasswordHelper
{
    private const int SaltSize = 16;        // 128 bit
    private const int HashSize = 32;        // 256 bit
    private const int Iterations = 210_000; // OWASP 2023
    private const string Prefix = "$pbkdf2-sha256$";

    public static string Hash(string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentException("No data found", nameof(password));

        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            password: password,
            salt: salt,
            iterations: Iterations,
            hashAlgorithm: HashAlgorithmName.SHA256,
            outputLength: HashSize);

        return $"{Prefix}{Iterations}${Convert.ToBase64String(salt)}${Convert.ToBase64String(hash)}";
    }

    public static bool Verify(string password, string storedHash)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(storedHash))
            return false;

        // 1. Parse format
        if (!storedHash.StartsWith(Prefix, StringComparison.Ordinal))
            return false;

        var parts = storedHash[Prefix.Length..].Split('$');
        if (parts.Length != 3)
            return false;

        // 2. Extract iterations, salt, hash
        if (!int.TryParse(parts[0], out var iterations) || iterations < 1)
            return false;

        byte[] salt, expectedHash;
        try
        {
            salt = Convert.FromBase64String(parts[1]);
            expectedHash = Convert.FromBase64String(parts[2]);
        }
        catch (FormatException)
        {
            return false;
        }

        var actualHash = Rfc2898DeriveBytes.Pbkdf2(
            password: password,
            salt: salt,
            iterations: iterations,
            hashAlgorithm: HashAlgorithmName.SHA256,
            outputLength: expectedHash.Length);

        return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
    }

    public static bool NeedsRehash(string storedHash)
    {
        if (string.IsNullOrEmpty(storedHash)
            || !storedHash.StartsWith(Prefix, StringComparison.Ordinal))
            return true;

        var parts = storedHash[Prefix.Length..].Split('$');
        if (parts.Length != 3 || !int.TryParse(parts[0], out var iterations))
            return true;

        return iterations < Iterations;
    }
}