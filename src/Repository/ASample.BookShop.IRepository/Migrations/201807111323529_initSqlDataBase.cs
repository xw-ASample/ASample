namespace ASample.BookShop.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initSqlDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Author = c.String(),
                        PublisherId = c.Guid(nullable: false),
                        PublishDate = c.DateTime(nullable: false),
                        ISBN = c.String(),
                        WordsCount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ContentDescription = c.String(),
                        AurhorDescription = c.String(),
                        EditorComment = c.String(),
                        TOC = c.String(),
                        CategoryId = c.Guid(nullable: false),
                        Clicks = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleteTime = c.DateTime(),
                        CreateTime = c.DateTime(nullable: false),
                        ModifyTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoginName = c.String(nullable: false, maxLength: 10),
                        LoginPassword = c.String(nullable: false, maxLength: 16),
                        RealName = c.String(maxLength: 6),
                        Address = c.String(maxLength: 200),
                        Phone = c.String(nullable: false, maxLength: 13),
                        Email = c.String(),
                        UserLevelId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleteTime = c.DateTime(),
                        CreateTime = c.DateTime(nullable: false),
                        ModifyTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.Book");
        }
    }
}
