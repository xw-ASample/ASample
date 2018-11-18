using ASample.Identity.Service.Infrasturatuce.DataInit;
using ASample.Identity.Service.Infrasturatuce.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASample.Identity.Service.Infrasturatuce
{
    public class IdentityContext : IdentityDbContext<IdentityUser>
    {
        public IdentityContext() : base("IdentityDataBase")
        {

        }
        public IdentityContext(string connectionString)
        : base(connectionString)
        {
        }  
        static IdentityContext()
        {
            Database.SetInitializer<IdentityContext>(new IdentityDbInit());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>().ToTable("User");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
        }  
    }
}