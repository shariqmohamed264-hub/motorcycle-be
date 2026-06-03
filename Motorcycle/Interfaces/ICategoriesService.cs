using Motorcycle.DTOs;

namespace Motorcycle.Interfaces
{
    public interface ICategoriesService
    {
        Task<List<CategoryDto>> Get();
    }
}
