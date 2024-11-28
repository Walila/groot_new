using System;
using System.Threading.Tasks;
using Groot.Services.Dobby;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Titansoft.MATW.Common.Extensions;

namespace Groot.Jobs.Dobby;

// Daily 1215 GTM +8 trigger
public class Daily0015DobbyJob : IHangfireJob
{
    private readonly IDobbyService _dobbyService;

    public Daily0015DobbyJob(IServiceProvider sp)
    {
        _dobbyService = sp.GetService<IDobbyService>();
    }

    public HangfireSchedulePlan Configuration()
    {
        return HangfireSchedulePlan.Create("15 00 * * *");
    }

    [JobDisplayName("Daily 0015 Dobby Job")]
    [AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
    public async Task Execute()
    {
        await _dobbyService.ScoringSystemMarkersGenerator();
    }
}