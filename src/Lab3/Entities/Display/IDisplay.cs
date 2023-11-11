using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public interface IDisplay : IAddresse
{
    void SetColor(Color color);
}