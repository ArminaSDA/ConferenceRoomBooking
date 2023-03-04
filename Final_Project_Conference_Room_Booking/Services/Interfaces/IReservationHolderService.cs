using Final_Project_Conference_Room_Booking.Models;
namespace Final_Project_Conference_Room_Booking.Services.Interfaces
{
    public interface IReservationHolderService
    {
        Task<ReservationHolder> Create(ReservationHolder reservationHolder);
        Task<ReservationHolder> DeleteReservationHolder(int id);
        Task<ReservationHolder> FindReservationHolder(int id);
        Task<ReservationHolder> Edit(int id);
        Task<ReservationHolder> Edit(ReservationHolder reservation);
        Task<List<ReservationHolder>> GetAllReservationHolders();
    }
}
