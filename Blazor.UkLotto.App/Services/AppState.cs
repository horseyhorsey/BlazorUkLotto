using Blazor.UkLotto.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.UkLotto.App.Services
{
    public class AppState
    {
        private IUkLotteryService _ukLotteryService;        

        public AppState(IUkLotteryService ukLotteryService)
        {
            _ukLotteryService = ukLotteryService;
        }

        public IEnumerable<LotteryDraw> LotteryDraws { get; set; }

        public async Task<bool> GetLatest()
        {
            if (LotteryDraws == null)
            {
                LotteryDraws = await _ukLotteryService.GetLatest();
                return true;
            }

            return false;
        }
    }
}
