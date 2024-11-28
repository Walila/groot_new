using System;
using Groot.Helpers.Interfaces;
using Microsoft.Extensions.Hosting;

namespace Groot.Helpers;

public class RecordHelper : IRecordHelper
{
    public RecordHelper(IHostEnvironment env)
    {
    }

    public string GetUrl(string projectDomain)
    {
        if (projectDomain == null)
        {
            throw new ArgumentNullException("Missing project domain in parameter");
        }

        return $"http://{projectDomain}.ma.svc.cluster.local";
    }
}
