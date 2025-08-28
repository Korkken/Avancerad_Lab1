using Avancerad_Lab1.DTOs;

namespace Avancerad_Lab1.Services.IServices
{
    public interface ISeatingService
    {
        Task<List<SeatingDTO>> GetAllSeatingsAsync();
        Task<SeatingDTO> GetSeatingByIdAsync(int seatingId);
        Task<int> CreateSeatingAsync(SeatingDTO seatingDTO);
        Task<bool> UpdateSeatingAsync(SeatingDTO seatingDTO);
        Task<bool> DeleteSeatingAsync(int seatingId);
    }
}
