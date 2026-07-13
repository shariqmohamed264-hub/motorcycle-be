using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Motorcycle.Interfaces;
using Motorcycle.Models;

namespace Motorcycle.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Admin,User")]
public class BrandsController : ControllerBase
{
    private readonly IBrandsService _service;

    public BrandsController(IBrandsService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {

        return Ok(await _service.Get());
    }
}