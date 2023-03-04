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
    public class ReservationHolderController : Controller
    {
        private readonly IReservationHolderService _reservationHolderService;
       
        public ReservationHolderController(IReservationHolderService reservationHolderService)
        {
            _reservationHolderService = reservationHolderService;
            
        }
        public async Task<ActionResult> Index()
        {
            var rHoldersList = await _reservationHolderService.GetAllReservationHolders();
            return View(rHoldersList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(ReservationHolder reservationHolder)
        {
            if (ModelState.IsValid)
            {
                var result = await _reservationHolderService.Create(reservationHolder);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var reservation = await _reservationHolderService.FindReservationHolder(id);
            return View(reservation);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ReservationHolder reservationHolder)
        {
            if (ModelState.IsValid)
            {
                await _reservationHolderService.Edit(reservationHolder);
                return RedirectToAction("Index");

            }
            else
            {
                return View(reservationHolder);
            }
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
