//using Final_Project_Conference_Room_Booking.Models;
//using Final_Project_Conference_Room_Booking.Services.Interfaces;
//using Microsoft.AspNetCore.Mvc;

//namespace Final_Project_Conference_Room_Booking.Controllers
//{
//    public class UserController : Controller
//    {
//        private readonly IUserService _userservice;

//        private readonly IBookingService _bookingService;

//        public UserController(IUserService userservice, IBookingService bookingService)
//        {
//            _userservice = userservice;
//            _bookingService = bookingService;
//        }
//        public async Task<IActionResult> Index(DateTime dt)
//        {
//            var result = await _userservice.GetAllReservations(dt);
                                           
//            return View(result);
//        }

//        [HttpGet]
//        public async Task<ActionResult> Delete(int id)
//        {
//            var booking = await _bookingService.FindBooking(id);
//            return View(booking);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> DeleteBooking(int id)
//        {
//            await _bookingService.DeleteBooking(id);
//            return RedirectToAction("Index");
//        }


//    }
//}   
