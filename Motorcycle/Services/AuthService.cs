using Microsoft.EntityFrameworkCore;
using Motorcycle.DTOs;
using Motorcycle.Interfaces;
using Motorcycle.Models;

namespace Motorcycle.Services
{
    public class AuthService : IAuthService
    {
        private readonly MotorcycleDbContext _context;
        private readonly IPasswordService _passwordService;
        private readonly IJwtService _jwtService;

        public AuthService(MotorcycleDbContext context, IPasswordService passwordService, IJwtService jwtService)
        {
            _context = context;
            _passwordService = passwordService;
            _jwtService = jwtService;
        }
        public async Task Register(RegisterInputDto request)
        {
            if (await _context.Users
                .AnyAsync(x =>
                    x.Email == request.Email))
            {
                throw new Exception(
                    "Email already exists");
            }

            var user = new User
            {
                Name = request.Name,

                Email = request.Email,

                PasswordHash =
                    _passwordService.Hash(
                        request.Password),

                RoleId = await _context.Roles
                        .Where(x => x.Name == "User")
                        .Select(x => x.Id).FirstOrDefaultAsync(),

                CreatedAt =
                    DateTime.UtcNow
            };

            _context.Users.Add(user);

            await _context.SaveChangesAsync();
        }

        public async Task<AuthResponseDto> Login(LoginInputDto request)
        {
            var user =
                await _context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x =>
                    x.Email ==
                    request.Email);

            if (user == null)
            {
                throw new Exception(
                    "Invalid credentials");
            }

            var valid =
                _passwordService.Verify(
                    request.Password,
                    user.PasswordHash ?? "");

            if (!valid)
            {
                throw new Exception(
                    "Invalid credentials");
            }

            var accessToken = _jwtService.GenerateToken(user);

            var refreshToken = _jwtService.GenerateRefreshToken();

            _context.RefreshTokens.Add(
                        new RefreshToken
                        {
                            UserId = user.Id,

                            Token = refreshToken,

                            ExpiresAt =
                                DateTime.UtcNow
                                    .AddDays(7),

                            CreatedAt =
                                DateTime.UtcNow
                        });
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                Token = accessToken,

                RefreshToken = refreshToken,

                UserName =
                    user.Name,

                Role =
                    user.Role.Name
            };
        }

        public async Task<AuthResponseDto> Refresh(RefreshTokenInputDto request)
        {
            var refreshToken = await _context.RefreshTokens
                                .Include(x => x.User)
                                .ThenInclude(x => x.Role)
                                .FirstOrDefaultAsync(x =>
                                    x.Token ==
                                    request.RefreshToken);
            if (refreshToken == null)
            {
                throw new Exception("Unauthorized");
            }

            if (refreshToken.IsRevoked)
            {
                throw new Exception("Unauthorized");
            }

            if (refreshToken.ExpiresAt <
                DateTime.UtcNow)
            {
                throw new Exception("Unauthorized");
            }
            refreshToken.IsRevoked = true;
            var accessToken = _jwtService.GenerateToken(refreshToken.User);

            var newRefreshToken = _jwtService.GenerateRefreshToken();
            _context.RefreshTokens.Add(
            new RefreshToken
            {
                UserId =
                    refreshToken.UserId,

                Token =
                    newRefreshToken,

                ExpiresAt =
                    DateTime.UtcNow
                        .AddDays(7),

                CreatedAt =
                    DateTime.UtcNow
            });
            await _context.SaveChangesAsync();
            return 
            new AuthResponseDto
            {
                Token =
                    accessToken,

                RefreshToken =
                    newRefreshToken,

                UserName =
                    refreshToken.User.Name,

                Role =
                    refreshToken.User.Role.Name
            };
        }

        public async Task Logout(RefreshTokenInputDto request)
        {
            var refreshToken = await _context.RefreshTokens
            .FirstOrDefaultAsync(x =>
            x.Token ==
            request.RefreshToken);
            if (refreshToken == null)
            {
                throw new Exception("Logout failed");
            }
            refreshToken.IsRevoked = true;

            await _context.SaveChangesAsync();
        }
    }
    }
