namespace AppName.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStandardProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Categories", "CreatedUser", c => c.String());
            AddColumn("dbo.Categories", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Categories", "UpdatedUser", c => c.String());
            AddColumn("dbo.Categories", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "CreatedUser", c => c.String());
            AddColumn("dbo.Products", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "UpdatedUser", c => c.String());
            AddColumn("dbo.Products", "UpdatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "UpdatedDate");
            DropColumn("dbo.Products", "UpdatedUser");
            DropColumn("dbo.Products", "CreatedDate");
            DropColumn("dbo.Products", "CreatedUser");
            DropColumn("dbo.Products", "IsActive");
            DropColumn("dbo.Categories", "UpdatedDate");
            DropColumn("dbo.Categories", "UpdatedUser");
            DropColumn("dbo.Categories", "CreatedDate");
            DropColumn("dbo.Categories", "CreatedUser");
            DropColumn("dbo.Categories", "IsActive");
        }
    }
}
