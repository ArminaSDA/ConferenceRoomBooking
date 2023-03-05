using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Services.Implementation;
using Final_Project_Conference_Room_Booking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_Project_Conference_Room_Booking.Controllers
{
    public class UnavailabilityPeriodController : Controller
    {
        private readonly IUnavailabilityPeriodService _unavailabilityPeriodService;
        private readonly IConferenceRoomService conferenceRoomService;

        public UnavailabilityPeriodController(IUnavailabilityPeriodService unavailabilityPeriodService, IConferenceRoomService conferenceRoomService)
        {
            _unavailabilityPeriodService = unavailabilityPeriodService;
            this.conferenceRoomService = conferenceRoomService;
        }
        public async Task<ActionResult> Index(DateTime dt)
        {
            var result = await _unavailabilityPeriodService.GetAllUnavailabilityPeriod(dt);

            return View(result);
        }
        public async Task<ActionResult> Create()
        {
            var cRooms = await conferenceRoomService.GetAllConferenceRooms();
            ViewBag.ConferenceRoomList = cRooms;
            return View();
        }


    }
}
