using System;
using System.Collections.Generic;

namespace Motorcycle.Models;

public partial class Brand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Country { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? CreatedByUserId { get; set; }

    public int? UpdatedByUserId { get; set; }

    public bool IsDeleted { get; set; }

    public string? ImageUrl { get; set; }

    public virtual User? CreatedByUser { get; set; }

    public virtual ICollection<Motorcycle> Motorcycles { get; set; } = new List<Motorcycle>();

    public virtual User? UpdatedByUser { get; set; }
}
