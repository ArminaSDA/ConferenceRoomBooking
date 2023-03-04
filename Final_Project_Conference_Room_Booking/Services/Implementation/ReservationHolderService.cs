using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Repositories.Implementation;
using Final_Project_Conference_Room_Booking.Repositories.Interfaces;
using Final_Project_Conference_Room_Booking.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Final_Project_Conference_Room_Booking.Services.Implementation
{
    public class ReservationHolderService : IReservationHolderService
    {
        
        private readonly IReservationHolderRepository _reservationHolderRepository;
       
        public ReservationHolderService(IReservationHolderRepository reservationHolderRepository)
        {
            _reservationHolderRepository = reservationHolderRepository;
            
        }

        public async Task<List<ReservationHolder>> GetAllReservationHolders()
        {
            return await _reservationHolderRepository.GetAllReservationHolders();
        }
        
        public async Task<ReservationHolder> Create(ReservationHolder reservationHolder)
        {
            return await _reservationHolderRepository.Create(reservationHolder);
        }
        public async Task<ReservationHolder> DeleteReservationHolder(int id)
        {
            return await _reservationHolderRepository.DeleteReservationHolder(id);
        }
        public async Task<ReservationHolder> FindReservationHolder(int id)
        {
            return await _reservationHolderRepository.FindReservationHolder(id);
                }
        public async Task<ReservationHolder> Edit(int id)
        {
            return await _reservationHolderRepository.FindReservationHolder(id);
        }
        public async Task<ReservationHolder> Edit(ReservationHolder reservation)
        {
            return await _reservationHolderRepository.Edit(reservation);
        }
    }
}