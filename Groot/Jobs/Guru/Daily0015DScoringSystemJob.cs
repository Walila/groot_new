// using System;
// using System.Threading.Tasks;
// using Groot.Services.Guru;
// using Hangfire;
// using Microsoft.Extensions.DependencyInjection;
// using Titansoft.MATW.Common.Extensions;
//
// namespace Groot.Jobs.Guru;
//
// // Daily 0015 GTM +8 trigger
// public class Daily0015DScoringSystemJob : IHangfireJob
// {
//     private readonly IGuruService _guruService;
//
//     public Daily0015DScoringSystemJob(IServiceProvider sp)
//     {
//         _guruService = sp.GetService<IGuruService>();
//     }
//
//     public HangfireSchedulePlan Configuration()
//     {
//         return HangfireSchedulePlan.Create("15 00 * * *");
//     }
//
//     [JobDisplayName("Markers of Scoring System Update")]
//     [AutomaticRetry(Attempts = 0, OnAttemptsExceeded = AttemptsExceededAction.Fail)]
//     public async Task Execute()
//     {
//         await _guruService.ScoringSystemMarkersGenerator();
//         
//     }
// }
