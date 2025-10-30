using System;
using System.Collections.Generic;

namespace OOP_KOD
{
    internal class EventLister
    {
        private readonly List<Event> _events;

        public EventLister(List<Event> events)
        {
            _events = events;
        }

        public void ListEvents()
        {
            var priceCalc = new PriceCalculator(new BasePriceStrategy());

            for (int i = 0; i < _events.Count; i++)
            {
                var ev = _events[i];
                double price = priceCalc.GetPrice();
                Console.WriteLine($"{i}: {ev.ShowDetails()} – {price:0} kr");
            }
        }
    }
}
