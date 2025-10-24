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
    private TimeoutHandler _timeoutHandler;

    public Booking(int id, string customerName)
    {
        Id = id;
        CustomerName = customerName;
        Status = new ReservedStatus();  // start state

        // 15 minuters timeout
        _timeoutHandler = new TimeoutHandler(TimeSpan.FromMinutes(15), () => Timeout());
    }

    public void SetStatus(IBookingStatus next) => Status = next;

    // Convenience actions (you call these from Program/UI)
    public void Confirm()
    {
        if (!Status.CanConfirm)
            throw new InvalidOperationException($"Kan inte bekräfta i status '{Status.Name}'.");

        // Avbryt timeout när bokningen bekräftas
        _timeoutHandler.CancelTimeout();
        SetStatus(new ConfirmedStatus());
    }

    public void Cancel()
    {
        // Avbryt timeout när bokningen avbryts manuellt
        _timeoutHandler.CancelTimeout();
        SetStatus(new CanceledStatus());
    }

    public void Timeout()
    {
        // Timeout hanteras automatiskt av TimeoutHandler
        SetStatus(new TimeoutStatus());
    }
}