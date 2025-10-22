using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD;

public class CanceledStatus : IBookingStatus
{
    public void HandleBooking(Booking booking)
    {
        // TODO: Logic for handling a canceled booking
    }

    public bool CanBeConfirmed()
    {
        // A canceled booking cannot be confirmed
        return false;
    }
}

