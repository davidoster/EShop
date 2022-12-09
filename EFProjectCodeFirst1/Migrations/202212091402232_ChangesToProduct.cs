namespace EFProjectCodeFirst1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToProduct : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerProducts", "Id", "dbo.ProductCategories");
            DropForeignKey("dbo.CustomerOrders", "Product_Id", "dbo.CustomerProducts");
            DropForeignKey("dbo.ProductDatas", "Product_Id", "dbo.CustomerProducts");
            DropIndex("dbo.CustomerProducts", new[] { "Id" });
            DropPrimaryKey("dbo.CustomerProducts");
            AddColumn("dbo.CustomerProducts", "Category_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerProducts", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CustomerProducts", "Id");
            CreateIndex("dbo.CustomerProducts", "Category_Id");
            AddForeignKey("dbo.CustomerProducts", "Category_Id", "dbo.ProductCategories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CustomerOrders", "Product_Id", "dbo.CustomerProducts", "Id");
            AddForeignKey("dbo.ProductDatas", "Product_Id", "dbo.CustomerProducts", "Id");
            //DropColumn("dbo.CustomerProducts", "ProductCategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerProducts", "ProductCategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProductDatas", "Product_Id", "dbo.CustomerProducts");
            DropForeignKey("dbo.CustomerOrders", "Product_Id", "dbo.CustomerProducts");
            DropForeignKey("dbo.CustomerProducts", "Category_Id", "dbo.ProductCategories");
            DropIndex("dbo.CustomerProducts", new[] { "Category_Id" });
            DropPrimaryKey("dbo.CustomerProducts");
            AlterColumn("dbo.CustomerProducts", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.CustomerProducts", "Category_Id");
            AddPrimaryKey("dbo.CustomerProducts", "Id");
            CreateIndex("dbo.CustomerProducts", "Id");
            AddForeignKey("dbo.ProductDatas", "Product_Id", "dbo.CustomerProducts", "Id");
            AddForeignKey("dbo.CustomerOrders", "Product_Id", "dbo.CustomerProducts", "Id");
            AddForeignKey("dbo.CustomerProducts", "Id", "dbo.ProductCategories", "Id");
        }
    }
}
