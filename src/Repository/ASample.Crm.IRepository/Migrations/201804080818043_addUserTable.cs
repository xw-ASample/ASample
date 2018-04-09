namespace ASample.Crm.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LoginName = c.String(nullable: false, maxLength: 30),
                        LoginPassword = c.String(nullable: false, maxLength: 16),
                        Name = c.String(nullable: false, maxLength: 10),
                        Address = c.String(nullable: false, maxLength: 200),
                        Phone = c.String(nullable: false, maxLength: 13),
                        Email = c.String(maxLength: 50),
                        UserLevelId = c.Guid(),
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
        }
    }
}
