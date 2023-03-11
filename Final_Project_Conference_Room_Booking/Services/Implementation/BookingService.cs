using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Repositories.Implementation;
using Final_Project_Conference_Room_Booking.Repositories.Interfaces;
using Final_Project_Conference_Room_Booking.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Final_Project_Conference_Room_Booking.Services.Implementation
{
    public class BookingService : IBookingService
    {

        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;

        }
        public async Task<List<Booking>> GetAllTheBookings()
        {
            return await _bookingRepository.GetAllTheBookings();
        }

        public async Task<Booking> Create(Booking booking)
        {
            return await _bookingRepository.Create(booking);
        }
       
        public async Task<Booking> DeleteBooking(int id)
        {
            return await _bookingRepository.DeleteBooking(id);
        }
        public async Task<Booking> FindBooking(int id)
        {
            return await _bookingRepository.FindBooking(id);
        }
        public async Task<Booking> Edit(int id)
        {
            return await _bookingRepository.FindBooking(id);
        }
        public async Task<Booking> Edit(Booking booking)
        {
            return await _bookingRepository.Edit(booking);
        }

        public async Task<Booking> Confirm(int id)
        {   
            return await _bookingRepository.Confirm(id);
        }
    }
}