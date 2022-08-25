using Volo.Abp.Modularity;

namespace mainumbi.Lakeli;

[DependsOn(
    typeof(LakeliApplicationModule),
    typeof(LakeliDomainTestModule)
    )]
public class LakeliApplicationTestModule : AbpModule
{

}
