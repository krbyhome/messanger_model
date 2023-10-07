using System.Security.Cryptography;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Exchanger;

public class GravityMatterExchanger : IFuelExchanging
{
    public static int Exchange(int fuelAmount)
    {
        return RandomNumberGenerator.GetInt32(130, 150) * fuelAmount;
    }
}