namespace DataWarehouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeUser2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Login", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Users", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Users", "Login");
        }
    }
}
