using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;

namespace Authorization
{
    public class SystemAdminPermissionValueProvider : PermissionValueProvider
    {
        public SystemAdminPermissionValueProvider(IPermissionStore permissionStore) : base(permissionStore) { }

        public override string Name => "SystemAdmin";

        public override Task<PermissionGrantResult> CheckAsync(PermissionValueCheckContext context)
        {
            if (context.Principal?.FindFirst("User_Type")?.Value == "SystemAdmin")
            {
                return Task.FromResult(PermissionGrantResult.Granted);
            }

            return Task.FromResult(PermissionGrantResult.Undefined);
        }

        public override Task<MultiplePermissionGrantResult> CheckAsync(PermissionValuesCheckContext context)
        {
            if (context.Principal?.FindFirst("User_Type")?.Value == "SystemAdmin")
            {

                return Task.FromResult(new MultiplePermissionGrantResult(new string[] { "" }, PermissionGrantResult.Granted));
            }
            return Task.FromResult(new MultiplePermissionGrantResult(new string[] { "" }, PermissionGrantResult.Undefined));
        }
    }
}
/*
     Once a provider is defined, it should be added to the AbpPermissionOptions as shown below;
     Configure<AbpPermissionOptions>(options =>
     {
         options.ValueProviders.Add<SystemAdminPermissionValueProvider>();
     });
*/