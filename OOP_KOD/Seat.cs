using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD;


public class Seat
{
    private int v1;
    private string v2;
    private string v3;
    private int v4;

    public Seat(int v1, string v2, string v3, int v4)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
        this.v4 = v4;
    }

    public int SeatId { get; set; }
    public int RowNumber { get; set; }
    public int SeatNumber { get; set; }
    public SeatType Type { get; set; }
    public SeatStatus Status { get; set; } = SeatStatus.Available;
    public double BasePrice { get; set; }

    public void Reserve()
    {
        if (Status == SeatStatus.Available)
        {
            Status = SeatStatus.Reserved;
            Console.WriteLine("Platsen har reserverats.");
        }
        else
        {
            Console.WriteLine("Kan inte reservera platsen – den är inte ledig.");
        }
    }

    public void Release()
    {
        if (Status != SeatStatus.Available)
        {
            Status = SeatStatus.Available;
            Console.WriteLine("Platsen är släppt och nu ledig.");
        }
        else
        {
            Console.WriteLine("Platsen är redan ledig.");
        }
    }

    public string GetColor()
    {
        return Status switch
        {
            SeatStatus.Available => "Grön",
            SeatStatus.Reserved => "Gul",
            SeatStatus.Booked => "Röd",
            _ => "Okänd"
        };
    }

    public override string ToString()
        => $"Rad {RowNumber}, Plats {SeatNumber} ({Type}, {Status}, {BasePrice:C})";
}