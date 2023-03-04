using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Conference_Room_Booking.Repositories.Implementation
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ConferenceRoomBookingContext _context;

        public LoginRepository(ConferenceRoomBookingContext context)
        {
            _context = context;
        }

        public async Task<User> AuthenticateUser(string email, string passcode)
        {
            var succeeded = await _context.Users.FirstOrDefaultAsync(authUser => authUser.Email == email && authUser.Password == passcode);
            return succeeded;
        }

        public async Task<IEnumerable<User>> getuser()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
