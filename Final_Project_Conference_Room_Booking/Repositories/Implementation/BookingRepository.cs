using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_Conference_Room_Booking.Repositories.Implementation
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ConferenceRoomBookingContext _context;

        public BookingRepository(ConferenceRoomBookingContext context)
        {
            _context = context;
        }

        public async Task<List<Booking>> GetAllTheBookings()


        {
            var  bookingList = await _context.Bookings.Where(s => s.IsDeleted == false).ToListAsync();
            return bookingList;

        }
        public async Task<List<Booking>> GetAllTheBookings(DateTime data)
        {
            
            var    bookingList = await _context.Bookings.Where(s => s.StartDate <= data && s.EndDate >= data).ToListAsync();
            return bookingList;
        }

     
        public async Task<Booking> Create(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await  _context.SaveChangesAsync();
            return (booking);
        }
        public async Task<Booking> DeleteBooking(int id)
        {
            var deleterecord = await _context.Bookings.FindAsync(id);

             deleterecord.IsDeleted = true;
            _context.Bookings.Update(deleterecord);
            await _context.SaveChangesAsync();

            return deleterecord;
        }
        public async Task<Booking> FindBooking(int id)
        {
            var bookingId = await _context.Bookings.FindAsync(id);
            return bookingId;
        }
        public async Task<Booking> Edit(int id)
        {
            return await _context.Bookings.FindAsync(id);
        }
        public async Task<Booking> Edit(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

  
        public async Task<Booking> Confirm(int id)
        {

            var confirmedrecord = await _context.Bookings.FindAsync(id);
            confirmedrecord.IsConfirmed = true;
            _context.Bookings.Update(confirmedrecord);
            await _context.SaveChangesAsync();
            return confirmedrecord;
        }
    }
}
