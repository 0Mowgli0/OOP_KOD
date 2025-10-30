using System;
using System.Collections.Generic;
using OOP_KOD.Interface.Booking_repository;
using OOP_KOD.Payment;

namespace OOP_KOD
{
    public class Menu
    {
        private readonly EventManager _manager = new EventManager();
        private readonly TimeSpan _ttl = TimeSpan.FromMinutes(10);

        private readonly EventLister _eventLister;
        private readonly EventPicker _eventPicker;
        private readonly MapViewer _mapViewer;
        private readonly ReservationFlow _reservationFlow;
        private readonly ConfirmFlowService _confirmFlow;
        private readonly CancelFlowService _cancelFlow;

        private Booking? _currentBooking;

        public Menu(List<Event> events, NotificationService notify, IBookingRepository repo)
        {
            _eventLister = new EventLister(events);
            _eventPicker = new EventPicker(events);
            _mapViewer = new MapViewer(_eventPicker, _manager);
            _reservationFlow = new ReservationFlow(_eventPicker, _manager, repo, _ttl);
            _confirmFlow = new ConfirmFlowService(repo, notify);
            _cancelFlow = new CancelFlowService(repo, notify);
        }

        public void Run()
        {
            Console.WriteLine("Välkommen till biljettshoppen!");

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1) Lista event");
                Console.WriteLine("2) Visa platskarta");
                Console.WriteLine("3) Reservera platser (1–5; familjeevent undantagna)");
                Console.WriteLine("4) Bekräfta & betala");
                Console.WriteLine("5) Avbryt bokning");
                Console.WriteLine("0) Avsluta");
                Console.Write("Val: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        return;

                    case "1":
                        _eventLister.ListEvents();
                        break;

                    case "2":
                        _mapViewer.ShowMap();
                        break;

                    case "3":
                        _currentBooking = _reservationFlow.RunReservation();
                        break;

                    case "4":
                        _currentBooking = _confirmFlow.Confirm(_currentBooking);
                        break;

                    case "5":
                        _currentBooking = _cancelFlow.Cancel(_currentBooking);
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val.");
                        break;
                }
            }
        }
    }
}
