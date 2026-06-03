using Microsoft.EntityFrameworkCore;
using Motorcycle.DTOs;
using Motorcycle.Interfaces;
using Motorcycle.Models;

namespace Motorcycle.Services
{
    public class BrandsService : IBrandsService
    {
        private readonly MotorcycleDbContext _context;

        public BrandsService(MotorcycleDbContext context)
        {
            _context = context;
        }
        public async Task<List<BrandDto>> Get()
        {
            return await _context.Brands.Where(x => !x.IsDeleted)
                .Select(x => new BrandDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl = x.ImageUrl
                }).ToListAsync();
        }
    }
}
