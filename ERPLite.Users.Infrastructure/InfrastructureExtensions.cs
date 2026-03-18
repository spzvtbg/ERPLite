namespace ERPLite.Users.Infrastructure
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Extension methods for the infrastructure layer, 
    /// providing additional functionality such as hashing passwords using SHA-512.
    /// </summary>
    public static class InfrastructureExtensions
    {
        /// <summary>
        /// Creates a SHA-512 hash of the given token and returns it as a Base64 string.
        /// </summary>
        /// <param name="password"><see cref="System.String"/></param>
        /// <returns><see cref="System.String"/></returns>
        public static string HashSHA512(this string token)
        {
            // Initialize the hash result as an empty string.
            // If the input token is null, empty, or consists only of whitespace,
            // the method will return this default value.
            var hashSHA512 = default(string);
            
            if (!string.IsNullOrWhiteSpace(token))
            {
                // Convert the input token to a byte array using UTF-8 encoding,
                var bytes = Encoding.UTF8.GetBytes(token);
                // Compute the SHA-512 hash of the byte array using the SHA512,
                var hashBytes = SHA512.HashData(bytes);
                // Convert the resulting hash byte array to a Base64 string for easier storage and representation.
                hashSHA512 = Convert.ToHexString(hashBytes);
            }

            // Return the computed hash as a Base64 string, or an empty string if the input token was invalid.
            return hashSHA512;
        }
    }
}
