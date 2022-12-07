namespace EFProjectCodeFirst1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertSomeChangesToProduct_And_ProductCategory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerProducts", "Category_Id", "dbo.ProductCategories");
            DropIndex("dbo.CustomerProducts", new[] { "Category_Id" });
            AlterColumn("dbo.CustomerProducts", "Category_Id", c => c.Int());
            AlterColumn("dbo.CustomerProducts", "Title", c => c.String());
            CreateIndex("dbo.CustomerProducts", "Category_Id");
            RenameTable(name: "dbo.CustomerProducts", newName: "Products");
            //AddForeignKey("dbo.Products", "Category_Id", "dbo.ProductCategories", "Id");
        }
        
        public override void Down()
        {
        }
    }
}
