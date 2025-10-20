using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_KOD;

namespace OOP_KOD;

public interface IBookingStatus
{
    string Name { get; }
    bool CanConfirm { get; }
    void HandleBooking(Booking booking);
    bool CanRefund(Booking booking);
}
