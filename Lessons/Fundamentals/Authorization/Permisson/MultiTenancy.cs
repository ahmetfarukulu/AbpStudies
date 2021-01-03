using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.MultiTenancy;

namespace Authorization
{
    public class BookStorePermissionDefinitionProvider2 : PermissionDefinitionProvider
    {
        /*
         ABP supports multi-tenancy as a first class citizen. You can define multi-tenancy side option while defining a new permission. It gets one of the three values defined below:

         Host: The permission is available only for the host side.
         Tenant: The permission is available only for the tenant side.
         Both (default): The permission is available both for tenant and host sides.
        */
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup("BookStore"
                , multiTenancySide: MultiTenancySides.Tenant //set multi-tenancy side!
                );

            myGroup.AddPermission("BookStore_Author_Create");
        }
    }
}
