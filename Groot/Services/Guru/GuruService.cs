using System;
using System.Threading.Tasks;
using Groot.Helpers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Groot.Services.Guru;

public class GuruService : IGuruService
{
    private readonly string _baseUrl;
    private readonly IRequestHelper _requestHelper;

    public GuruService(IServiceProvider sp)
    {
        var recordHelper = sp.GetService<IRecordHelper>();
        _baseUrl = recordHelper?.GetUrl("guru");

        _requestHelper = sp.GetService<IRequestHelper>();
    }

    public Task AccountLifecycleUpdate()
    {
        return _requestHelper.Post($"{_baseUrl}/uploadaccountlifecyle");
    }

    public Task UpdateChurnPerformance()
    {
        return _requestHelper.Post($"{_baseUrl}/job/churnperformance");
    }

    public Task CasinoNewVoucherUpdate()
    {
        return _requestHelper.Post($"{_baseUrl}/job/newcasinoperformance");
    }

    public Task GamesNewVoucherUpdate()
    {
        return _requestHelper.Post($"{_baseUrl}/job/newgamesperformance");
    }

    public Task CasinoReturnVoucherUpdate()
    {
        return _requestHelper.Post($"{_baseUrl}/job/returncasinoperformance");
    }

    public Task GamesReturnVoucherUpdate()
    {
        return _requestHelper.Post($"{_baseUrl}/job/returngamesperformance");
    }

    public Task CasinoChurnVoucherUpdate()
    {
        return _requestHelper.Post($"{_baseUrl}/job/churncasinoperformance");
    }

    public Task GamesChurnVoucherUpdate()
    {
        return _requestHelper.Post($"{_baseUrl}/job/churngamesperformance");
    }
    public Task HistoricalLtvUpdate()
    {
        return _requestHelper.Post($"{_baseUrl}/job/updatehistoricalltv");
    }

    public Task ScoringSystemMarkersGenerator()
    {
        return _requestHelper.Post($"{_baseUrl}/job/scoring_system_markers");
    }
    public Task LoyalProgramMarkerUpdate()
    {
        return _requestHelper.Post($"{_baseUrl}/job/updateloyalprogrammarker");
    }

}
