namespace OOP_KOD
{
    public sealed class Booking
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime CreatedUtc { get; init; } = DateTime.UtcNow;

        private IBookingStatus _status = new ReservedStatus();
        public IBookingStatus Status => _status;

        public void Handle() => _status.HandleBooking(this);

        public bool TryConfirm()
        {
            if (!_status.CanBeConfirmed()) return false;
            _status = new ConfirmedStatus();
            return true;
        }

        public void Cancel() => _status = new CanceledStatus();

        public void Timeout()
        {
            if (_status is TimeoutStatus) return;
            _status = new TimeoutStatus();
            // här kan du senare trigga notis / släppa platser, etc.
        }


    }
}