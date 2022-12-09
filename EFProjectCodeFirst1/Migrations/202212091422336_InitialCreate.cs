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
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.Category_Id, cascadeDelete: true)
                .Index(t => t.Category_Id);
            
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
                "dbo.CustomerOrdersMultipleProducts",
                c => new
                    {
                        CustomerOrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerOrderId)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "dbo.ProductDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Product_Id = c.Int(),
                        OrderMultiple_CustomerOrderId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerProducts", t => t.Product_Id)
                .ForeignKey("dbo.CustomerOrdersMultipleProducts", t => t.OrderMultiple_CustomerOrderId)
                .Index(t => t.Product_Id)
                .Index(t => t.OrderMultiple_CustomerOrderId);
            
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
            DropForeignKey("dbo.ProductDatas", "OrderMultiple_CustomerOrderId", "dbo.CustomerOrdersMultipleProducts");
            DropForeignKey("dbo.ProductDatas", "Product_Id", "dbo.CustomerProducts");
            DropForeignKey("dbo.CustomerOrdersMultipleProducts", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.CustomerOrders", "Product_Id", "dbo.CustomerProducts");
            DropForeignKey("dbo.CustomerProducts", "Category_Id", "dbo.ProductCategories");
            DropForeignKey("dbo.CustomerOrders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.ProductDatas", new[] { "OrderMultiple_CustomerOrderId" });
            DropIndex("dbo.ProductDatas", new[] { "Product_Id" });
            DropIndex("dbo.CustomerOrdersMultipleProducts", new[] { "Customer_Id" });
            DropIndex("dbo.CustomerProducts", new[] { "Category_Id" });
            DropIndex("dbo.CustomerOrders", new[] { "Product_Id" });
            DropIndex("dbo.CustomerOrders", new[] { "Customer_Id" });
            DropTable("dbo.SomeTables");
            DropTable("dbo.ProductDatas");
            DropTable("dbo.CustomerOrdersMultipleProducts");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.CustomerProducts");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerOrders");
        }
    }
}
