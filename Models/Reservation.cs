﻿using ReservationSystem2022.Controllers;


namespace ReservationSystem2022.Models
{
    public class Reservation
    {
        public long Id { get; set; }
        public virtual User? Owner { get; set; }
        public virtual Item? Target { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
    public class ReservationDTO
    {
        public long Id { get; set; }
        public string Owner { get; set; }
        public long Target { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
