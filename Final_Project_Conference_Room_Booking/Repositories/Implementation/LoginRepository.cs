//using Final_Project_Conference_Room_Booking.Models;
//using Final_Project_Conference_Room_Booking.Repositories.Interfaces;
//using Microsoft.EntityFrameworkCore;

//namespace Final_Project_Conference_Room_Booking.Repositories.Implementation
//{
//    public class LoginRepository : ILoginRepository
//    {
//        private readonly ConferenceRoomBookingContext _context;

//        public LoginRepository(ConferenceRoomBookingContext context)
//        {
//            _context = context;
//        }

//        public async Task<ApplicationUser> AuthenticateUser(string email, string passcode)
//        {
//            var succeeded = await _context.ApplicationUsers.FirstOrDefaultAsync(authUser => authUser.Email == email);
//            return succeeded;
//        }

//        public async Task<IEnumerable<ApplicationUser>> getuser()
//        {
//            return await _context.ApplicationUsers.ToListAsync();
//        }
//    }
//}
