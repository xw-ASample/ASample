using ASample.BookShop.Dal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASample.BookShop.Dal.Map
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            ToTable("Book");
            HasKey(e => e.Id);
            //Property(e => e.LoginId).IsRequired();
            //Property(e => e.RealName).IsRequired().HasMaxLength(10);
            //Property(e => e.Address).IsRequired().HasMaxLength(200);
            //Property(e => e.Phone).IsRequired().HasMaxLength(13);
            //Property(e => e.Brithday).IsRequired();

            //Property(e => e.CreateTime).IsRequired();
            //Property(e => e.DeleteTime).IsOptional();
            //Property(e => e.IsDeleted).IsRequired();
            //Property(e => e.ModifyTime).IsOptional();
        }
    }
}
