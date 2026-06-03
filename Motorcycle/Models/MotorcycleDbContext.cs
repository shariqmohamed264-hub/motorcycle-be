using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Motorcycle.Models;

public partial class MotorcycleDbContext : DbContext
{
    public MotorcycleDbContext()
    {
    }

    public MotorcycleDbContext(DbContextOptions<MotorcycleDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Dealer> Dealers { get; set; }

    public virtual DbSet<Motorcycle> Motorcycles { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<TestRideBooking> TestRideBookings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=MotorcycleDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Brands__3214EC07B6067D07");

            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ImageUrl).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.BrandCreatedByUsers)
                .HasForeignKey(d => d.CreatedByUserId)
                .HasConstraintName("FK_Brands_CreatedBy");

            entity.HasOne(d => d.UpdatedByUser).WithMany(p => p.BrandUpdatedByUsers)
                .HasForeignKey(d => d.UpdatedByUserId)
                .HasConstraintName("FK_Brands_UpdatedBy");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC07170F2FE1");

            entity.HasIndex(e => e.Name, "UQ__Categori__737584F6F38BA0B3").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Icon).HasMaxLength(100);
            entity.Property(e => e.ImageUrl).HasMaxLength(500);
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.CategoryCreatedByUsers)
                .HasForeignKey(d => d.CreatedByUserId)
                .HasConstraintName("FK_Categories_CreatedBy");

            entity.HasOne(d => d.UpdatedByUser).WithMany(p => p.CategoryUpdatedByUsers)
                .HasForeignKey(d => d.UpdatedByUserId)
                .HasConstraintName("FK_Categories_UpdatedBy");
        });

        modelBuilder.Entity<Dealer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Dealers__3214EC071D7D9898");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.State).HasMaxLength(100);

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.DealerCreatedByUsers)
                .HasForeignKey(d => d.CreatedByUserId)
                .HasConstraintName("FK_Dealers_CreatedBy");

            entity.HasOne(d => d.UpdatedByUser).WithMany(p => p.DealerUpdatedByUsers)
                .HasForeignKey(d => d.UpdatedByUserId)
                .HasConstraintName("FK_Dealers_UpdatedBy");
        });

        modelBuilder.Entity<Motorcycle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Motorcyc__3214EC07E5A379FB");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EngineCc).HasColumnName("EngineCC");
            entity.Property(e => e.FuelTankCapacity).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ImageUrl).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Mileage).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.WeightKg).HasColumnType("decimal(6, 2)");

            entity.HasOne(d => d.Brand).WithMany(p => p.Motorcycles)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Motorcycles_Brands");

            entity.HasOne(d => d.Category).WithMany(p => p.Motorcycles)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Motorcycles_Categories");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.MotorcycleCreatedByUsers)
                .HasForeignKey(d => d.CreatedByUserId)
                .HasConstraintName("FK_Motorcycles_CreatedBy");

            entity.HasOne(d => d.UpdatedByUser).WithMany(p => p.MotorcycleUpdatedByUsers)
                .HasForeignKey(d => d.UpdatedByUserId)
                .HasConstraintName("FK_Motorcycles_UpdatedBy");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07FC2E4B2C");

            entity.HasIndex(e => e.Name, "UQ__Roles__737584F67B6471D0").IsUnique();

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<TestRideBooking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TestRide__3214EC0717D26238");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Notes).HasMaxLength(1000);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.CreatedByUser).WithMany(p => p.TestRideBookingCreatedByUsers)
                .HasForeignKey(d => d.CreatedByUserId)
                .HasConstraintName("FK_TestRideBookings_CreatedBy");

            entity.HasOne(d => d.Dealer).WithMany(p => p.TestRideBookings)
                .HasForeignKey(d => d.DealerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TestRideBookings_Dealers");

            entity.HasOne(d => d.Motorcycle).WithMany(p => p.TestRideBookings)
                .HasForeignKey(d => d.MotorcycleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TestRideBookings_Motorcycles");

            entity.HasOne(d => d.UpdatedByUser).WithMany(p => p.TestRideBookingUpdatedByUsers)
                .HasForeignKey(d => d.UpdatedByUserId)
                .HasConstraintName("FK_TestRideBookings_UpdatedBy");

            entity.HasOne(d => d.User).WithMany(p => p.TestRideBookingUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TestRideBookings_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC076ECD74A9");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534E75D6996").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.GoogleId).HasMaxLength(200);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.ProfilePictureUrl).HasMaxLength(500);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
