//using System.Threading.Tasks;
//using Groot.Services.Guru;
//using Hangfire;
//using Titansoft.MATW.Common.Extensions;
//
//namespace Groot.Jobs.Guru;
//
//// Daily 1000 GTM +8 trigger
//public class Daily1000DCasinoVoucherPerformanceJob(IGuruService guruService) : IHangfireJob
//{
//    public HangfireSchedulePlan Configuration()
//    {
//        return HangfireSchedulePlan.Create("0 22 * * *");
//    }
//
//    [JobDisplayName("Casino voucher performance data processing")]
//    [AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
//    public Task Execute()
//    {
//        // todo: need change simulate to post when confirm migrate
//        Task.Factory.StartNew(CasinoVoucherUpdate);
//        return Task.CompletedTask;
//    }
//
//    private async Task CasinoVoucherUpdate()
//    {
//        await guruService.CasinoNewVoucherUpdate();
//        await guruService.CasinoReturnVoucherUpdate();
//        await guruService.CasinoChurnVoucherUpdate();
//    }
//}
