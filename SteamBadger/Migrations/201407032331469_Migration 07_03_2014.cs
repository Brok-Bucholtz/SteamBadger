namespace SteamBadger.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration07_03_2014 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Achievement", "globalPercentAchieved", c => c.Double(nullable: false));
            AddColumn("dbo.Achievement", "apiname", c => c.String());
            AddColumn("dbo.SteamApp", "img_icon_url", c => c.String());
            AddColumn("dbo.SteamApp", "img_logo_url", c => c.String());
            DropColumn("dbo.Achievement", "percentAchieved");
            DropColumn("dbo.Achievement", "image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Achievement", "image", c => c.String());
            AddColumn("dbo.Achievement", "percentAchieved", c => c.Double(nullable: false));
            DropColumn("dbo.SteamApp", "img_logo_url");
            DropColumn("dbo.SteamApp", "img_icon_url");
            DropColumn("dbo.Achievement", "apiname");
            DropColumn("dbo.Achievement", "globalPercentAchieved");
        }
    }
}
