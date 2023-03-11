using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Services.Implementation;
using Final_Project_Conference_Room_Booking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;

namespace Final_Project_Conference_Room_Booking.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IConferenceRoomService _conferenceRoomService;
        public BookingController(IBookingService bookingService, IConferenceRoomService conferenceRoomService)
        {
            _bookingService = bookingService;
            _conferenceRoomService = conferenceRoomService; 
        }

        public async Task<ActionResult> Index()
        {
            var bookingList = await _bookingService.GetAllTheBookings();
            return View(bookingList);
        }

        public async Task<ActionResult> Create()
        {
            var conferenceRoomList = await _conferenceRoomService.GetAllConferenceRooms();
            ViewBag.ConferenceRoomList = conferenceRoomList; // ViewBag i dergon cRooms tek View
            return View();
        }
        public async Task<IActionResult> Edit(int Id)
        {

            var booking = await _bookingService.FindBooking(Id);
            if (booking == null)
            {
                return NotFound();
            }

            var bookings = await _conferenceRoomService.GetAllConferenceRooms();
            ViewBag.RoomId = new SelectList(bookings, "Id", "Code", booking.RoomId);

            return View(booking);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Booking booking)
        {
                var result = await _bookingService.Create(booking);

            return RedirectToAction("Index");
        }

    

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Booking booking)
        {
            
                await _bookingService.Edit(booking);
                return RedirectToAction("Index");
            
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var booking = await _bookingService.FindBooking(id);
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteBooking(int id)
        {
            await _bookingService.DeleteBooking(id);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Confirm(int id)
        {
            var booking = await _bookingService.FindBooking(id);
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmBooking(int id)
        {
            await _bookingService.Confirm(id);
            return RedirectToAction("Index");
        }
    }
}
