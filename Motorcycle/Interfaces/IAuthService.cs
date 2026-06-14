using Motorcycle.DTOs;

namespace Motorcycle.Interfaces
{
    public interface IAuthService
    {
        Task Register(RegisterInputDto request);

        Task<AuthResponseDto> Login(LoginInputDto request);

        Task<AuthResponseDto> Refresh(RefreshTokenInputDto request);

        Task Logout(RefreshTokenInputDto request);
    }
}
