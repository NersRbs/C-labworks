using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Environments.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Route.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.PhotonicDeflectors;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class RouteTests
{
    [Theory]
    [ClassData(typeof(TheoryTestWithPleasureShuttleAndAugur))]
    public void Check_ShouldResultNotSuccessStatus(IShip ship)
    {
        // Arrange
        var route = new Route.Entities.Route(new Segment(
            2000,
            new NebulaeOfIncreasedDensityOfSpace(new List<INebulaeOfIncreasedDensityOfSpaceObstacle>())));

        // Act
        Status result = route.Check(ship).First();

        // Assert
        Assert.Equal(new Status.LossOfTheShip(), result);
    }

    [Theory]
    [ClassData(typeof(TheoryTestWithVaclasAndVaclasWithPhotonicDeflector))]
    public void Check_ShouldResultSuccessStatus(IShip ship, Type expectedResult)
    {
        // Arrange
        var route = new Route.Entities.Route(new Segment(
            1000,
            new NebulaeOfIncreasedDensityOfSpace(new List<INebulaeOfIncreasedDensityOfSpaceObstacle>()
            {
                new AntimatterNebulaeOfIncreasedDensityOfSpaceObstacle(),
                new AntimatterNebulaeOfIncreasedDensityOfSpaceObstacle(),
                new AntimatterNebulaeOfIncreasedDensityOfSpaceObstacle(),
            })));

        // Act
        Status result = route.Check(ship).First();

        // Assert
        Assert.True(result.GetType() == expectedResult);
    }

    [Theory]
    [ClassData(typeof(TheoryTestWithVaclasAndAugurAndMeredian))]
    public void Check_ShouldResultDestroyedAndLostTheDiffectorAndNotTouched(IShip ship, int caseStrengthHp, int deflectorHp)
    {
        // Arrange
        var route = new Route.Entities.Route(new Segment(1000, new NebulaeOfNitrideParticles(new List<INebulaeOfNitrideParticlesObstacle>() { new CosmoWhales() })));

        // Act
        route.Check(ship);

        // Assert
        Assert.Equal(ship.CaseStrength.HealthPoints.Health, caseStrengthHp);
        Assert.Equal(ship.Deflector.HealthPoints.Health, deflectorHp);
    }

    [Fact]
    public void Optimal_ShouldResultPleasureShuttleBetterVaclas()
    {
        // Arrange
        var pleasureShuttle = new PleasureShuttle();
        var vaclas = new Vaclas();

        var route = new Route.Entities.Route(new Segment(1000, new OrdinarySpace(new List<IOrdinarySpaceObstacle>())));

        // Act
        IShip? result = route.Optimal(pleasureShuttle, vaclas);

        // Assert
        Assert.Equal(pleasureShuttle, result);
    }

    [Fact]
    public void Optimal_ShouldResultStella()
    {
        // Arrange
        var augur = new Augur();
        var stella = new Stella();

        var route = new Route.Entities.Route(new Segment(
            2000,
            new NebulaeOfIncreasedDensityOfSpace(new List<INebulaeOfIncreasedDensityOfSpaceObstacle>())));

        // Act
        IShip? result = route.Optimal(augur, stella);

        // Assert
        Assert.Equal(stella, result);
    }

    [Fact]
    public void Optimal_ShouldResultVaclas()
    {
        // Arrange
        var pleasureShuttle = new PleasureShuttle();
        var vaclas = new Vaclas();

        var route = new Route.Entities.Route(new Segment(
            2000,
            new NebulaeOfNitrideParticles(new List<INebulaeOfNitrideParticlesObstacle>())));

        // Act
        IShip? result = route.Optimal(pleasureShuttle, vaclas);

        // Assert
        Assert.Equal(vaclas, result);
    }

    [Fact]
    public void Optimal_ShouldResultVaclasWithPhotonicDeflector()
    {
        var pleasureShuttle = new PleasureShuttle();
        var vaclas = new Vaclas();
        var vaclasWithPhotonicDeflector = new Vaclas(new BasePhotonicDeflector());
        var augurWithPhotonicDeflector = new Augur(new BasePhotonicDeflector());

        var route = new Route.Entities.Route(
            new Segment(100, new OrdinarySpace(new List<IOrdinarySpaceObstacle>() { new Asteroids() })),
            new Segment(
                2000,
                new NebulaeOfIncreasedDensityOfSpace(new List<INebulaeOfIncreasedDensityOfSpaceObstacle>()
                {
                    new AntimatterNebulaeOfIncreasedDensityOfSpaceObstacle(),
                    new AntimatterNebulaeOfIncreasedDensityOfSpaceObstacle(),
                    new AntimatterNebulaeOfIncreasedDensityOfSpaceObstacle(),
                })),
            new Segment(300, new NebulaeOfNitrideParticles(new List<INebulaeOfNitrideParticlesObstacle>())));

        // Act
        IShip? result = route.Optimal(pleasureShuttle, vaclas, vaclasWithPhotonicDeflector, augurWithPhotonicDeflector);

        // Assert
        Assert.Equal(vaclasWithPhotonicDeflector, result);
    }
}