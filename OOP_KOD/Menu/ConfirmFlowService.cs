using System;
using System.Linq;
using OOP_KOD.Interface.Booking_repository;
using OOP_KOD.Payment;

namespace OOP_KOD
{
    internal class ConfirmFlowService
    {
        private readonly IBookingRepository _repo;
        private readonly NotificationService _notify;

        public ConfirmFlowService(IBookingRepository repo, NotificationService notify)
        {
            _repo = repo;
            _notify = notify;
        }

        public Booking? Confirm(Booking? current)
        {
            if (current == null)
            {
                Console.WriteLine("Ingen aktiv bokning.");
                return current;
            }

            var total = current.Seats.Sum(s => s.BasePrice);
            Console.WriteLine("Prisrad:");
            foreach (var s in current.Seats)
                Console.WriteLine($"  Plats {s.SeatNumber} ({s.Type}) = {s.BasePrice:0.00}");
            Console.WriteLine($"Totalt: {total:0.00} kr");

            Console.Write("Betalning (d = direkt, f = faktura): ");
            var k = (Console.ReadLine() ?? "").Trim().ToLower();
            IPayment pay = k == "f" ? new Invoice(total) : new DirectPayment(total);

            pay.Pay();
            if (current.TryConfirm())
            {
                _repo.updateBooking(current);
                _notify.NotifyAll($"Bokning {current.Id} bekräftad. Totalt {total:0.00} kr.");
                Console.WriteLine("Bekräftad.");
            }
            else
            {
                Console.WriteLine("Kunde inte bekräfta (kan ha gått ut).");
            }

            return current;
        }
    }
}
