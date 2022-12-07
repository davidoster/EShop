namespace EFProjectCodeFirst1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSomeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SomeTables",
                c => new
                    {
                        MyProperty = c.Int(nullable: false, identity: true),
                        MyDate = c.DateTime(nullable: false),
                        MyBoolProperty = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MyProperty);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SomeTables");
        }
    }
}
