using Motorcycle.DTOs;

namespace Motorcycle.Interfaces
{
    public interface IBrandsService
    {
        Task<List<BrandDto>> Get();
    }
}
