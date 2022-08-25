using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using mainumbi.Lakeli.Data;
using Volo.Abp.DependencyInjection;

namespace mainumbi.Lakeli.EntityFrameworkCore;

public class EntityFrameworkCoreLakeliDbSchemaMigrator
    : ILakeliDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreLakeliDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the LakeliDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<LakeliDbContext>()
            .Database
            .MigrateAsync();
    }
}
