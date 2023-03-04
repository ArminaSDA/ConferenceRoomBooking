using Final_Project_Conference_Room_Booking.Models;
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

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task<ActionResult> Index()
        {
            var bookingList = await _bookingService.GetAllTheBookings();
            return View(bookingList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                var result = await _bookingService.Create(booking);
                if (result != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "An error occurred while creating the booking.");
                }
            }
            return View(booking);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var booking = await _bookingService.FindBooking(id);
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Booking booking)
        {
            if (ModelState.IsValid)
            {
                await _bookingService.Edit(booking);
                return RedirectToAction("Index");
            }
            else
            {
                return View(booking);
            }
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
    }
}
