namespace ASample.BookShopMySql.IRepository.Migrations
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
                        Title = c.String(unicode: false),
                        Author = c.String(unicode: false),
                        PublisherId = c.Guid(nullable: false),
                        PublishDate = c.DateTime(nullable: false, precision: 0),
                        ISBN = c.String(unicode: false),
                        WordsCount = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ContentDescription = c.String(unicode: false),
                        AurhorDescription = c.String(unicode: false),
                        EditorComment = c.String(unicode: false),
                        TOC = c.String(unicode: false),
                        CategoryId = c.Guid(nullable: false),
                        Clicks = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleteTime = c.DateTime(precision: 0),
                        CreateTime = c.DateTime(nullable: false, precision: 0),
                        ModifyTime = c.DateTime(precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Book");
        }
    }
}
