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
//public class Daily1400DAccountLifecycleJob : IHangfireJob
//{
//    private readonly IGuruService _guruService;
//
//    public Daily1400DAccountLifecycleJob(IServiceProvider sp)
//    {
//        _guruService = sp.GetService<IGuruService>();
//    }
//
//    public HangfireSchedulePlan Configuration()
//    {
//        return HangfireSchedulePlan.Create("0 2 * * *");
//    }
//
//    [JobDisplayName("Account Lifecycle")]
//    [AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
//    public async Task Execute()
//    {
//        await _guruService.AccountLifecycleUpdate();
//
//    }
//}
