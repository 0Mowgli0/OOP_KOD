using System;
using System.Collections.Generic;
using System.Linq;
using OOP_KOD.Interface.Booking_repository;

namespace OOP_KOD
{
    internal class ReservationFlow
    {
        private readonly EventPicker _picker;
        private readonly EventManager _manager;
        private readonly IBookingRepository _repo;
        private readonly TimeSpan _ttl;

        // vi vill kunna uppdatera current booking i Menu → vi returnerar den
        public ReservationFlow(EventPicker picker, EventManager manager, IBookingRepository repo, TimeSpan ttl)
        {
            _picker = picker;
            _manager = manager;
            _repo = repo;
            _ttl = ttl;
        }

        public Booking? RunReservation()
        {
            var ev = _picker.PickEvent();
            Console.WriteLine(_manager.GetSeatMap(ev));

            var seatNumbers = ReadSeatNumbers();
            if (seatNumbers.Count == 0)
            {
                Console.WriteLine("Inga giltiga platsnummer.");
                return null;
            }

            bool isFamily = ev.Name.Contains("Family", StringComparison.OrdinalIgnoreCase);
            if (!isFamily && (seatNumbers.Count < 1 || seatNumbers.Count > 5))
            {
                Console.WriteLine("Du får köpa 1–5 biljetter per person.");
                return null;
            }

            var seats = new List<Seat>();
            foreach (var num in seatNumbers)
            {
                var seat = ev.Arena.Seats.FirstOrDefault(s => s.SeatNumber == num);
                if (seat == null)
                {
                    Console.WriteLine($"Plats {num} finns inte.");
                    foreach (var s in seats) s.Release();
                    return null;
                }

                if (!_manager.ReserveSeat(ev, seat.SeatId))
                {
                    Console.WriteLine($"Plats {num} kunde inte reserveras.");
                    foreach (var s in seats) s.Release();
                    return null;
                }

                seats.Add(seat);
            }

            var booking = new Booking(ev, seats, _ttl);
            _repo.saveBooking(booking);
            Console.WriteLine($"Bokning skapad: {booking.Id} (giltig till {booking.ExpiresAtUtc:HH:mm:ss} UTC)");
            return booking;
        }

        private static List<int> ReadSeatNumbers()
        {
            Console.Write("Platsnummer (komma-separerat, t.ex. 1,12,25): ");
            var raw = Console.ReadLine() ?? "";
            return raw.Split(',', StringSplitOptions.RemoveEmptyEntries)
                      .Select(s => int.TryParse(s.Trim(), out var v) ? v : -1)
                      .Where(v => v > 0)
                      .ToList();
        }
    }
}
