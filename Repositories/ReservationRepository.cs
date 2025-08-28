using Avancerad_Lab1.Data;
using Avancerad_Lab1.Repositories.IRepositories;
using Avancerad_Lab1.Models;
using Microsoft.EntityFrameworkCore;

namespace Avancerad_Lab1.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDBContext _dbContext;

        public ReservationRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddReservationAsync(Reservation reservation)
        {
            _dbContext.Reservations.Add(reservation);
            await _dbContext.SaveChangesAsync();

            return reservation.Id;

        }
        public async Task<bool> DeleteReservationAsync(int reservationId)
        {
            var rowsAffected = await _dbContext.Reservations.Where(r => r.Id == reservationId).ExecuteDeleteAsync();

            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }
        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            var reservations = await _dbContext.Reservations.ToListAsync();

            return reservations;
        }
        public async Task<Reservation> GetReservationByIdAsync(int reservationId)
        {
            var reservation = await _dbContext.Reservations
                .FirstOrDefaultAsync(r => r.Id == reservationId);

                return reservation;

        }
        public async Task<bool> UpdateReservationAsync(Reservation reservation)
        {
            _dbContext.Reservations.Update(reservation);
            var result = await _dbContext.SaveChangesAsync();

            if (result != 0)
            {
                return true;
            }
            return false;
        }
    }
}
