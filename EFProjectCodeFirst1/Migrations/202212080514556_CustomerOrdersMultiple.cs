namespace EFProjectCodeFirst1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerOrdersMultiple : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductDatas", "OrderMultiple_CustomerOrderId", "dbo.CustomerOrdersMultipleProducts");
            DropForeignKey("dbo.ProductDatas", "Product_Id", "dbo.CustomerProducts");
            DropForeignKey("dbo.CustomerOrdersMultipleProducts", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.ProductDatas", new[] { "OrderMultiple_CustomerOrderId" });
            DropIndex("dbo.ProductDatas", new[] { "Product_Id" });
            DropIndex("dbo.CustomerOrdersMultipleProducts", new[] { "Customer_Id" });
            DropTable("dbo.ProductDatas");
            DropTable("dbo.CustomerOrdersMultipleProducts");
        }
    }
}
