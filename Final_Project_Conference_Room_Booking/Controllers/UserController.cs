using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Conference_Room_Booking.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
