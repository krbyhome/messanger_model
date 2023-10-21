using Itmo.ObjectOrientedProgramming.Lab1.Common;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Enviroments;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Service;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Tests
{
    [Theory]
    [ClassData(typeof(FirstTestDataGenerator))]
    public void ShuttleShouldHasNoReqiuredEngineAvgurShouldBeLost(
        Route route,
        Shuttle shuttle,
        Avgur avgur,
        ShipRunnerService service)
    {
        TravelResult resultShuttle = service.Run(shuttle, route);
        TravelResult resultAvgur = service.Run(avgur, route);

        Assert.IsType<TravelResult.NoRequiredEngine>(resultShuttle);
        Assert.IsType<TravelResult.LostInSpace>(resultAvgur);
    }

    [Theory]
    [ClassData(typeof(SecondTestDataGenerator))]
    public void VaclasCrewShouldBeDeadAndModifiedVaclasShouldBeComplete(
        Route route,
        Vaclas vaclasWithoutPhotonicDeflector,
        Vaclas vaclasWithPhotonicDeflector,
        ShipRunnerService service)
    {
        TravelResult resultFirst = service.Run(vaclasWithoutPhotonicDeflector, route);
        TravelResult resultSecond = service.Run(vaclasWithPhotonicDeflector, route);

        Assert.IsType<TravelResult.CrewDead>(resultFirst);
        Assert.IsType<TravelResult.Success>(resultSecond);
    }

    [Theory]
    [ClassData(typeof(ThirdTestDataGenerator))]
    public void VaclasShouldBeDeadAvgurShouldLoseDeflectorMeridianShouldBeComplete(
        Route route,
        Vaclas vaclas,
        Avgur avgur,
        Meridian meridian,
        ShipRunnerService service)
    {
        TravelResult resultVaclas = service.Run(vaclas, route);
        TravelResult resultAvgur = service.Run(avgur, route);
        TravelResult resultMeridian = service.Run(meridian, route);

        Assert.IsType<TravelResult.SpaceShipDestroyed>(resultVaclas);
        Assert.IsType<TravelResult.Success>(resultAvgur);
        Assert.False(avgur.Deflector?.IsComplete);
        Assert.IsType<TravelResult.Success>(resultMeridian);
        Assert.True(meridian.Deflector?.IsComplete);
    }

    [Fact]
    public void ShuttleAndVaclasInDefaultSpaceShouldChooseShuttle()
    {
        var route = new Route(new[]
        {
            new Section(
                new DefaultSpace(System.Array.Empty<IDefaultSpaceObstacle>()),
                400),
        });
        var service = new ShipRunnerService();
        TravelResult resultShuttle = service.Run(new Shuttle(), route);
        TravelResult resultVaclas = service.Run(new Vaclas(), route);

        Assert.IsType<TravelResult.Success>(resultShuttle);
        Assert.IsType<TravelResult.Success>(resultVaclas);

        int costShuttle = ((TravelResult.Success)resultShuttle).Cost;
        int costVaclas = ((TravelResult.Success)resultVaclas).Cost;

        Assert.True(costShuttle < costVaclas);
    }

    [Fact]
    public void AvgurAndStellaInDenseNebulaeShouldChooseStella()
    {
        var route = new Route(new[]
        {
            new Section(
                new DenseNebulae(System.Array.Empty<ISubspaceThreadObstacle>()),
                1200),
        });
        var service = new ShipRunnerService();

        TravelResult resultAvgur = service.Run(new Avgur(), route);
        TravelResult resultStella = service.Run(new Stella(), route);

        Assert.IsType<TravelResult.LostInSpace>(resultAvgur);
        Assert.IsType<TravelResult.Success>(resultStella);
    }

    [Fact]
    public void ShuttleAndVaclasInNitrineParticleNebulaeShouldChooseVaclas()
    {
        var route = new Route(new[]
        {
            new Section(
                new NitrineParticleNebulae(System.Array.Empty<INitrineParticleNebulaeObstacle>()),
                5000),
        });
        var service = new ShipRunnerService();

        TravelResult resultShuttle = service.Run(new Shuttle(), route);
        TravelResult resultVaclas = service.Run(new Vaclas(), route);

        Assert.IsType<TravelResult.Success>(resultShuttle);
        Assert.IsType<TravelResult.Success>(resultVaclas);

        int costShuttle = ((TravelResult.Success)resultShuttle).Cost;
        int costVaclas = ((TravelResult.Success)resultVaclas).Cost;

        Assert.True(costShuttle > costVaclas);
    }

    [Fact]
    public void StellaCrewShouldBeDeadVaclasShouldBeDestroyedAvgurCrewShouldBeDeadMeridianCrewShouldBeDead()
    {
        var route = new Route(new[]
        {
            new Section(
                new DenseNebulae(new[]
                {
                    new AntimaterialFlash(),
                }),
                1000),
            new Section(
                new DenseNebulae(System.Array.Empty<ISubspaceThreadObstacle>()),
                2000),
            new Section(
                new NitrineParticleNebulae(new[]
                {
                    new CosmoWhale(),
                }),
                100),
        });
        var service = new ShipRunnerService();

        TravelResult resultStella = service.Run(new Stella(), route);
        TravelResult resultVaclas = service.Run(new Vaclas(PhotonicModifier.True), route);
        TravelResult resultAvgur = service.Run(new Avgur(), route);
        TravelResult resultMeridian = service.Run(new Meridian(), route);

        Assert.IsType<TravelResult.CrewDead>(resultStella);
        Assert.IsType<TravelResult.SpaceShipDestroyed>(resultVaclas);
        Assert.IsType<TravelResult.CrewDead>(resultAvgur);
        Assert.IsType<TravelResult.CrewDead>(resultMeridian);
    }
}