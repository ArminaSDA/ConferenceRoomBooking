﻿using Final_Project_Conference_Room_Booking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Conference_Room_Booking.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userservice;

        public UserController(IUserService userservice)
        {
            _userservice = userservice;
        }
        public async Task<IActionResult> Index(DateTime dt)
        {
            var result = await _userservice.GetAllReservations(dt);
                                           
            return View(result);
        }
    }
}
