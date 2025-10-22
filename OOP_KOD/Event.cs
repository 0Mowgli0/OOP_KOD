using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_KOD;

public sealed class Event
{
    public int Id { get; }
    public string Name { get; }
    public DateTime StartsAt { get; }
    public DateTime ReleaseAt { get; }
    public Arena Arena { get; }

    public Event(int id, string name, DateTime startsAt, DateTime releaseAt, Arena arena)
    {
        Id = id;
        Name = name;
        StartsAt = startsAt;
        ReleaseAt = releaseAt;
        Arena = arena;
    }
}