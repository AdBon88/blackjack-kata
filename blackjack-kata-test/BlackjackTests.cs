using System;
using Xunit;

namespace blackjack_kata
{
    public class UnitTest1
    {
        [Fact]
        public void Test1_createDeckOf52Cards()
        {
            const int expected = 0;
            int actual = new StringCalculator().Calculate("");
            Assert.Equal(expected, actual);
        }
    }
}
