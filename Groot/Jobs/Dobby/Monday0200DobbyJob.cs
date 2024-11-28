using System;
using System.Threading.Tasks;
using Groot.Services.Dobby;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Titansoft.MATW.Common.Extensions;

namespace Groot.Jobs.Dobby;

// Daily 1400 GTM +8 trigger
public class Monday0200DobbyJob : IHangfireJob
{
    private readonly IDobbyService _dobbyService;

    public Monday0200DobbyJob(IServiceProvider sp)
    {
        _dobbyService = sp.GetService<IDobbyService>();
    }

    public HangfireSchedulePlan Configuration()
    {
        return HangfireSchedulePlan.Create("0 2 * * 1");
    }

    [JobDisplayName("Monday 0200 Dobby Job")]
    [AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
    public async Task Execute()
    {
        await _dobbyService.LoyalProgramMarkerUpdate(DateTime.Today);
    }
}