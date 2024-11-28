using System;
using System.Threading.Tasks;
using Groot.Services.Dobby;
using Hangfire;
using NeoLib.Common.Models;
using Titansoft.MATW.Common.Extensions;

namespace Groot.Jobs.Dobby;

// Daily 1000 GTM +8 trigger
public class Monday1700DobbyJob(IDobbyService dobbyService) : IHangfireJob
{
    public HangfireSchedulePlan Configuration()
    {
        return HangfireSchedulePlan.Create("0 5 * * MON");
    }

    [JobDisplayName("Monday 1700 Dobby Job")]
    [AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
    public Task Execute()
    {
        Task.Factory.StartNew(VipReport);
        Task.Factory.StartNew(TelesalesReport);
        return Task.CompletedTask;
    }

    private async Task VipReport()
    {
        var interval = new ClosedOpenInterval
        {
            From = DateTime.Today.AddDays(-7),
            To = DateTime.Today
        };
        await dobbyService.B2CVipLevelReport(interval);
    }
    
    private async Task TelesalesReport()
    {
        var interval = new ClosedOpenInterval
        {
            From = DateTime.Today.AddDays(-7),
            To = DateTime.Today
        };
        await dobbyService.TelesalesReport(interval);
    }
}