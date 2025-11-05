using System;
using OOP_KOD.Interface.Booking_repository;

namespace OOP_KOD
{
    /* Tjänst som hanterar flödet för att avbryta en bokning:
       anropar bokningslagret och skickar notifieringar.*/
    internal class CancelFlowService
    {
        private readonly IBookingRepository _repo;
        private readonly NotificationService _notify;

        // Skapar tjänsten med beroenden för lagring 
        public CancelFlowService(IBookingRepository repo, NotificationService notify)
        {
            _repo = repo;
            _notify = notify;
        }

        // Försöker avbryta den angivna bokningen.
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
        public List<Booking> GetActiveBookings()
        {
            return _repo.getAllActiveBookings();
        }
    }
}
