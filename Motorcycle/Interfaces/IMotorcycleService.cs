using Motorcycle.DTOs;

namespace Motorcycle.Interfaces
{
    public interface IMotorcycleService
    {
        Task<BrandMotorcyclesDto> GetByBrand(int brandId);
        Task<CategoryMotorcyclesDto> GetByCategory(int categoryId);
        Task<MotorcycleDetailsDto> GetDetails(int id);
        Task<List<MotorcycleSearchDto>> Search(string keyword);
    }
}
