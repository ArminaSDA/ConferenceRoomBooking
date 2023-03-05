using Final_Project_Conference_Room_Booking.Models;
using Final_Project_Conference_Room_Booking.Repositories.Interfaces;
using Final_Project_Conference_Room_Booking.Services.Interfaces;

namespace Final_Project_Conference_Room_Booking.Services.Implementation;

public class UnavailabilityPeriodService:IUnavailabilityPeriodService
{
    private readonly IUnavailabilityPeriodRepository _unavailabilityPeriodRepository;

    public UnavailabilityPeriodService(IUnavailabilityPeriodRepository unavailabilityPeriodRepository)
    {
        _unavailabilityPeriodRepository = unavailabilityPeriodRepository;
    }
    public async Task<IEnumerable<UnavailabilityPeriod>> GetAllUnavailabilityPeriod(DateTime data)
    {
        return await _unavailabilityPeriodRepository.GetAllUnavailabilityPeriod(data);
    }
        
}
