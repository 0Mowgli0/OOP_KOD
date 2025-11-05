using System;
using System.Collections.Generic;
using OOP_KOD.Interface.Booking_repository;
using OOP_KOD.Payment;

namespace OOP_KOD
{
    public class Menu
    {
        private readonly EventManager _manager = new EventManager();
        private readonly TimeSpan _ttl = TimeSpan.FromSeconds(5000);

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
                        {
                            var active = _cancelFlow.GetActiveBookings();
                            if (active == null || active.Count == 0)
                            {
                                Console.WriteLine("Inga aktiva bokningar att bekräfta.");
                                break;
                            }

                            Console.WriteLine("Välj bokning att bekräfta:");
                            for (int i = 0; i < active.Count; i++)
                                Console.WriteLine($"{i + 1}. Bokning ID: {active[i].Id}");

                            Console.Write("Val (nummer): ");
                            if (int.TryParse(Console.ReadLine(), out int confirmChoice) &&
                                confirmChoice >= 1 && confirmChoice <= active.Count)
                            {
                                var booking = active[confirmChoice - 1];
                                _confirmFlow.Confirm(booking);
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt val.");
                            }
                            break;
                        }

                    case "5":
                        {
                            var active = _confirmFlow.GetActiveBookings();

                            if (active == null || active.Count == 0)
                            {
                                Console.WriteLine("Inga aktiva bokningar att avboka.");
                                break;
                            }

                            Console.WriteLine("Välj bokning att avboka:");
                            for (int i = 0; i < active.Count; i++)
                                Console.WriteLine($"{i + 1}. Bokning ID: {active[i].Id}");

                            Console.Write("Val (nummer): ");
                            if (int.TryParse(Console.ReadLine(), out int cancelChoice) &&
                                cancelChoice >= 1 && cancelChoice <= active.Count)
                            {
                                var booking = active[cancelChoice - 1];
                                _cancelFlow.Cancel(booking);
                            }
                            else
                            {
                                Console.WriteLine("Ogiltigt val.");
                            }
                            break;
                        }


                    default:
                        Console.WriteLine("Ogiltigt val.");
                        break;
                }
            }
        }
    }
}
