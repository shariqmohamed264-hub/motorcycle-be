using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Motorcycle.Interfaces;
using Motorcycle.Models;

namespace Motorcycle.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize(Roles = "Admin,User")]
public class MotorcycleController : ControllerBase
{
    private readonly IMotorcycleService _service;

    public MotorcycleController(IMotorcycleService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetByBrand([FromQuery] int brandId)
    {
        return Ok(await _service.GetByBrand(brandId));
    }

    [HttpGet]
    public async Task<IActionResult> GetByCategory([FromQuery] int categoryId)
    {
        return Ok(await _service.GetByCategory(categoryId));
    }

    [HttpGet]
    public async Task<IActionResult> GetDetails([FromQuery] int id)
    {
        return Ok(await _service.GetDetails(id));
    }

    [HttpGet]
    public async Task<IActionResult> Search([FromQuery] string keyword)
    {
        return Ok(await _service.Search(keyword));
    }

}