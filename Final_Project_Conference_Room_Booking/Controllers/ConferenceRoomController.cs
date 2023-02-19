using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Conference_Room_Booking.Controllers
{
    public class ConferenceRoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
