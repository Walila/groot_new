using System;
using System.Threading.Tasks;
using Groot.Services.Conan;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Titansoft.MATW.Common.Extensions;

namespace Groot.Jobs.Conan;

// Daily 1215 GTM +8 trigger
public class Hourly0025ConanJob : IHangfireJob
{
    private readonly IConanService _conanService;

    public Hourly0025ConanJob(IServiceProvider sp)
    {
        _conanService = sp.GetService<IConanService>();
    }

    public HangfireSchedulePlan Configuration()
    {
        return HangfireSchedulePlan.Create("25 * * * *");
    }

    [JobDisplayName("Hourly 0025 Conan Job")]
    [AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
    public async Task Execute()
    {
        await _conanService.HourJobUpdate();
    }
}