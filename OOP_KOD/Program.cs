using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_KOD
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            List<Event> events = SeedData.CreateEvents();
            new Menu(events).Run();
            Console.WriteLine("\nHej då!");
        }
    }
}
