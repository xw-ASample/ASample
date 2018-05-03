using ASample.Crm.Model.AggregateRoots;
using System.Data.Entity.ModelConfiguration;

namespace ASample.Crm.IRepository.Map
{
    public class UserMap :  EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            HasKey(e => e.Id);
            Property(e => e.LoginName).IsRequired().HasMaxLength(30);
            Property(e => e.LoginPassword).IsRequired().HasMaxLength(16);
            Property(e => e.Address).IsRequired().HasMaxLength(200);
            Property(e => e.Phone).IsRequired().HasMaxLength(13);
            Property(e => e.Name).IsRequired().HasMaxLength(10);

            Property(e => e.Email).IsOptional().HasMaxLength(50);
            Property(e => e.UserLevelId).IsOptional();
        }
    }
}
