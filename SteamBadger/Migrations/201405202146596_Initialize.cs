namespace SteamBadger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achievement",
                c => new
                    {
                        name = c.String(nullable: false, maxLength: 128),
                        percentAchieved = c.Double(nullable: false),
                        description = c.String(),
                        image = c.String(),
                        SteamApp_dbID = c.Int(),
                    })
                .PrimaryKey(t => t.name)
                .ForeignKey("dbo.SteamApp", t => t.SteamApp_dbID)
                .Index(t => t.SteamApp_dbID);
            
            CreateTable(
                "dbo.SteamApp",
                c => new
                    {
                        dbID = c.Int(nullable: false, identity: true),
                        valveID = c.Int(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.dbID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Achievement", "SteamApp_dbID", "dbo.SteamApp");
            DropIndex("dbo.Achievement", new[] { "SteamApp_dbID" });
            DropTable("dbo.SteamApp");
            DropTable("dbo.Achievement");
        }
    }
}
