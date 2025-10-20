using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD;

public sealed class TimeoutStatus : IBookingStatus
{
    public string Name => "Timeout";
    public bool CanConfirm => false;

    public void HandleBooking(Booking booking)
    {
        // Terminal.
    }

    public bool CanRefund(Booking booking) => false;
}

