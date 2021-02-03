using Allegory.Sample.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Allegory.Sample.Permissions
{
    public class SamplePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var sampleGroup = context.AddGroup(SamplePermissions.GroupName);

            var productPermission = sampleGroup.AddPermission(SamplePermissions.Products.Default, L("Permission:Products"));
            productPermission.AddChild(SamplePermissions.Products.Create, L("Permission:Products.Create"));
            productPermission.AddChild(SamplePermissions.Products.Edit, L("Permission:Products.Edit"));
            productPermission.AddChild(SamplePermissions.Products.Delete, L("Permission:Products.Delete"));

        }
        public static LocalizableString L(string name) => LocalizableString.Create<SampleResource>(name);
    }
}
