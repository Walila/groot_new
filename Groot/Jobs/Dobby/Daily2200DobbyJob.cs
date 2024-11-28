using System.Threading.Tasks;
using Groot.Services.Dobby;
using Hangfire;
using Titansoft.MATW.Common.Extensions;

namespace Groot.Jobs.Dobby;

// Daily 1000 GTM +8 trigger
public class Daily2200DobbyJob(IDobbyService dobbyService) : IHangfireJob
{
    public HangfireSchedulePlan Configuration()
    {
        return HangfireSchedulePlan.Create("0 22 * * *");
    }

    [JobDisplayName("Daily 2200 Dobby Job")]
    [AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
    public Task Execute()
    {
        Task.Factory.StartNew(CasinoVoucherUpdate);
        return Task.CompletedTask;
    }
    
    private async Task CasinoVoucherUpdate()
    {
        await dobbyService.CasinoNewVoucherUpdate();
        await dobbyService.CasinoReturnVoucherUpdate();
        await dobbyService.CasinoChurnVoucherUpdate();
    }
}