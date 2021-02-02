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
        }
        public static LocalizableString L(string name)=> LocalizableString.Create<SampleResource>(name);
    }
}
