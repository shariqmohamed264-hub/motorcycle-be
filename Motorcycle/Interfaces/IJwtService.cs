using Motorcycle.Models;

namespace Motorcycle.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        string GenerateRefreshToken();
    }
}
