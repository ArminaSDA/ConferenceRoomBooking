using Final_Project_Conference_Room_Booking.Models;

namespace Final_Project_Conference_Room_Booking.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        Task<IEnumerable<ApplicationUser>> getuser();
        Task<ApplicationUser> AuthenticateUser(string username, string passcode);
    }
}
