using Avancerad_Lab1.Models;

namespace Avancerad_Lab1.Repositories.IRepositories
{
    public interface ISeatingRepository
    {
        Task<List<Seating>> GetAllSeatingsAsync();
        Task<Seating> GetSeatingByIdAsync(int seatingId);
        Task<int> AddSeatingAsync(Seating seating);
        Task<bool> UpdateSeatingAsync(Seating seating);
        Task<bool> DeleteSeatingAsync(int seatingId);
    }
}
