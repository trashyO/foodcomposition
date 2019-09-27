using FluentAssertions;
using NUnit.Framework;

namespace FoodComposition
{
    [TestFixture]
    public class ValueTest
    {

        [TestCase]
        public void TestValuesAreEqual()
        {
            var expected = new Value(100, Unit.Gram);
            var actual = new Value(100, Unit.Gram);

            expected.Should().Be(actual);
        }
        
        //TODO: Add test for null equality check
        
        //TODO: add test for other paths through equals code, so I understand it better
        
        //TODO: add test for hashcode
    }
}