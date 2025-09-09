using Avancerad_Lab1.DTOs;
using Avancerad_Lab1.Models;
using Avancerad_Lab1.Repositories;
using Avancerad_Lab1.Repositories.IRepositories;
using Avancerad_Lab1.Services.IServices;

namespace Avancerad_Lab1.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ISeatingRepository _seatingRepository;
        public ReservationService(IReservationRepository reservationRepository, ISeatingRepository seatingRepository) {
            _reservationRepository = reservationRepository;
            _seatingRepository = seatingRepository;
        }
        public async Task <List<ReservationDTO>> GetReservationsAsync()
        {
            var Reservations = await _reservationRepository.GetAllReservationsAsync();

            var reservationsDTO = Reservations.Select(r => new ReservationDTO
            {
                Id = r.Id,
                BookingDate = r.BookingDate,

                GuestAmount = r.GuestAmount,
                FK_SeatingId = r.FK_SeatingId,
                FK_CustomerId = r.FK_CustomerId,
            }).ToList();
            return reservationsDTO;
        }
        public async Task<ReservationDTO> GetReservationByIdAsync(int ReservationId)
        {
            var reservation = await _reservationRepository.GetReservationByIdAsync(ReservationId);
            if (reservation == null)
            {
                return null;
            }
            var reservationDTO = new ReservationDTO
            {
                Id = reservation.Id,
                BookingDate = reservation.BookingDate,

                GuestAmount = reservation.GuestAmount,
                FK_SeatingId = reservation.FK_SeatingId,
                FK_CustomerId = reservation.FK_CustomerId,
            };
            return reservationDTO;
        }
        public async Task<int> CreateReservationAsync(ReservationDTO reservationDTO)
        {
            var existingReservations = await _reservationRepository.GetAllReservationsAsync();
            
            var hasConflict = existingReservations.Any(r => 
                r.FK_SeatingId == reservationDTO.FK_SeatingId &&
                r.BookingDate.Date == reservationDTO.BookingDate.Date);
            
            if (hasConflict)
                throw new InvalidOperationException("Time slot already booked for this seating");

            var reservation = new Reservation
            {
                BookingDate = reservationDTO.BookingDate,
                GuestAmount = reservationDTO.GuestAmount,
                FK_CustomerId = reservationDTO.FK_CustomerId,
                FK_SeatingId = reservationDTO.FK_SeatingId
            };
            var newReservationId = await _reservationRepository.AddReservationAsync(reservation);
            

            
            return newReservationId;
        }
        public async Task<bool> UpdateReservationAsync(ReservationDTO reservationDTO) 
        {
            var reservation = new Reservation
            {
                Id = reservationDTO.Id,
                BookingDate = reservationDTO.BookingDate,

                GuestAmount = reservationDTO.GuestAmount,
                FK_SeatingId = reservationDTO.FK_SeatingId,
                FK_CustomerId = reservationDTO.FK_CustomerId
            };
            return await _reservationRepository.UpdateReservationAsync(reservation);
        }
        public Task<bool> DeleteReservationAsync(int ReservationId)
        {
            var deletedReservation = _reservationRepository.DeleteReservationAsync(ReservationId);
            return deletedReservation;
        }
    }
}
