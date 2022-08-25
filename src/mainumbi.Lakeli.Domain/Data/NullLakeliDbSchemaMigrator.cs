using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace mainumbi.Lakeli.Data;

/* This is used if database provider does't define
 * ILakeliDbSchemaMigrator implementation.
 */
public class NullLakeliDbSchemaMigrator : ILakeliDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
