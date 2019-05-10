using Shouldly;
using Xunit;

namespace RONCBackEnd.Tests
{
    public class BabysFirstTestClass
    {
        [Fact]
        public void BabysFirstTest()
        {
            var thisIsNonsense = false;

            thisIsNonsense.ShouldBeTrue();
        }
    }
}