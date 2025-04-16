using ABPDemo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace ABPDemo.Permissions;

public class ABPDemoPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(ABPDemoPermissions.GroupName);

        var booksPermission = myGroup.AddPermission(ABPDemoPermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(ABPDemoPermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(ABPDemoPermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(ABPDemoPermissions.Books.Delete, L("Permission:Books.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(ABPDemoPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<ABPDemoResource>(name);
    }
}
