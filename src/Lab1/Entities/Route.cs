using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Route
{
    public Route(IReadOnlyCollection<Section> sections)
    {
        Sections = sections;
    }

    public IReadOnlyCollection<Section> Sections { get; }
}