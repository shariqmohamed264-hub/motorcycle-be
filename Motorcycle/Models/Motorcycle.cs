using System;
using System.Collections.Generic;

namespace Motorcycle.Models;

public partial class Motorcycle
{
    public int Id { get; set; }

    public int BrandId { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int EngineCc { get; set; }

    public decimal? Mileage { get; set; }

    public int? TopSpeed { get; set; }

    public decimal? FuelTankCapacity { get; set; }

    public decimal? WeightKg { get; set; }

    public int? LaunchYear { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CreatedByUserId { get; set; }

    public int? UpdatedByUserId { get; set; }

    public bool IsDeleted { get; set; }

    public string? ImageUrl { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual User? CreatedByUser { get; set; }

    public virtual ICollection<TestRideBooking> TestRideBookings { get; set; } = new List<TestRideBooking>();

    public virtual User? UpdatedByUser { get; set; }
}
