using Final_Project_Conference_Room_Booking.Models;

namespace Final_Project_Conference_Room_Booking.Services.Interfaces;

public interface IConferenceRoomService
{
    Task<List<ConferenceRoom>> GetAllConferenceRooms();
    Task<ConferenceRoom> Create(ConferenceRoom conferenceRoom);
    Task<ConferenceRoom> DeleteConferenceRoom(int id);
    Task<ConferenceRoom> FindConferenceRoom(int id);
    Task<ConferenceRoom> Edit(int id);
    Task<ConferenceRoom> Edit(ConferenceRoom conferenceRoom);
}
