using mainumbi.Lakeli.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace mainumbi.Lakeli.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class LakeliPageModel : AbpPageModel
{
    protected LakeliPageModel()
    {
        LocalizationResourceType = typeof(LakeliResource);
    }
}
