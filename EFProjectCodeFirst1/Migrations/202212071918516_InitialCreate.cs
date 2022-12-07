namespace EFProjectCodeFirst1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerOrders",
                c => new
                    {
                        CustomerOrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        ProductQuantity = c.Int(nullable: false),
                        ProductPrice = c.Double(nullable: false),
                        Customer_Id = c.Int(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerOrderId)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.CustomerProducts", t => t.Product_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerProducts",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SomeTables",
                c => new
                    {
                        MyProperty = c.Int(nullable: false, identity: true),
                        MyDate = c.DateTime(),
                        MyBoolProperty = c.Boolean(),
                        MyStringProperty = c.String(),
                    })
                .PrimaryKey(t => t.MyProperty);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerOrders", "Product_Id", "dbo.CustomerProducts");
            DropForeignKey("dbo.CustomerProducts", "Id", "dbo.ProductCategories");
            DropForeignKey("dbo.CustomerOrders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.CustomerProducts", new[] { "Id" });
            DropIndex("dbo.CustomerOrders", new[] { "Product_Id" });
            DropIndex("dbo.CustomerOrders", new[] { "Customer_Id" });
            DropTable("dbo.SomeTables");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.CustomerProducts");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerOrders");
        }
    }
}
