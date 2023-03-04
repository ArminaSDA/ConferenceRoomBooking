using Final_Project_Conference_Room_Booking.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Conference_Room_Booking.Controllers
{
    public class LogInController : Controller
    {

        private readonly ILogger<LogInController> _logger;
        private readonly ILoginRepository _loginUser;

        public LogInController(ILogger<LogInController> logger, ILoginRepository loginUser)
        {
            _logger = logger;
            _loginUser = loginUser;

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string email, string Password)
        {
            var issuccess = _loginUser.AuthenticateUser(email, Password);


            if (issuccess.Result != null)
            {

                //ViewBag.username = string.Format("Successfully logged-in", username);
                //RedirectToAction (string actionName, string controllerName);
                //return View();  
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.username = string.Format("Login Failed ", email);
                return View();
            }
        }
    }
}
