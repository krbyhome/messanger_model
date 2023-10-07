using Itmo.ObjectOrientedProgramming.Lab1.Common;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public interface ITravelable
{
    public TravelSectionResult Travel(Section section);
}