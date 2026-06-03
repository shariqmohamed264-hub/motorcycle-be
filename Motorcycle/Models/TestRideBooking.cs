using System;
using System.Collections.Generic;

namespace Motorcycle.Models;

public partial class TestRideBooking
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int MotorcycleId { get; set; }

    public int DealerId { get; set; }

    public DateTime BookingDate { get; set; }

    public string Status { get; set; } = null!;

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CreatedByUserId { get; set; }

    public int? UpdatedByUserId { get; set; }

    public bool IsDeleted { get; set; }

    public virtual User? CreatedByUser { get; set; }

    public virtual Dealer Dealer { get; set; } = null!;

    public virtual Motorcycle Motorcycle { get; set; } = null!;

    public virtual User? UpdatedByUser { get; set; }

    public virtual User User { get; set; } = null!;
}
