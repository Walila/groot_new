//using System.Threading.Tasks;
//using Groot.Services.Guru;
//using Hangfire;
//using Titansoft.MATW.Common.Extensions;
//
//namespace Groot.Jobs.Guru;
//
//// Daily 0800 GTM +8 trigger
//public class Daily0800DGamesVoucherPerformanceJob(IGuruService guruService) : IHangfireJob
//{
//    public HangfireSchedulePlan Configuration()
//    {
//        return HangfireSchedulePlan.Create("0 20 * * *");
//    }
//
//    [JobDisplayName("Game voucher performance data processing")]
//    [AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
//    public Task Execute()
//    {
//        // todo: need change simulate to post when confirm migrate
//        Task.Factory.StartNew(GamesVoucherUpdate);
//        return Task.CompletedTask;
//    }
//
//    private async Task GamesVoucherUpdate()
//    {
//        await guruService.GamesNewVoucherUpdate();
//        await guruService.GamesReturnVoucherUpdate();
//        await guruService.GamesChurnVoucherUpdate();
//    }
//}
