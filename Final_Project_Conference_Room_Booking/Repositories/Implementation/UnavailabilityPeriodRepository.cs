using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Repositories.Interfaces;
using Final_Project_Conference_Room_Booking.Services.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Conference_Room_Booking.Repositories.Implementation
{
    public class UnavailabilityPeriodRepository : IUnavailabilityPeriodRepository
    {
        private readonly ConferenceRoomBookingContext _context;

        public UnavailabilityPeriodRepository(ConferenceRoomBookingContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UnavailabilityPeriod>> GetAllUnavailabilityPeriod(DateTime data)
        {
            var result = await _context.UnavailabilityPeriods.Where(s => s.StartDate <= data && s.EndDate >= data).ToListAsync();
            return result;

        }
     

    }
}
