//using System;
//using System.Threading.Tasks;
//using Groot.Services.Guru;
//using Hangfire;
//using Microsoft.Extensions.DependencyInjection;
//using Titansoft.MATW.Common.Extensions;
//
//namespace Groot.Jobs.Guru;
//
//// Weekly 1400 GTM +8 trigger
//public class Weekly1400DLoyalProgramJob : IHangfireJob
//{
//    private readonly IGuruService _guruService;
//
//    public Weekly1400DLoyalProgramJob(IServiceProvider sp)
//    {
//        _guruService = sp.GetService<IGuruService>();
//    }
//
//    public HangfireSchedulePlan Configuration()
//    {
//        return HangfireSchedulePlan.Create("0 2 * * 1");
//    }
//
//    [JobDisplayName("Loyal Program Marker Update")]
//    [AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
//    public async Task Execute()
//    {
//        await _guruService.LoyalProgramMarkerUpdate();
//    }
//}
