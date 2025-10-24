using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD
{
    public class SMSNotifier : INotifiable
    {
        public void SendNotification()
        {
            // Default notification logic for SMS
            SendSMS("Default notification message");
        }

        public void SendSMS(string message)
        {
            // Implementation for sending SMS
            Console.WriteLine($"Sending SMS: {message}");
        }
    }
}
