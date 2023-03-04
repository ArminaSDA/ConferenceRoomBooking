using Final_Project_Conference_Room_Booking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Conference_Room_Booking.Controllers
{
    public class ConferenceRoomController : Controller
    {
        private readonly IConferenceRoomService _conferenceroomservice;

        public ConferenceRoomController(IConferenceRoomService conferenceroomservice)
        {
            _conferenceroomservice = conferenceroomservice;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _conferenceroomservice.GetAllConferenceRooms();
            return View(result);
        }
    }
}
