using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_KOD
{
    public sealed class Booking
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime CreatedUtc { get; } = DateTime.UtcNow;
        public Event Event { get; }
        public List<Seat> Seats { get; }
        public DateTime ExpiresAtUtc { get; private set; }

        private IBookingStatus _status = new ReservedStatus();
        public IBookingStatus Status => _status;

        private readonly TimeoutHandler _timeout = new TimeoutHandler();

        public Booking(Event ev, IEnumerable<Seat> seats, TimeSpan ttl)
        {
            Event = ev;
            Seats = seats.ToList();
            StartTimeout(ttl);
        }

        private void StartTimeout(TimeSpan ttl)
        {
            ExpiresAtUtc = DateTime.UtcNow + ttl;
            _timeout.StartTimeout(ttl, () => Handle()); // låt state avgöra
        }

        public void CancelTimer() => _timeout.CancelTimeout();

        public void Handle() => _status.HandleBooking(this);

        public bool TryConfirm()
        {
            // Får inte bekräfta något som gått ut
            if (DateTime.UtcNow >= ExpiresAtUtc) return false;
            if (!_status.CanBeConfirmed()) return false;

            _status = new ConfirmedStatus();
            CancelTimer();
            foreach (var s in Seats) s.Book();
            return true;
        }

        public void Cancel()
        {
            _status = new CanceledStatus();
            CancelTimer();
            foreach (var s in Seats) s.Release();
        }

        public void Timeout()
        {
            if (_status is TimeoutStatus || _status is ConfirmedStatus || _status is CanceledStatus) return;
            _status = new TimeoutStatus();
            foreach (var s in Seats) s.Release();
        }

        public override string ToString() => $"Booking {Id} [{_status.GetType().Name}] seats={Seats.Count} event={Event.Name}";
    }
}