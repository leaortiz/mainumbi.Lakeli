using mainumbi.Lakeli.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace mainumbi.Lakeli;

[DependsOn(
    typeof(LakeliEntityFrameworkCoreTestModule)
    )]
public class LakeliDomainTestModule : AbpModule
{

}
