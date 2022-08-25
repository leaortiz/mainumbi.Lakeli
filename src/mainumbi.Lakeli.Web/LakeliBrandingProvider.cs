using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace mainumbi.Lakeli.Web;

[Dependency(ReplaceServices = true)]
public class LakeliBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Lakeli";
}
