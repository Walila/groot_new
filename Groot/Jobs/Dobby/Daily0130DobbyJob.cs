using System;
using System.Threading.Tasks;
using Groot.Services.Dobby;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Titansoft.MATW.Common.Extensions;

namespace Groot.Jobs.Dobby;

// Daily 1330 GTM +8 trigger
public class Daily0130DobbyJob : IHangfireJob
{
    private readonly IDobbyService _dobbyService;

    public Daily0130DobbyJob(IServiceProvider sp)
    {
        _dobbyService = sp.GetService<IDobbyService>();
    }

    public HangfireSchedulePlan Configuration()
    {
        return HangfireSchedulePlan.Create("30 01 * * *");
    }

    [JobDisplayName("Daily 0130 Dobby Job")]
    [AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
    public async Task Execute()
    {
        await _dobbyService.UpdateABTestingPerformance();
    }
}