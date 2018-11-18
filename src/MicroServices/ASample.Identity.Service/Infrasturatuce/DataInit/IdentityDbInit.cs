using ASample.Identity.Service.Infrasturatuce.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASample.Identity.Service.Infrasturatuce.DataInit
{
    public class IdentityDbInit : DropCreateDatabaseAlways<IdentityContext>
    {
        protected override void Seed(IdentityContext context)
        {
            this.InitAdmin(context);
            base.Seed(context);
        }

        public void InitAdmin(IdentityContext context)
        {
            string adminName = "admin";
            string adminPassword = "admin123";
            string adminRoleName = "Administrators";

            // 创建用户  
            UserManager<AppUser> userManager = new UserManager<AppUser>(
                new UserStore<AppUser>(context));
            var user = new AppUser { UserName = adminName };
            userManager.Create(user, adminPassword);

            // 创建角色  
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
            var adminRole = roleManager.Create(new IdentityRole(adminRoleName));

            // 给用户赋予角色  
            userManager.AddToRole(user.Id, adminRoleName);
        }
    }  
}