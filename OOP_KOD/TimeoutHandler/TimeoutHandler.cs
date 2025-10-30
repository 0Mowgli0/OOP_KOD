using System;

namespace OOP_KOD
{
    // Enkel timeout-hanterare baserad på System.Threading.Timer
    public sealed class TimeoutHandler : IDisposable
    {
        public DateTime TimeoutTime { get; private set; }
        private System.Threading.Timer? _timer;
        private Action? _callback;

        public void StartTimeout(TimeSpan duration, Action callback)
        {
            CancelTimeout();
            _callback = callback;
            TimeoutTime = DateTime.UtcNow.Add(duration);

            // Starta en engångstimer som anropar callback och sedan själv-disposar
            _timer = new System.Threading.Timer(_ =>
            {
                CancelTimeout();
                _callback?.Invoke();
            }, null, duration, System.Threading.Timeout.InfiniteTimeSpan);
        }

        public void CancelTimeout()
        {
            _timer?.Dispose();
            _timer = null;
        }

        public void Dispose() => CancelTimeout();
    }
}