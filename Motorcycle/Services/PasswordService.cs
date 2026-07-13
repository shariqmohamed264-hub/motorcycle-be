using Motorcycle.Interfaces;
using BCrypt.Net;

namespace Motorcycle.Services
{
    public class PasswordService : IPasswordService
    {
        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool Verify(
            string password,
            string hash)
        {
            return BCrypt.Net.BCrypt.Verify(
                password,
                hash);
        }
    }
}
