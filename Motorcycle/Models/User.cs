using System;
using System.Collections.Generic;

namespace Motorcycle.Models;

public partial class User
{
    public int Id { get; set; }

    public int RoleId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? GoogleId { get; set; }

    public string? ProfilePictureUrl { get; set; }

    public string? PhoneNumber { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool IsDeleted { get; set; }

    public string? PasswordHash { get; set; }

    public virtual ICollection<Brand> BrandCreatedByUsers { get; set; } = new List<Brand>();

    public virtual ICollection<Brand> BrandUpdatedByUsers { get; set; } = new List<Brand>();

    public virtual ICollection<Category> CategoryCreatedByUsers { get; set; } = new List<Category>();

    public virtual ICollection<Category> CategoryUpdatedByUsers { get; set; } = new List<Category>();

    public virtual ICollection<Dealer> DealerCreatedByUsers { get; set; } = new List<Dealer>();

    public virtual ICollection<Dealer> DealerUpdatedByUsers { get; set; } = new List<Dealer>();

    public virtual ICollection<Motorcycle> MotorcycleCreatedByUsers { get; set; } = new List<Motorcycle>();

    public virtual ICollection<Motorcycle> MotorcycleUpdatedByUsers { get; set; } = new List<Motorcycle>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<TestRideBooking> TestRideBookingCreatedByUsers { get; set; } = new List<TestRideBooking>();

    public virtual ICollection<TestRideBooking> TestRideBookingUpdatedByUsers { get; set; } = new List<TestRideBooking>();

    public virtual ICollection<TestRideBooking> TestRideBookingUsers { get; set; } = new List<TestRideBooking>();
}
