using Final_Project_Conference_Room_Booking.Models;

namespace Final_Project_Conference_Room_Booking.Services.Interfaces
{
    public interface IConferenceRoomService 
    {
        Task<IEnumerable<ConferenceRoom>> GetAllConferenceRooms();

    }
}
