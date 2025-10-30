using OOP_KOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD
{
    public sealed class ReservedStatus : IBookingStatus
    {
        public void HandleBooking(Booking booking)
        {
            if (System.DateTime.UtcNow >= booking.ExpiresAtUtc)
            {
                booking.CancelTimer();
                booking.Timeout();
            }
        }

        public bool CanBeConfirmed() => true;
    }
}