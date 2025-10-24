using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD
{
    public class TimeoutHandler
    {
        public DateTime TimeoutTime { get; private set; }
        private Timer timer;
        private Action timeoutCallback;
        private TimeSpan timeoutDuration;

        public TimeoutHandler(TimeSpan duration, Action callback)
        {
            timeoutDuration = duration;
            timeoutCallback = callback;
        }

        public void StartTimeout()
        {
            TimeoutTime = DateTime.Now.Add(timeoutDuration);
            timer = new Timer(_ => timeoutCallback?.Invoke(), null, timeoutDuration, Timeout.InfiniteTimeSpan);
        }

        public void CancelTimeout()
        {
            timer?.Dispose();
            timer = null;
        }

        // tror inte de ska va med
        public bool IsExpired()
        {
            return DateTime.Now > TimeoutTime;
        }
    }
}

/* För att använda TimeoutHandler i en bokningsklass:
 
    public class Booking
{
    private TimeoutHandler timeoutHandler;

    public Booking()
    {
        // 15 minuters timeout
        timeoutHandler = new TimeoutHandler(TimeSpan.FromMinutes(15), () => Cancel());
    }

    public void Confirm()
    {
        // Bekräfta bokningen och avbryt timeout
        timeoutHandler.CancelTimeout();
        status = new ConfirmedStatus();
    }

    public void Cancel()
    {
        // Avbryt bokningen (anropas antingen manuellt eller av timeout)
        timeoutHandler.CancelTimeout();
        status = new CancelledStatus();
    }
} */