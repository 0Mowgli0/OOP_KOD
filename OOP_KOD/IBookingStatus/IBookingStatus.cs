using OOP_KOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD
{
    public interface IBookingStatus
    {
        void HandleBooking(Booking booking);
        bool CanBeConfirmed();
    }
}

