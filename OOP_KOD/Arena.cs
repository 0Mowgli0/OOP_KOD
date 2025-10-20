using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace OOP_KOD;

public sealed class Arena
{
    public int Id { get; }
    public string Name { get; }
    public bool Indoor { get; }
    public string Material { get; }

    private readonly List<Seat> _seats = new();
    public IReadOnlyList<Seat> Seats => new ReadOnlyCollection<Seat>(_seats);

    public Arena(int id, string name, bool indoor, string material)
    {
        Id = id; Name = name; Indoor = indoor; Material = material;
    }

    public void AddSeat(Seat seat) => _seats.Add(seat);
}

