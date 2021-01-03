using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Services;

namespace Authorization
{
    [Authorize]
    public class AuthorAppService : ApplicationService, IAuthorAppService
    {
        public Task GetListAsync()=> Task.CompletedTask;

        [AllowAnonymous]
        public Task GetAsync() => Task.CompletedTask;

        [Authorize("BookStore_Author_Create")]
        public Task CreateAsync() => Task.CompletedTask;
    }
    public interface IAuthorAppService { }
}
/*
Authorize attribute forces the user to login into the application in order to use the AuthorAppService methods. So, GetListAsync method is only available to the authenticated users.
AllowAnonymous suppresses the authentication. So, GetAsync method is available to everyone including unauthorized users.
[Authorize("BookStore_Author_Create")] defines a policy (see policy based authorization) that is checked to authorize the current user.
*/
