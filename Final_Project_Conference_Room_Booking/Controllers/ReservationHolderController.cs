using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Services.Implementation;
using Final_Project_Conference_Room_Booking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Linq;
using System.Net;


namespace Final_Project_Conference_Room_Booking.Controllers
{
    public class ReservationHolderController : Controller
    {
        private readonly IReservationHolderService _reservationHolderService;
        private readonly IBookingService _bookingService;
       
        public ReservationHolderController(IReservationHolderService reservationHolderService, IBookingService bookingService)
        {
            _reservationHolderService = reservationHolderService;
            _bookingService = bookingService;   
        }

        public async Task<ActionResult> Index()
        {
            var rHoldersList = await _reservationHolderService.GetAllReservationHolders();
            return View(rHoldersList);
        }
        public async Task<ActionResult> Create()
        {
            var bookingList = await _bookingService.GetAllTheBookings();
            ViewBag.BookingList = bookingList;
            return View();
        }
        public async Task<IActionResult> Edit(int Id)
        {

            var reservationHolder = await _reservationHolderService.FindReservationHolder(Id);
            if (reservationHolder == null)
            {
                return NotFound();
            }

            var bookings = await _bookingService.GetAllTheBookings();
            ViewBag.BookingId = new SelectList(bookings, "Id", "Code", reservationHolder.BookingId);

            return View(reservationHolder);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(ReservationHolder reservationHolder)
        {
            var result = await _reservationHolderService.Create(reservationHolder);
            return RedirectToAction("Index");
        }

     

        [HttpPost]
        public async Task<ActionResult> Edit(ReservationHolder reservationHolder)
        {
                await _reservationHolderService.Edit(reservationHolder);
                return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var reservation = await _reservationHolderService.FindReservationHolder(id);
            return View(reservation);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteReservationHolder(int id)
        {
            await _reservationHolderService.DeleteReservationHolder(id);
            return RedirectToAction("Index");
        }
    }
}
