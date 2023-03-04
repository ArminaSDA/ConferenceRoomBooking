using Final_Project_Conference_Room_Booking.Models;

namespace Final_Project_Conference_Room_Booking.Repositories.Interfaces
{
    public interface IConferenceRoomRepository
    {
        Task<IEnumerable<ConferenceRoom>> GetAllConferenceRooms();




    }
}
