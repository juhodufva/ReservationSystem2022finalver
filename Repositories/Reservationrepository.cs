﻿using ReservationSystem2022.Models;
using Microsoft.EntityFrameworkCore;

namespace ReservationSystem2022.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ReservationContext _context;
        public ReservationRepository(ReservationContext context)
        {
            _context = context;
        }
        public async Task<Reservation> AddReservationAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return reservation;
        }

        public async Task<bool> DeleteReservationAsync(Reservation reservation)
        {
            try
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<Reservation> GetReservationAsync(long id)
        {
            return await _context.Reservations.Include(i => i.Owner).Include(i => i.Target).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Reservation>> GetReservationsAsync(Item target, DateTime start, DateTime end)
        {
            return await _context.Reservations.Include(i => i.Owner).Include(x => x.Target).Where(x => x.Target == target && (x.StartTime >= start && x.StartTime < end || x.EndTime >= start && x.EndTime < end || x.StartTime <= start && x.EndTime >= end)).ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservationsAsync()
        {
            return await _context.Reservations.Include(i => i.Owner).Include(i => i.Target).ToListAsync();
        }

        public async Task<Reservation> UpdateReservationAsync(Reservation reservation)
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
            return reservation;
        }
    }
}
