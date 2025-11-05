using System;
using System.Collections.Generic;

namespace OOP_KOD
{
    // Listar events 
    internal class EventLister
    {
        private readonly List<Event> _events;

        public EventLister(List<Event> events)
        {
            _events = events;
        }

        // Lista events med pris
        public void ListEvents()
        {
            var priceCalc = new PriceCalculator(new BasePriceStrategy());

            for (int i = 0; i < _events.Count; i++)
            {
                var ev = _events[i];
                double price = priceCalc.GetPrice();
                Console.WriteLine($"{i+1}: {ev.ShowDetails()} – {price:0} kr");
            }
        }
    }
}
