using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OOP_KOD
{
    public class NotificationService
    {
        private List<INotifiable> observers = new List<INotifiable>();

        public void RegisterObserver(INotifiable observer)
        {
            observers.Add(observer);
        }

        public void UnregisterObserver(INotifiable observer)
        {
            observers.Remove(observer);
        }

        public void NotifyAll(string message)
        {
            foreach (var observer in observers)
            {
                observer.SendNotification();
            }
        }
    }
}
