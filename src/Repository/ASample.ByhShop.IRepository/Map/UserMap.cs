using ASample.ByhShop.Model.AggregateRoots;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.ByhShop.IRepository.Map
{
    public class UserMap: EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            HasKey(e => e.Id);
            Property(e => e.Name).IsRequired().HasMaxLength(10);
            Property(e => e.Password).IsRequired().HasMaxLength(16);
            Property(e => e.Email).IsOptional().HasMaxLength(6);
            Property(e => e.AddressId).IsOptional();
            Property(e => e.Contact).IsOptional().HasMaxLength(200);
            Property(e => e.Phone).IsRequired().HasMaxLength(13);
            Property(e => e.LastLogonDate).IsOptional();
            Property(e => e.IsDisabled).IsRequired(); 

            Property(e => e.CreateTime).IsRequired();
            Property(e => e.DeleteTime).IsOptional();
            Property(e => e.IsDeleted).IsRequired();
            Property(e => e.ModifyTime).IsOptional();
        }
    }
}
