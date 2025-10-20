using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD;

public sealed class ReservedStatus : IBookingStatus
{
    public string Name => "Reserverad";
    public bool CanConfirm => true;

    public void HandleBooking(Booking booking)
    {
        // No automatic transition here. Wait for Confirm/Cancel/Timeout.
    }

    public bool CanRefund(Booking booking) => false;
}

