using mainumbi.Lakeli.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace mainumbi.Lakeli.Permissions;

public class LakeliPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(LakeliPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(LakeliPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<LakeliResource>(name);
    }
}
