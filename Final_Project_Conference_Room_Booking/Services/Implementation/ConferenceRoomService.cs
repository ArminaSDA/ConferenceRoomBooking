using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Repositories.Interfaces;
using Final_Project_Conference_Room_Booking.Services.Interfaces;

namespace Final_Project_Conference_Room_Booking.Services.Implementation
{
    public class ConferenceRoomService : IConferenceRoomService
    {
        private readonly IConferenceRoomRepository _conferenceroomrepository;

        public ConferenceRoomService(IConferenceRoomRepository conferenceroomrepository)
        {
            _conferenceroomrepository = conferenceroomrepository;
        }

        public async Task<IEnumerable<ConferenceRoom>> GetAllConferenceRooms()
        {
            var result = await _conferenceroomrepository.GetAllConferenceRooms();

            return result; 

        }
    }
}
