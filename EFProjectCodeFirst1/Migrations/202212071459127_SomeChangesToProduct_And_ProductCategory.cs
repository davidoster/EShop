namespace EFProjectCodeFirst1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeChangesToProduct_And_ProductCategory : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Products", newName: "CustomerProducts");
            //          [FK_dbo.Products_dbo.ProductCategories_Category_Id]
            DropForeignKey("dbo.CustomerProducts", "Category_Id", "dbo.ProductCategories");
            DropIndex("dbo.CustomerProducts", new[] { "Category_Id" });
            AlterColumn("dbo.CustomerProducts", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.CustomerProducts", "Category_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.CustomerProducts", "Category_Id");
            AddForeignKey("dbo.CustomerProducts", "Category_Id", "dbo.ProductCategories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerProducts", "Category_Id", "dbo.ProductCategories");
            DropIndex("dbo.CustomerProducts", new[] { "Category_Id" });
            AlterColumn("dbo.CustomerProducts", "Category_Id", c => c.Int());
            AlterColumn("dbo.CustomerProducts", "Title", c => c.String());
            CreateIndex("dbo.CustomerProducts", "Category_Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.ProductCategories", "Id");
            RenameTable(name: "dbo.CustomerProducts", newName: "Products");
        }
    }
}
