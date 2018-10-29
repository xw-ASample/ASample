using ASample.Permission.Service.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;

namespace ASample.Permission.Service
{
    public class ASamplePermissionDbContext:DbContext
    {
        public ASamplePermissionDbContext() : base("name=ASamplePermissionDbContext")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Admin> Admin { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<Menu> Menu { get; set; }

        public DbSet<AdminRole> AdminRole { get; set; }

        public DbSet<RoleMenu> RoleMenu { get; set; }
    }
}