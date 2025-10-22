using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD;

public class TimeoutStatus : IBookingStatus
{
    public object Name => throw new NotImplementedException();

    public bool CanConfirm => throw new NotImplementedException();

    public void HandleBooking(Booking booking)
    {
        // TODO: Logic for handling a timed-out booking
    }

    public bool CanBeConfirmed()
    {
        // A timed-out booking cannot be confirmed
        return false;
    }
}

