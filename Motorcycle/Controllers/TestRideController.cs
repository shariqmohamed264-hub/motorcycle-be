using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Motorcycle.DTOs;
using Motorcycle.Interfaces;
using System.Security.Claims;

namespace Motorcycle.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin,User")]
    public class TestRideController : ControllerBase
    {
        private readonly ITestRideService _service;

        public TestRideController(ITestRideService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> BookTestRide(BookTestRideDto dto)
        {
            dto.UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            await _service.BookTestRide(dto);
            return Ok();
        }
    }
}
