using System;
using OOP_KOD.Interface.Booking_repository;

namespace OOP_KOD
{
    internal class CancelFlowService
    {
        private readonly IBookingRepository _repo;
        private readonly NotificationService _notify;

        public CancelFlowService(IBookingRepository repo, NotificationService notify)
        {
            _repo = repo;
            _notify = notify;
        }

        public Booking? Cancel(Booking? current)
        {
            if (current == null)
            {
                Console.WriteLine("Ingen aktiv bokning.");
                return current;
            }

            current.Cancel();
            _repo.updateBooking(current);
            _notify.NotifyAll($"Bokning {current.Id} avbröts.");
            Console.WriteLine("Avbruten.");

            return current;
        }
    }
}
