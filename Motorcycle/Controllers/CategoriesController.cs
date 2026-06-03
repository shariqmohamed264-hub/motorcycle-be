using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Motorcycle.Interfaces;
using Motorcycle.Models;

namespace Motorcycle.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoriesService _service;

    public CategoriesController(ICategoriesService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.Get());
    }
}