using ASample.BookShop.Model.AggregateRoots;
using System.Data.Entity.ModelConfiguration;

namespace ASample.BookShop.IRepository.Map
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            HasKey(e => e.Id);
            Property(e => e.LoginName).IsRequired().HasMaxLength(10);
            Property(e => e.LoginPassword).IsRequired().HasMaxLength(16);
            Property(e => e.RealName).IsOptional().HasMaxLength(6);
            Property(e => e.Address).IsOptional().HasMaxLength(200);
            Property(e => e.Phone).IsRequired().HasMaxLength(13);

            Property(e => e.CreateTime).IsRequired();
            Property(e => e.DeleteTime).IsOptional();
            Property(e => e.IsDeleted).IsRequired();
            Property(e => e.ModifyTime).IsOptional();
        }

    }
}
