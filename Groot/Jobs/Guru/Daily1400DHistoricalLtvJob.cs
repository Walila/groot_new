//using System;
//using System.Threading.Tasks;
//using Groot.Services.Guru;
//using Hangfire;
//using Microsoft.Extensions.DependencyInjection;
//using Titansoft.MATW.Common.Extensions;
//
//namespace Groot.Jobs.Guru;
//
//// Daily 1400 GTM +8 trigger
//public class Daily1400DHistoricalLtvJob : IHangfireJob
//{
//    private readonly IGuruService _guruService;
//
//    public Daily1400DHistoricalLtvJob(IServiceProvider sp)
//    {
//        _guruService = sp.GetService<IGuruService>();
//    }
//
//    public HangfireSchedulePlan Configuration()
//    {
//        return HangfireSchedulePlan.Create("0 2 * * *");
//    }
//
//    [JobDisplayName("Historical LTV Update")]
//    [AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
//    public async Task Execute()
//    {
//        await _guruService.HistoricalLtvUpdate();
//
//    }
//}
