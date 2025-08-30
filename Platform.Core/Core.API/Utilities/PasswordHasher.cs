namespace Core.API.Utilities;
using System.Security.Cryptography;

public static class PasswordHasher
{
    // Hash a password with a salt
    public static string HashPassword(string password)
    {
        // Generate a random salt
        using var rng = RandomNumberGenerator.Create();
        byte[] salt = new byte[16];
        rng.GetBytes(salt);

        // Derive the key
        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
        byte[] hash = pbkdf2.GetBytes(32);

        // Store salt + hash together (Base64 encoded)
        byte[] hashBytes = new byte[salt.Length + hash.Length];
        Buffer.BlockCopy(salt, 0, hashBytes, 0, salt.Length);
        Buffer.BlockCopy(hash, 0, hashBytes, salt.Length, hash.Length);

        return Convert.ToBase64String(hashBytes);
    }

    // Verify password against stored hash
    public static bool VerifyPassword(string password, string storedHash)
    {
        byte[] hashBytes = Convert.FromBase64String(storedHash);

        // Extract salt
        byte[] salt = new byte[16];
        Buffer.BlockCopy(hashBytes, 0, salt, 0, salt.Length);

        // Extract actual hash
        byte[] storedSubHash = new byte[32];
        Buffer.BlockCopy(hashBytes, salt.Length, storedSubHash, 0, storedSubHash.Length);

        // Recompute hash with given password
        using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000, HashAlgorithmName.SHA256);
        byte[] newHash = pbkdf2.GetBytes(32);

        // Compare byte by byte
        return CryptographicOperations.FixedTimeEquals(storedSubHash, newHash);
    }
}
