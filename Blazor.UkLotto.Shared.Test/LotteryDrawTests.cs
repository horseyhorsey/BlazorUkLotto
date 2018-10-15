using System;
using System.Linq;
using Xunit;

namespace Blazor.UkLotto.Shared.Test
{
    public class LotteryDrawTests
    {
        [Fact]
        public void GetLatestDrawsTest()
        {
            Shared.LotteryDrawFactory fact = new LotteryDrawFactory();
            var lottoStr = fact.GetDrawHistory();

            Assert.True(lottoStr?.Count() > 10);
        }
    }
}
 