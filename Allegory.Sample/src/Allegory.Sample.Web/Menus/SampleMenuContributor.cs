using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Allegory.Sample.Localization;
using Allegory.Sample.MultiTenancy;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Allegory.Sample.Web.Menus
{
    public class SampleMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }
        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            if (!MultiTenancyConsts.IsEnabled)
            {
                var administration = context.Menu.GetAdministration();
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            var l = context.GetLocalizer<SampleResource>();

            context.Menu.Items.Insert(0, new ApplicationMenuItem(SampleMenus.Home, l["Menu:Home"], "~/"));

            var sampleMenu = new ApplicationMenuItem(
                                    "Sample",
                                    l["Menu:Sample"],
                                    icon: "fas fa-sitemap"
                                );

            context.Menu.AddItem(sampleMenu);

            
            //if (await context.IsGrantedAsync(BookStorePermissions.Authors.Default))=>product domain
            //{
            //    bookStoreMenu.AddItem(new ApplicationMenuItem(
            //        "BooksStore.Authors",
            //        l["Menu:Authors"],
            //        url: "/Authors"
            //    ));
            //}
        }
    }
}
