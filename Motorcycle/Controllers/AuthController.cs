using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Motorcycle.DTOs;
using Motorcycle.Interfaces;

namespace Motorcycle.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterInputDto request)
        {
            await _service.Register(request);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginInputDto request)
        {
            return Ok(await _service.Login(request));
        }

        [HttpPost]
        public async Task<IActionResult> Refresh(RefreshTokenInputDto request)
        {
            return Ok(await _service.Refresh(request));
        }

        [HttpPost]
        public async Task<IActionResult> Logout(RefreshTokenInputDto request)
        {
            await _service.Logout(request);
            return Ok();
        }
    }
}
