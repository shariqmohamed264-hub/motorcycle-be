using Motorcycle.DTOs;

namespace Motorcycle.Interfaces
{
    public interface ITestRideService
    {
        Task BookTestRide(BookTestRideDto dto); 
    }
}
