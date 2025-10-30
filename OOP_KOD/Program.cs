using System;
using System.Collections.Generic;
using OOP_KOD.Interface.Booking_repository;

namespace OOP_KOD
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            List<Event> events = SeedData.CreateEvents();

            var notifier = new NotificationService();
            notifier.RegisterObserver(new EmailNotifier());
            notifier.RegisterObserver(new SMSNotifier());

            IBookingRepository repo = new BookingRepository();

            new Menu(events, notifier, repo).Run();
            Console.WriteLine("\nHej då!");
        }
    }
}