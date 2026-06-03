namespace Motorcycle.DTOs
{
    public class BrandMotorcyclesDto
    {
        public int BrandId { get; set; }

        public string? BrandName { get; set; }

        public string? BrandImageUrl { get; set; }

        public List<MotorcycleDto>? Motorcycles { get; set; }
    }
}
