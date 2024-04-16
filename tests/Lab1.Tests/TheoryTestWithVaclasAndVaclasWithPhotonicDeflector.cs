using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Route.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Models.PhotonicDeflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class TheoryTestWithVaclasAndVaclasWithPhotonicDeflector : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new Vaclas(), typeof(Status.DeathOfTheCrew) };
        yield return new object[] { new Vaclas(new BasePhotonicDeflector()), typeof(Status.Success) };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}