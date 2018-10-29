namespace ASample.Permission.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initPermission : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleteTime = c.DateTime(),
                        CreateTime = c.DateTime(nullable: false),
                        ModifyTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdminRole",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AdminId = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.Int(nullable: false),
                        Name = c.String(),
                        Url = c.String(),
                        Sort = c.Int(nullable: false),
                        ParentCode = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleteTime = c.DateTime(),
                        CreateTime = c.DateTime(nullable: false),
                        ModifyTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleteTime = c.DateTime(),
                        CreateTime = c.DateTime(nullable: false),
                        ModifyTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleMenu",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        MenuId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RoleMenu");
            DropTable("dbo.Role");
            DropTable("dbo.Menu");
            DropTable("dbo.AdminRole");
            DropTable("dbo.Admin");
        }
    }
}
