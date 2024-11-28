using System;
using System.Threading.Tasks;
using Groot.Helpers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Groot.Services.Conan;

public class ConanService : IConanService
{
    private readonly string _baseUrl;
    private readonly IRequestHelper _requestHelper;

    public ConanService(IServiceProvider sp)
    {
        var recordHelper = sp.GetService<IRecordHelper>();
        _baseUrl = recordHelper?.GetUrl("conan");

        _requestHelper = sp.GetService<IRequestHelper>();
    }

    public Task HourJobUpdate()
    {
        var url = $"{_baseUrl}/hour_job";
        return _requestHelper.Post(url);
    }
}
