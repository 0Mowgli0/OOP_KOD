using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD;

public sealed class CanceledStatus : IBookingStatus
{
    public string Name => "Avbokad";
    public bool CanConfirm => false;

    public void HandleBooking(Booking booking)
    {
        // Terminal.
    }

    public bool CanRefund(Booking booking) => false;
}
