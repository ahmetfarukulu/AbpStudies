using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;

namespace Authorization
{
    public class BookStorePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        //You typically define this class inside the Application.Contracts project of your application. The startup template already comes with an empty class named YourProjectNamePermissionDefinitionProvider that you can start with.
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup("BookStore");

            myGroup.AddPermission("BookStore_Author_Create");
        }
    }
}
