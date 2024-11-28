using System.Threading.Tasks;
using Groot.Services.Dobby;
using Hangfire;
using Titansoft.MATW.Common.Extensions;

namespace Groot.Jobs.Dobby;

// Daily 0800 GTM +8 trigger
public class Daily2000DobbyJob(IDobbyService dobbyService) : IHangfireJob
{
    public HangfireSchedulePlan Configuration()
    {
        return HangfireSchedulePlan.Create("0 20 * * *");
    }

    [JobDisplayName("Daily 2000 Dobby Job")]
    [AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
    public Task Execute()
    {
        Task.Factory.StartNew(GamesVoucherUpdate);
        return Task.CompletedTask;
    }
    
    private async Task GamesVoucherUpdate()
    {
        await dobbyService.GamesNewVoucherUpdate();
        await dobbyService.GamesReturnVoucherUpdate();
        await dobbyService.GamesChurnVoucherUpdate();
    }
}