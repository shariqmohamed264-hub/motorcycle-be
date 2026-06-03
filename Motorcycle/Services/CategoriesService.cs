using Microsoft.EntityFrameworkCore;
using Motorcycle.DTOs;
using Motorcycle.Interfaces;
using Motorcycle.Models;

namespace Motorcycle.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly MotorcycleDbContext _context;

        public CategoriesService(MotorcycleDbContext context)
        {
            _context = context;
        }
        public async Task<List<CategoryDto>> Get()
        {
            return await _context.Categories.Where(x => !x.IsDeleted)
                .Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Icon = x.Icon
                }).ToListAsync();
        }
    }
}
