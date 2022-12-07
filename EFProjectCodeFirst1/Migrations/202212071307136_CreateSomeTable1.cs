namespace EFProjectCodeFirst1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateSomeTable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SomeTables", "MyDate", c => c.DateTime());
            AlterColumn("dbo.SomeTables", "MyBoolProperty", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SomeTables", "MyBoolProperty", c => c.Boolean(nullable: false));
            AlterColumn("dbo.SomeTables", "MyDate", c => c.DateTime(nullable: false));
        }
    }
}
