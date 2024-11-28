using System;
using System.Threading.Tasks;
using NeoLib.Common.Models;

namespace Groot.Services.Dobby;

public interface IDobbyService
{
    Task AccountLifecycleUpdate();
    Task HistoricalLtvUpdate();
    Task LoyalProgramMarkerUpdate(DateTime referDate);
    Task DashboardPromotionUpdate();
    Task ScoringSystemMarkersGenerator();
    Task CasinoNewVoucherUpdate();
    Task GamesNewVoucherUpdate();
    Task CasinoReturnVoucherUpdate();
    Task GamesReturnVoucherUpdate();
    Task CasinoChurnVoucherUpdate();
    Task GamesChurnVoucherUpdate();
    Task B2CVipLevelReport(ClosedOpenInterval interval);
    Task UpdateABTestingPerformance();
    Task GoToPlayRecommendB2C();
    Task GoToPlayRecommendB2B();
    Task RecentLikeB2B();
    Task RecentLikeB2C();
    Task GeneratePlayerGames(int offSet);
    Task TelesalesReport(ClosedOpenInterval interval);
    Task MonthlyTelesalesReport();
}
