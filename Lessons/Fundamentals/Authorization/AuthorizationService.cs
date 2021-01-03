using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Authorization
{
    public class SomeClass
    {
        //AuthorizationService is available as a property when you derive from ABP's ApplicationService base class. Since it is widely used in application services, ApplicationService pre-injects it for you. Otherwise, you can directly inject it into your class.
        IAuthorizationService _authorizationService;
        public SomeClass(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }
        public async Task CreateAsync()
        {
            var result = await _authorizationService.AuthorizeAsync("Author_Management_Create_Books");
            if (result.Succeeded == false)
            {
                //throw exception
                throw new SecurityException("...");
            }

            //continue to the normal flow...
        }
        public void Create()
        {
            //Since it is widely used in application services, ApplicationService pre-injects it for you
            //await AuthorizationService.CheckAsync("Author_Management_Create_Books");
            //CheckAsync extension method throws AbpAuthorizationException if the current user/client is not granted for the given permission. There is also IsGrantedAsync extension method that returns true or false
        }
    }
}
