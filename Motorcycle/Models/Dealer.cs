using System;
using System.Collections.Generic;

namespace Motorcycle.Models;

public partial class Dealer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public string? State { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CreatedByUserId { get; set; }

    public int? UpdatedByUserId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual User? CreatedByUser { get; set; }

    public virtual ICollection<TestRideBooking> TestRideBookings { get; set; } = new List<TestRideBooking>();

    public virtual User? UpdatedByUser { get; set; }
}
