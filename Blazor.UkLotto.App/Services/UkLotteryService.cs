using Blazor.UkLotto.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.UkLotto.App.Services
{
    public interface IUkLotteryService
    {
        Task<IEnumerable<LotteryDraw>> GetLatest();
    }

    public class UkLotteryService : IUkLotteryService
    {
        public UkLotteryService()
        {

        }

        public Task<IEnumerable<LotteryDraw>> GetLatest()
        {
            var factory = new Blazor.UkLotto.Shared.LotteryDrawFactory();
            return Task.Run(() => factory.GetDrawHistory());
        }
    }
}
