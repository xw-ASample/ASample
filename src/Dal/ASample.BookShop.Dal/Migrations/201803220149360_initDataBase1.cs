namespace ASample.BookShop.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDataBase1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "Name", c => c.String());
            AddColumn("dbo.Book", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "Price");
            DropColumn("dbo.Book", "Name");
        }
    }
}
