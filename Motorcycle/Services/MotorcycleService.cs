using Microsoft.EntityFrameworkCore;
using Motorcycle.DTOs;
using Motorcycle.Interfaces;
using Motorcycle.Models;

namespace Motorcycle.Services
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly MotorcycleDbContext _context;

        public MotorcycleService(MotorcycleDbContext context)
        {
            _context = context;
        }
        public async Task<BrandMotorcyclesDto> GetByBrand(int brandId)
        {
            return await _context.Brands
                        .Include(x => x.Motorcycles)
                        .Where(b => b.Id == brandId)
                        .Select(b => new BrandMotorcyclesDto
                        {
                            BrandId = b.Id,
                            BrandName = b.Name,
                            BrandImageUrl = b.ImageUrl,

                            Motorcycles = b.Motorcycles
                                .Select(m => new MotorcycleDto
                                {
                                    Id = m.Id,
                                    Name = m.Name,
                                    Price = m.Price,
                                    EngineCc = m.EngineCc,
                                    ImageUrl = m.ImageUrl
                                })
                                .ToList()
                        })
                        .FirstOrDefaultAsync()?? new BrandMotorcyclesDto();
        }

        public async Task<CategoryMotorcyclesDto> GetByCategory(int categoryId)
        {
            return await _context.Categories
                        .Include(x => x.Motorcycles)
                        .Where(b => b.Id == categoryId)
                        .Select(b => new CategoryMotorcyclesDto
                        {
                            CategoryId = b.Id,
                            CategoryName = b.Name,
                            CategoryImageUrl = b.ImageUrl,

                            Motorcycles = b.Motorcycles
                                .Select(m => new MotorcycleDto
                                {
                                    Id = m.Id,
                                    Name = m.Name,
                                    Price = m.Price,
                                    EngineCc = m.EngineCc,
                                    ImageUrl = m.ImageUrl
                                })
                                .ToList()
                        })
                        .FirstOrDefaultAsync() ?? new CategoryMotorcyclesDto();
        }

        public async Task<MotorcycleDetailsDto> GetDetails(int id)
        {
            return await _context.Motorcycles.AsNoTracking()
                .Where(x => x.Id == id)
                .Select(m => new MotorcycleDetailsDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    Description = m.Description,
                    Price = m.Price,
                    EngineCc = m.EngineCc,
                    Mileage = m.Mileage ?? 0,
                    TopSpeed = m.TopSpeed ?? 0,
                    FuelTankCapacity = m.FuelTankCapacity ?? 0,
                    WeightKg = m.WeightKg ?? 0,
                    LaunchYear = m.LaunchYear ?? 0,
                    ImageUrl = m.ImageUrl,
                    BrandName = m.Brand.Name,
                    CategoryName = m.Category.Name
                })
                .FirstOrDefaultAsync() ?? new MotorcycleDetailsDto();
        }

        public async Task<List<MotorcycleSearchDto>> Search(string keyword)
        {
            keyword = keyword.ToLower();

            return await _context.Motorcycles.AsNoTracking()

                .Where(m =>

                    m.Name.ToLower().Contains(keyword)

                    ||

                    m.Brand.Name.ToLower()
                        .Contains(keyword)

                    ||

                    m.Category.Name.ToLower()
                        .Contains(keyword)
                )

                .Select(m => new MotorcycleSearchDto
                {
                    Id = m.Id,

                    Name = m.Name,

                    BrandName = m.Brand.Name,

                    CategoryName = m.Category.Name,

                    ImageUrl = m.ImageUrl
                })

                .Take(10)

                .ToListAsync();
        }
    }
}
