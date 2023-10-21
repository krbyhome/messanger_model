using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Exchanger;

public class PlasmaFuelExchanger : IFuelExchanging
{
    public static int Exchange(int fuelAmount)
    {
        return RandomNumberGenerator.GetInt32(70, 90) * fuelAmount;
    }
}