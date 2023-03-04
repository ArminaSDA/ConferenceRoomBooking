using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Services.Implementation;
using Final_Project_Conference_Room_Booking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Final_Project_Conference_Room_Booking.Controllers;

public class ConferenceRoomController : Controller
{
    private readonly IConferenceRoomService _conferenceRoomService;
   
    public ConferenceRoomController(IConferenceRoomService conferenceRoomService)
    {
        _conferenceRoomService = conferenceRoomService;
       
    }
    public async Task<ActionResult> Index()
    {
        var conferenceRoomList = await _conferenceRoomService.GetAllConferenceRooms();
        return View(conferenceRoomList);
    }
    public ActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(ConferenceRoom conferenceRoom)
    {
        if (ModelState.IsValid)
        {
            var result = await _conferenceRoomService.Create(conferenceRoom);
            if (result != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "An error occurred while creating the booking.");
            }
        }
        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<ActionResult> Edit(int id)
    {
        var conferenceRoom = await _conferenceRoomService.FindConferenceRoom(id);
        return View(conferenceRoom);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(ConferenceRoom conferenceRoom)
    {
        if (ModelState.IsValid)
        {
            await _conferenceRoomService.Edit(conferenceRoom);
            return RedirectToAction("Index");
        }
        else
        {
            return View(conferenceRoom);
        }
    }
    [HttpGet]
    public async Task<ActionResult> Delete(int id)
    {
        var conferenceRoom = await _conferenceRoomService.FindConferenceRoom(id);
        return View(conferenceRoom);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConferenceRoom(int id)
    {
        await _conferenceRoomService.DeleteConferenceRoom(id);
        return RedirectToAction("Index");
    }
}