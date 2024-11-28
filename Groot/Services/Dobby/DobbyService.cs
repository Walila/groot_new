using System;
using System.Threading.Tasks;
using Groot.Extensions;
using Groot.Helpers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NeoLib.Common.Models;

namespace Groot.Services.Dobby;

public class DobbyService : IDobbyService
{
    private readonly string         _baseUrl;
    private readonly IRequestHelper _requestHelper;

    public DobbyService(IServiceProvider sp)
    {
        var recordHelper = sp.GetService<IRecordHelper>();
        _baseUrl = recordHelper?.GetUrl("dobby");

        _requestHelper = sp.GetService<IRequestHelper>();
    }

    public Task AccountLifecycleUpdate()
    {
        var url = $"{_baseUrl}/job/upload_account_lifecycle";
        return _requestHelper.Post(url);
    }

    public Task HistoricalLtvUpdate()
    {
        var url = $"{_baseUrl}/job/update_historical_ltv";
        return _requestHelper.Post(url);
    }

    public Task LoyalProgramMarkerUpdate(DateTime referDate)
    {
        var url = $"{_baseUrl}/job/update_loyal_program_markers";
        return _requestHelper.Post(url, referDate);
    }

    public Task DashboardPromotionUpdate()
    {
        var interval = DateTime.Today.GetDaysInterval(-30, 0);
        var url      = $"{_baseUrl}/job/update_dashboard_promotion";
        return _requestHelper.Post(url, interval);
    }

    public Task ScoringSystemMarkersGenerator()
    {
        var url = $"{_baseUrl}/job/scoring_system_markers";
        return _requestHelper.Post(url);
    }

    public Task CasinoNewVoucherUpdate()
    {
        return _requestHelper.Post($"{_baseUrl}/job/new_casino_performance");
    }

    public Task GamesNewVoucherUpdate()
    {
        return _requestHelper.Post($"{_baseUrl}/job/new_games_performance");
    }

    public Task CasinoReturnVoucherUpdate()
    {
        return _requestHelper.Post($"{_baseUrl}/job/return_casino_performance");
    }

    public Task GamesReturnVoucherUpdate()
    {
        return _requestHelper.Post($"{_baseUrl}/job/return_games_performance");
    }

    public Task CasinoChurnVoucherUpdate()
    {
        return _requestHelper.Post($"{_baseUrl}/job/churn_casino_performance");
    }

    public Task GamesChurnVoucherUpdate()
    {
        return _requestHelper.Post($"{_baseUrl}/job/churn_games_performance");
    }

    public Task B2CVipLevelReport(ClosedOpenInterval interval)
    {
        return _requestHelper.Post($"{_baseUrl}/job/send_B2C_weekly_vip_report", interval);
    }

    public Task UpdateABTestingPerformance()
    {
        return _requestHelper.Post($"{_baseUrl}/job/update_g2g_eDM_testing_performance");
    }

    public async Task GoToPlayRecommendB2B()
    {
        var today = DateTime.Today.ToString("yyyy-MM-dd");

        var request = new { referDate = today };

        var b2BUrl = $"{_baseUrl}/job/gotoplayb2b";
        await _requestHelper.Post(b2BUrl, request);
    }

    public async Task GoToPlayRecommendB2C()
    {
        var today = DateTime.Today.ToString("yyyy-MM-dd");

        var request = new { referDate = today };

        var b2CUrl = $"{_baseUrl}/job/gotoplayb2c";
        await _requestHelper.Post(b2CUrl, request);
    }

    public async Task RecentLikeB2B()
    {
        var today = DateTime.Today.ToString("yyyy-MM-dd");

        var request = new { referDate = today };

        var url = $"{_baseUrl}/job/recentlikeb2b";
        await _requestHelper.Post(url, request);
    }

    public async Task RecentLikeB2C()
    {
        var today = DateTime.Today.ToString("yyyy-MM-dd");

        var request = new { referDate = today };

        var url = $"{_baseUrl}/job/recentlikeb2c";
        await _requestHelper.Post(url, request);
    }

    public async Task GeneratePlayerGames(int offSet)
    {
        var generatedDay = DateTime.Today.AddDays(offSet).ToString("yyyy-MM-dd");

        var url = $"{_baseUrl}/job/playergames";

        await _requestHelper.Post(url, generatedDay);
        ;
    }

    public Task TelesalesReport(ClosedOpenInterval interval)
    {
        return _requestHelper.Post($"{_baseUrl}/job/send_telesales_performance_report", interval);
    }

    public Task MonthlyTelesalesReport()
    {
        return _requestHelper.Post($"{_baseUrl}/job/send_monthly_telesales_performance_report");
    }
}