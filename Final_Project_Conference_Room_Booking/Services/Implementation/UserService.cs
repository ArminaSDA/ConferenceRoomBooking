using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Repositories.Interfaces;
using Final_Project_Conference_Room_Booking.Services.Interfaces;

namespace Final_Project_Conference_Room_Booking.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userrepository;

        public UserService(IUserRepository userrepository)
        {
            _userrepository = userrepository;
        }

       public async Task<IEnumerable<Booking>> GetAllReservations(DateTime data)
        {
            return await _userrepository.GetAllReservations(data);
        }
    }
}
