namespace DataWarehouse.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbV2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CityName = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        IdUser = c.Long(nullable: false),
                        IdCityFrom = c.Long(nullable: false),
                        IdCityTo = c.Long(nullable: false),
                        Price = c.Single(nullable: false),
                        FromPlace = c.String(maxLength: 255),
                        StartTime = c.DateTime(nullable: false),
                        MinutesToDest = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.IdCityFrom)
                .ForeignKey("dbo.Cities", t => t.IdCityTo)
                .ForeignKey("dbo.Users", t => t.IdUser)
                .Index(t => t.IdUser)
                .Index(t => t.IdCityFrom)
                .Index(t => t.IdCityTo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trips", "IdUser", "dbo.Users");
            DropForeignKey("dbo.Trips", "IdCityTo", "dbo.Cities");
            DropForeignKey("dbo.Trips", "IdCityFrom", "dbo.Cities");
            DropIndex("dbo.Trips", new[] { "IdCityTo" });
            DropIndex("dbo.Trips", new[] { "IdCityFrom" });
            DropIndex("dbo.Trips", new[] { "IdUser" });
            DropTable("dbo.Trips");
            DropTable("dbo.Cities");
        }
    }
}
