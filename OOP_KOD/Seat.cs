using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD;

public enum SeatStatus { Available, Booked, Blocked }

public sealed class Seat
{
    public int Id { get; }
    public string Section { get; }
    public string Row { get; }
    public int Number { get; }
    public SeatStatus Status { get; private set; } = SeatStatus.Available;

    public Seat(int id, string section, string row, int number)
    {
        Id = id; Section = section; Row = row; Number = number;
    }

    public override string ToString()
    {
        string statusSv = Status switch
        {
            SeatStatus.Available => "Ledig",
            SeatStatus.Booked => "Bokad",
            SeatStatus.Blocked => "Spärrad",
            _ => "Okänd"
        };
        return $"{Section}-{Row}:{Number} ({statusSv})";
    }
}

