using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_KOD;

namespace OOP_KOD;

public class ConfirmedStatus : IBookingStatus
{
    public void HandleBooking(Booking booking)
    {
        // TODO: Logic for handling a confirmed booking
    }

    public bool CanBeConfirmed()
    {
        // A confirmed booking is already confirmed
        return false;
    }
}