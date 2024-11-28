using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NeoLib.Config.Extensions;
using Groot.Helpers;
using Groot.Services.Guru;
using Groot.Services.Dobby;
using Groot.Services.Conan;
using Serilog;
using Serilog.Events;
using Titansoft.AspNetCore.Logging;
using Titansoft.AspNetCore.Logging.Middlewares.AccessLogs;
using Titansoft.MATW.Common.Extensions;
using Titansoft.SDK.Account.Redis.Manager;
using Titansoft.SDK.Account.Redis.StartUp;
using IRecordHelper = Groot.Helpers.Interfaces.IRecordHelper;
using IRequestHelper = Groot.Helpers.Interfaces.IRequestHelper;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseLogger(context =>
{
    LoggingConfig.SetMinimumLevel(LogEventLevel.Information).EnableLogFile(
        context.HostingEnvironment.IsDevelopment(),
        "c:/log/Groot",
        RollingInterval.Day,
        3);
});
ConfigureServices();
var app = builder.Build();
Configure();
app.Run();



void ConfigureServices()
{
    builder.Services.ConfigNeoLib();

    builder.Services.AddControllers();
    builder.Services.AddRedis(builder.Configuration);
    if (builder.Configuration.IsRedisEnable())
    {
        builder.Services.AddHangFire(builder.Configuration, RedisConnectionManager.Connection);
    }
    else
    {
        //If want to use 2.0.0 version need to config dashboard and Jobs Storage 
        builder.Services.AddHangFire(builder.Configuration);
    }
    // builder.Services.AddSingleton<ApiExceptionFilter>();
    builder.Services.ConfigHealthCheck();
    builder.Services.AddSingleton<IGuruService, GuruService>();
    builder.Services.AddSingleton<IDobbyService, DobbyService>();
    builder.Services.AddSingleton<IConanService, ConanService>();
    builder.Services.AddSingleton<IRequestHelper, RequestHelper>();
    builder.Services.AddSingleton<IRecordHelper, RecordHelper>();
}

void Configure()
{
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    app.UseHangFire();
    
    app.UseRouting();
    
    app.UseAuthorization();
    
    app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    
    app.UseHealthCheck();

    app.EnableAccessLog().ExcludeFilter(log => log.Path.StartsWith("/health"));
}