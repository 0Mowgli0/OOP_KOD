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

            if (DateTime.UtcNow >= booking.CreatedUtc.AddMinutes(10))
                booking.Timeout();

        }
        public bool CanBeConfirmed() => true;
    }
}
