using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Conference_Room_Booking.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ConferenceRoomBookingContext _context;

        public UserRepository(ConferenceRoomBookingContext context)
        {
            _context = context;   
        }
       public async Task<IEnumerable<Booking>> GetAllReservations(DateTime data)
        {
            var result = await  _context.Bookings.Where(s =>s.StartDate <= data&& s.EndDate >= data).ToListAsync(); 

            return result;

        }
    }
}
