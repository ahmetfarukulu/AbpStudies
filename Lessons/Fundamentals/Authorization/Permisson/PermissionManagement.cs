using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.PermissionManagement;

namespace Authorization
{
    public class MyService : ITransientDependency
    {
        private readonly IPermissionManager _permissionManager;

        public MyService(IPermissionManager permissionManager)
        {
            _permissionManager = permissionManager;
        }

        public async Task GrantPermissionForUserAsync(Guid userId, string permissionName)
        {
            await _permissionManager.SetForUserAsync(userId, permissionName, true);
        }

        public async Task ProhibitPermissionForUserAsync(Guid userId, string permissionName)
        {
            await _permissionManager.SetForUserAsync(userId, permissionName, false);
        }
    }
}
