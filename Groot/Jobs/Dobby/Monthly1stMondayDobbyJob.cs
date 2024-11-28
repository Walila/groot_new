using System;
using System.Threading.Tasks;
using Groot.Services.Dobby;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Titansoft.MATW.Common.Extensions;

namespace Groot.Jobs.Dobby;

// Daily 1400 GTM +8 trigger
public class Monthly1stMondayDobbyJob : IHangfireJob
{
    private readonly IDobbyService _dobbyService;

    public Monthly1stMondayDobbyJob(IServiceProvider sp)
    {
        _dobbyService = sp.GetService<IDobbyService>();
    }

    public HangfireSchedulePlan Configuration()
    {
        return HangfireSchedulePlan.Create("30 5 1-7 * MON");
    }

    [JobDisplayName("Monday 0200 Dobby Job")]
    [AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
    public async Task Execute()
    {
        await _dobbyService.MonthlyTelesalesReport();
    }
}