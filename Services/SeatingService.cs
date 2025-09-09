using Avancerad_Lab1.DTOs;
using Avancerad_Lab1.Models;
using Avancerad_Lab1.Repositories.IRepositories;
using Avancerad_Lab1.Services.IServices;

namespace Avancerad_Lab1.Services
{
    public class SeatingService : ISeatingService
    {
        private readonly ISeatingRepository _seatingrepository;
        public SeatingService(ISeatingRepository seatingRepository)
        {
            _seatingrepository = seatingRepository;
        }
        public async Task<List<SeatingDTO>> GetAllSeatingsAsync()
        {
            var Seatings = await _seatingrepository.GetAllSeatingsAsync();

            var seatingDTO = Seatings.Select(r => new SeatingDTO
            {
                Id = r.Id,
                TableNumber = r.TableNumber,
                IsBooked = r.IsBooked,
                Capacity = r.Capacity,
                Date = r.Date,
                StartTime = r.StartTime,
            }).ToList();
            return seatingDTO;
        }
        public async Task<List<SeatingDTO>> GetAllUnBookedSeatingsAsync()
        {
            var Seatings = await _seatingrepository.GetAllUnBookedSeatingsAsync();

            var seatingDTO = Seatings.Select(r => new SeatingDTO
            {
                Id = r.Id,
                TableNumber = r.TableNumber,
                IsBooked = r.IsBooked,
                Capacity = r.Capacity,
                Date = r.Date,
                StartTime = r.StartTime,
            }).ToList();
            return seatingDTO;
        }
        public async Task<SeatingDTO> GetSeatingByIdAsync(int seatingId)
        {
            var seating = await _seatingrepository.GetSeatingByIdAsync(seatingId);
            if (seating == null)
            {
                return null;
            }
            var seatingDTO = new SeatingDTO
            {
                Id = seating.Id,
                TableNumber = seating.TableNumber,
                IsBooked = seating.IsBooked,
                Capacity = seating.Capacity,
                Date = seating.Date,
                StartTime = seating.StartTime,
            };
            return seatingDTO;
        }
        public async Task<int> CreateSeatingAsync(SeatingDTO seatingDTO)
        {
            var seating = new Seating
            {
                TableNumber = seatingDTO.TableNumber,
                IsBooked = seatingDTO.IsBooked,
                Capacity = seatingDTO.Capacity,
                Date = seatingDTO.Date,
                StartTime = seatingDTO.StartTime,
            };
            var newSeatingId = await _seatingrepository.AddSeatingAsync(seating);
            return newSeatingId;
        } 
        public async Task<bool> UpdateSeatingAsync(SeatingDTO seatingDTO)
        {
            var seating = new Seating
            {
                Id = seatingDTO.Id,
                TableNumber = seatingDTO.TableNumber,
                IsBooked = seatingDTO.IsBooked,
                Capacity = seatingDTO.Capacity,
                Date = seatingDTO.Date,
                StartTime = seatingDTO.StartTime,
            };
            var updatedSeating = await _seatingrepository.UpdateSeatingAsync(seating);
            return updatedSeating;
        }
        public Task<bool> DeleteSeatingAsync(int seatingId)
        {
            var deletedSeating = _seatingrepository.DeleteSeatingAsync(seatingId);
            return deletedSeating;
        }
    }
}
