using Itmo.ObjectOrientedProgramming.Lab1.Entities.Enviroments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class Section
{
    public Section(IEnviroment enviroment, int distance)
    {
        Enviroment = enviroment;
        Distance = distance;
    }

    public IEnviroment Enviroment { get; }
    public int Distance { get; }
}