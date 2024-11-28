using System.Threading.Tasks;

namespace Groot.Services.Guru;

public interface IGuruService
{
    Task AccountLifecycleUpdate();
    Task UpdateChurnPerformance();

    Task CasinoNewVoucherUpdate();
    Task CasinoReturnVoucherUpdate();

    Task GamesNewVoucherUpdate();
    Task GamesReturnVoucherUpdate();

    Task CasinoChurnVoucherUpdate();
    Task GamesChurnVoucherUpdate();

    Task HistoricalLtvUpdate();
    
    Task ScoringSystemMarkersGenerator();
    Task LoyalProgramMarkerUpdate();
}
