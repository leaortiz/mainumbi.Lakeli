using System;
using System.Collections.Generic;
using System.Text;
using mainumbi.Lakeli.Localization;
using Volo.Abp.Application.Services;

namespace mainumbi.Lakeli;

/* Inherit your application services from this class.
 */
public abstract class LakeliAppService : ApplicationService
{
    protected LakeliAppService()
    {
        LocalizationResource = typeof(LakeliResource);
    }
}
