using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD;

public class ReservedStatus : IBookingStatus
{
    public void HandleBooking(Booking booking)
    {
        // TODO: Logic for handling a reserved booking
    }

    public bool CanBeConfirmed()
    {
        // A reserved booking can usually be confirmed
        return true;
    }
}
