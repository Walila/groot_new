using System.Threading.Tasks;
using Groot.Services.Dobby;
using Hangfire;
using Titansoft.MATW.Common.Extensions;

namespace Groot.Jobs.Dobby;

// Daily 1300 GTM +8 trigger
public class Daily0100PlayerGamesJob(IDobbyService dobbyService) : IHangfireJob
{
    public HangfireSchedulePlan Configuration()
    {
        return HangfireSchedulePlan.Create("0 1 * * *");
    }
        
    [JobDisplayName("generate daily player games data")]
    [AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
    public async Task Execute()
    {
        const int generateYesterday = -1;
        const int generateFourDaysAgo = -4;
        await dobbyService.GeneratePlayerGames(generateYesterday);
        await dobbyService.GeneratePlayerGames(generateFourDaysAgo);
        
        // var generateYesterdayOrderTb = Task.Run(() => maLocalStorageService.GenerateOrderTb(-1));
        // var generateFourDaysAgoOrderTb = Task.Run(() => maLocalStorageService.GenerateOrderTb(-4));
        // await generateYesterdayOrderTb;
        // await generateFourDaysAgoOrderTb;
    }
}