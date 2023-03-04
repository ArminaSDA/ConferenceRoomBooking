using Final_Project_Conference_Room_Booking.Models;

namespace Final_Project_Conference_Room_Booking.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        Task<IEnumerable<User>> getuser();
        Task<User> AuthenticateUser(string username, string passcode);
    }
}
