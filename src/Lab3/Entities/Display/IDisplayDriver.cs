using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Services;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public interface IDisplayDriver : IClearableDrawer
{
    void WithColor(Color color);
}