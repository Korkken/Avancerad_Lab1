using Avancerad_Lab1.DTOs;

namespace Avancerad_Lab1.Services.IServices
{
    public interface IReservationService
    {
        Task<List<ReservationDTO>> GetReservationsAsync();
        Task<ReservationDTO> GetReservationByIdAsync(int reservationId);
        Task<int> CreateReservationAsync(ReservationDTO reservationDTO);
        Task<bool> UpdateReservationAsync(ReservationDTO reservationDTO);
        Task<bool> DeleteReservationAsync(int reservationId);

    }
}
