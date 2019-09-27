using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace FoodComposition
{
    [TestFixture]
    public class UnitFactoryTest
    {
        
        [TestCase("kJ", Unit.Kj)]
        [TestCase("g", Unit.Gram)]
        [TestCase("ug", Unit.Microgram)]
        [TestCase("mg", Unit.Milligram)]
        public void TestDefaultLookupUnits(string key, Unit value)
        {
            UnitFactory.Default.Lookup(key).Should().Be(value);
        }

    }
}