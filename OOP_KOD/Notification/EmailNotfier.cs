using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD
{
    public class EmailNotifier : INotifiable
    {
        public void SendNotification()
        {
            // Default notification logic for email
            SendEmail("Default notification message");
        }

        public void SendEmail(string message)
        {
            // Implementation for sending email
            Console.WriteLine($"Sending email: {message}");
        }
    }
}
