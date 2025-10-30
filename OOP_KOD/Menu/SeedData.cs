using System;
using System.Collections.Generic;
using OOP_KOD;

namespace OOP_KOD
{
    public static class SeedData
    {
        public static List<Event> CreateEvents()
        {
            // HÄR: räkna ut priserna EN gång
            double priceVip = new SeatingTypePriceStrategy(SeatingType.VIP).CalculatePrice();
            double priceStandard = new SeatingTypePriceStrategy(SeatingType.Standard).CalculatePrice();
            double priceBalcony = new SeatingTypePriceStrategy(SeatingType.Balcony).CalculatePrice();

            var seatsArena1 = new List<Seat>();
            int id = 1;

            // ARENA 1
            for (int row = 1; row <= 3; row++)
            {
                for (int i = 1; i <= 10; i++)
                {
                    // globalt platsnummer: rad 1 = 1–10, rad 2 = 11–20, rad 3 = 21–30
                    int seatNumber = (row - 1) * 10 + i;

                    SeatType type = row == 1
                        ? SeatType.LUXURY_BOX
                        : (row == 2 ? SeatType.FOLDING : SeatType.BENCH);

                    string color = type == SeatType.FOLDING ? "röd" : "grå";
                    bool eco = type == SeatType.BENCH;

                    // välj rätt förberäknat pris
                    double basePrice = type switch
                    {
                        SeatType.LUXURY_BOX => priceVip,     // VIP
                        SeatType.FOLDING => priceStandard, // Standard
                        SeatType.BENCH => priceBalcony,  // Billigast
                        _ => priceStandard
                    };

                    seatsArena1.Add(new Seat(
                        seatId: id++,
                        rowNumber: row,
                        seatNumber: seatNumber,
                        type: type,
                        basePrice: basePrice,
                        color: color,
                        ecoPaintApproved: eco
                    ));
                }
            }

            // ARENA 2
            var seatsArena2 = new List<Seat>();
            for (int row = 1; row <= 3; row++)
            {
                for (int i = 1; i <= 10; i++)
                {
                    int seatNumber = (row - 1) * 10 + i;   // samma princip här

                    SeatType type = row == 1
                        ? SeatType.FOLDING
                        : (row == 2 ? SeatType.BENCH : SeatType.LUXURY_BOX);

                    string color = type == SeatType.FOLDING ? "röd" : "svart";
                    bool eco = type == SeatType.BENCH;

                    double basePrice = type switch
                    {
                        SeatType.LUXURY_BOX => priceVip,
                        SeatType.FOLDING => priceStandard,
                        SeatType.BENCH => priceBalcony,
                        _ => priceStandard
                    };

                    seatsArena2.Add(new Seat(
                        seatId: id++,
                        rowNumber: row,
                        seatNumber: seatNumber,
                        type: type,
                        basePrice: basePrice,
                        color: color,
                        ecoPaintApproved: eco
                    ));
                }
            }

            var arenas = new List<Arena>
            {
                new Arena(1, "Stora Arenan", "Stål & Glas", seatsArena1),
                new Arena(2, "Parkscenen",   "Trä",          seatsArena2),
            };

            var events = new List<Event>
            {
                new Event(100, "Rock Night",      "The Codes",   DateTime.Today.AddDays(7),  arenas[0], true),
                new Event(101, "Family Fun",      "Kids Show",   DateTime.Today.AddDays(5),  arenas[1], true),
                new Event(102, "Summer Fest",     "DJ Sunrise",  DateTime.Today.AddDays(2),  arenas[0], false),
                new Event(103, "Classic Evening", "Symphonics",  DateTime.Today.AddDays(30), arenas[0], false),
            };

            return events;
        }
    }
}
