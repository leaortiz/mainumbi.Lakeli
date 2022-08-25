using mainumbi.Lakeli.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace mainumbi.Lakeli.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class LakeliController : AbpControllerBase
{
    protected LakeliController()
    {
        LocalizationResource = typeof(LakeliResource);
    }
}
