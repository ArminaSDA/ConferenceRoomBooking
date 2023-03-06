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
        private readonly IConferenceRoomService _conferenceRoomService;

        public UnavailabilityPeriodController(IUnavailabilityPeriodService unavailabilityPeriodService, IConferenceRoomService conferenceRoomService)
        {
            _unavailabilityPeriodService = unavailabilityPeriodService;
            _conferenceRoomService = conferenceRoomService;
        }
        public async Task<ActionResult> Index()
        {
            var result = await _unavailabilityPeriodService.GetAllUnavailabilityPeriod();

            return View(result);
        }
        public async Task<ActionResult> Create()
        {
            var conferenceRoomList = await _conferenceRoomService.GetAllConferenceRooms();
            ViewBag.ConferenceRoomList = conferenceRoomList; // ViewBag i dergon cRooms tek View
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(UnavailabilityPeriod unavailabilityPeriod)
        {
            var result = await _unavailabilityPeriodService.Create(unavailabilityPeriod);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var booking = await _unavailabilityPeriodService.FindUnavailabilityPeriod(id);
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UnavailabilityPeriod unavailabilityPeriod)
        {

            await _unavailabilityPeriodService.Edit(unavailabilityPeriod);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var booking = await _unavailabilityPeriodService.FindUnavailabilityPeriod(id);
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteUnavailabilityPeriod(int id)
        {
            await _unavailabilityPeriodService.DeleteUnavailabilityPeriod(id);
            return RedirectToAction("Index");
        }
    }
}
