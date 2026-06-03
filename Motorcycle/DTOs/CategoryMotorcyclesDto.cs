namespace Motorcycle.DTOs
{
    public class CategoryMotorcyclesDto
    {
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public string? CategoryImageUrl { get; set; }

        public List<MotorcycleDto>? Motorcycles { get; set; }
    }
}
