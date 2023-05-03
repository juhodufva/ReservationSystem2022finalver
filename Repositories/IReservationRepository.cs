using ReservationSystem2022.Models;

namespace ReservationSystem2022.Repositories
{
    public interface IReservationRepository
    {
        public Task<Reservation> GetReservationAsync(long id);
        public Task<IEnumerable<Reservation>> GetReservationsAsync();
        public Task<IEnumerable<Reservation>> GetReservationsAsync(Item target, DateTime start, DateTime end);
        public Task<Reservation> AddReservationAsync(Reservation reservation);
        public Task<Reservation> UpdateReservationAsync(Reservation reservation);
        public Task<bool> DeleteReservationAsync(Reservation reservation);
    }
}
