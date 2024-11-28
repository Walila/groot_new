using System.Threading.Tasks;
using Groot.Services.Dobby;
using Hangfire;
using Titansoft.MATW.Common.Extensions;

namespace Groot.Jobs.Dobby;

// Daily 1400 GTM +8 trigger
public class Daily0145RecentLikeJob(IDobbyService dobbyService) : IHangfireJob
{
    public HangfireSchedulePlan Configuration()
    {
        return HangfireSchedulePlan.Create("45 01 * * *");
    }
        
    [JobDisplayName("Generate player recent like top 5 games")]
    [AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
    public async Task Execute()
    {
        await dobbyService.RecentLikeB2B();
        await dobbyService.RecentLikeB2C();
    }
}