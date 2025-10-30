using System;
using System.Collections.Generic;

namespace OOP_KOD
{
    internal class EventPicker
    {
        private readonly List<Event> _events;

        public EventPicker(List<Event> events)
        {
            _events = events;
        }

        public Event PickEvent()
        {
            Console.WriteLine();
            Console.WriteLine("Tillgängliga event:");
            for (int i = 0; i < _events.Count; i++)
                Console.WriteLine($"{i}: {_events[i].ShowDetails()}");

            Console.Write("Event-index: ");
            var input = Console.ReadLine();

            if (!int.TryParse(input, out int idx) || idx < 0 || idx >= _events.Count)
            {
                Console.WriteLine("Ogiltigt index, väljer första (0).");
                idx = 0;
            }

            return _events[idx];
        }
    }
}
