using mainumbi.Lakeli.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace mainumbi.Lakeli.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(LakeliEntityFrameworkCoreModule),
    typeof(LakeliApplicationContractsModule)
    )]
public class LakeliDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
