using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Conference_Room_Booking.Repositories.Implementation
{
    public class ConferenceRoomRepository : IConferenceRoomRepository
    {
        private readonly ConferenceRoomBookingContext _context;

        public ConferenceRoomRepository(ConferenceRoomBookingContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ConferenceRoom>> GetAllConferenceRooms()

        {
            var result = await _context.ConferenceRooms.ToListAsync();

            return result;


        }
    }
}
