namespace ASample.BookShop.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDatabase : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Book", "Title", c => c.String());
            AddColumn("dbo.Book", "Author", c => c.String());
            AddColumn("dbo.Book", "PublisherId", c => c.Guid(nullable: false));
            AddColumn("dbo.Book", "PublishDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Book", "ISBN", c => c.String());
            AddColumn("dbo.Book", "WordsCount", c => c.Int(nullable: false));
            AddColumn("dbo.Book", "ContentDescription", c => c.String());
            AddColumn("dbo.Book", "AurhorDescription", c => c.String());
            AddColumn("dbo.Book", "EditorComment", c => c.String());
            AddColumn("dbo.Book", "TOC", c => c.String());
            AddColumn("dbo.Book", "CategoryId", c => c.Guid(nullable: false));
            AddColumn("dbo.Book", "Clicks", c => c.Int(nullable: false));
            AlterColumn("dbo.Book", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Book", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Book", "Name", c => c.String());
            AlterColumn("dbo.Book", "Price", c => c.Int(nullable: false));
            DropColumn("dbo.Book", "Clicks");
            DropColumn("dbo.Book", "CategoryId");
            DropColumn("dbo.Book", "TOC");
            DropColumn("dbo.Book", "EditorComment");
            DropColumn("dbo.Book", "AurhorDescription");
            DropColumn("dbo.Book", "ContentDescription");
            DropColumn("dbo.Book", "WordsCount");
            DropColumn("dbo.Book", "ISBN");
            DropColumn("dbo.Book", "PublishDate");
            DropColumn("dbo.Book", "PublisherId");
            DropColumn("dbo.Book", "Author");
            DropColumn("dbo.Book", "Title");
            DropTable("dbo.User");
        }
    }
}
