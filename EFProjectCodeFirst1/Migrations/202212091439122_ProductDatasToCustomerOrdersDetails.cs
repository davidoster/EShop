namespace EFProjectCodeFirst1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductDatasToCustomerOrdersDetails : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProductDatas", newName: "CustomerOrdersDetails");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CustomerOrdersDetails", newName: "ProductDatas");
        }
    }
}
