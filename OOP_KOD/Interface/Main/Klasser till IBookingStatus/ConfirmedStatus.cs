using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_KOD;

namespace OOP_KOD;

public sealed class ConfirmedStatus : IBookingStatus
{
    public string Name => "Bekräftad";
    public bool CanConfirm => false;

    public void HandleBooking(Booking booking)
    {
        // Terminal in this simple example.
    }

    public bool CanRefund(Booking booking) => true;
}
