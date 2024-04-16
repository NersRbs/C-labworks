using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Ships.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class TheoryTestWithVaclasAndAugurAndMeredian : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new Vaclas(), 0, 0 };
        yield return new object[] { new Augur(), 100, 0 };
        yield return new object[] { new Meredian(), 50, 60 };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}