using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD;

public sealed class Booking
{
    public int Id { get; }
    public string CustomerName { get; }
    public IBookingStatus Status { get; private set; }

    public Booking(int id, string customerName)
    {
        Id = id;
        CustomerName = customerName;
        Status = new ReservedStatus();  // start state
    }

    public void SetStatus(IBookingStatus next) => Status = next;

    // Convenience actions (you call these from Program/UI)
    public void Confirm()
    {
        if (!Status.CanConfirm)
            throw new InvalidOperationException($"Kan inte bekräfta i status '{Status.Name}'.");
        SetStatus(new ConfirmedStatus());
    }

    public void Cancel() => SetStatus(new CanceledStatus());
    public void Timeout() => SetStatus(new TimeoutStatus());
}

