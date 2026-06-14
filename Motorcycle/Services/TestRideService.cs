using Microsoft.EntityFrameworkCore;
using Motorcycle.DTOs;
using Motorcycle.Interfaces;
using Motorcycle.Models;

namespace Motorcycle.Services
{
    public class TestRideService : ITestRideService
    {
        private readonly MotorcycleDbContext _context;

        public TestRideService(MotorcycleDbContext context)
        {
            _context = context;
        }

        public async Task BookTestRide(BookTestRideDto dto)
        {
            var motorcycle =
            await _context.Motorcycles
            .FindAsync(
            dto.MotorcycleId);

            if (motorcycle == null)
            {
                throw new Exception("Motorcycle not found");
            }

            var slotExists = await _context.TestRideBookings.AnyAsync(x => x.MotorcycleId == dto.MotorcycleId
            && x.BookingDate == dto.BookingDate && x.UserId == dto.UserId);

            if (slotExists) throw new Exception("You already booked this motorcycle");

            var booking = new TestRideBooking
            {
                UserId = dto.UserId,
                MotorcycleId = dto.MotorcycleId,
                BookingDate = dto.BookingDate,
                CreatedAt = DateTime.Now,
                CreatedByUserId = dto.UserId,
                UpdatedAt = DateTime.Now,
                UpdatedByUserId = dto.UserId
            };
            await _context.TestRideBookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }
    }
    }
