using System.Threading.Tasks;
using Groot.Services.Dobby;
using Hangfire;
using Titansoft.MATW.Common.Extensions;

namespace Groot.Jobs.Dobby;

// Daily 1306 GTM +8 trigger
public class Daily0106B2CGoToPlayRecommendationJob(IDobbyService dobbyService) : IHangfireJob
{
    public HangfireSchedulePlan Configuration()
    {
        return HangfireSchedulePlan.Create("6 1 * * 5");
    }

    [JobDisplayName("B2C go to play games recommendation data processing")]
    [AutomaticRetry(Attempts = 3, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
    public async Task Execute()
    {
        await dobbyService.GoToPlayRecommendB2C();
    }
}