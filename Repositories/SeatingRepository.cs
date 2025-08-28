using Avancerad_Lab1.Data;
using Avancerad_Lab1.Models;
using Avancerad_Lab1.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Avancerad_Lab1.Repositories
{
    public class SeatingRepository : ISeatingRepository
    {
        private readonly AppDBContext _dbContext;

        public SeatingRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddSeatingAsync(Seating seating)
        {
            _dbContext.Seatings.Add(seating);
            await _dbContext.SaveChangesAsync();

            return seating.Id;

        }
        public async Task<bool> DeleteSeatingAsync(int seatingId)
        {
            var rowsAffected = await _dbContext.Seatings.Where(s => s.Id == seatingId).ExecuteDeleteAsync();

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<List<Seating>> GetAllSeatingsAsync()
        {
            var seatings = await _dbContext.Seatings.ToListAsync();

            return seatings;
        }
        public async Task<Seating> GetSeatingByIdAsync(int seatingId)
        {
            var seating = await _dbContext.Seatings
                .FirstOrDefaultAsync(s => s.Id == seatingId);

            return seating;

        }
        public async Task<bool> UpdateSeatingAsync(Seating seating)
        {
            _dbContext.Seatings.Update(seating);
            var result = await _dbContext.SaveChangesAsync();

            if (result != 0)
            {
                return true;
            }
            return false;
        }
    }
}
