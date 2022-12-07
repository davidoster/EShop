namespace EFProjectCodeFirst1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerOrders : DbMigration
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
                //.ForeignKey("dbo.CustomerProducts", t => t.Product_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Product_Id);
                
                AddForeignKey("dbo.CustomerOrders", "Product_Id", "dbo.Products", "Id", cascadeDelete: false);

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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerOrders", "Product_Id", "dbo.CustomerProducts");
            DropForeignKey("dbo.CustomerOrders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.CustomerOrders", new[] { "Product_Id" });
            DropIndex("dbo.CustomerOrders", new[] { "Customer_Id" });
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerOrders");
        }
    }
}
