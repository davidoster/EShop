namespace EFProjectCodeFirst1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToProduct1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CustomerProducts", "Id", c => c.Int(nullable: false, identity: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerProducts", "Id", c => c.Int(nullable: false));
        }
    }
}
