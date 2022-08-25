using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace mainumbi.Lakeli;

public class LakeliWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<LakeliWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
