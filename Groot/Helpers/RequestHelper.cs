using System;
using System.Threading.Tasks;
using Groot.Helpers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NeoLib.Common.Services.Interfaces;
using Newtonsoft.Json;

namespace Groot.Helpers;

public class RequestHelper : IRequestHelper
{
    private readonly INeoRestClient _neoRestClient;
    private readonly ILogger<RequestHelper> _logger;
        
    public RequestHelper(IServiceProvider sp, ILogger<RequestHelper> logger)
    {
        _neoRestClient = sp.GetService<INeoRestClient>();
        _logger = logger;
    }
        
    public async Task Simulate(string url, object request = null)
    {
        await Task.Delay(1000);
        _logger.LogInformation($"[Simulation] Url:{url}, request:{JsonConvert.SerializeObject(request)}");
    }

    public async Task Post(string url, object request = null)
    {
        var response = await _neoRestClient.PostWithoutDeserialize(url, request, null, 18000);
        _logger.LogInformation($"Url:{url}, request:{JsonConvert.SerializeObject(request)}, response:{response}");
    }
}