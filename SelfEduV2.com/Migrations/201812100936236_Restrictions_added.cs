namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restrictions_added : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Channels", "ChannelName", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Videos", "FilePath", c => c.String(nullable: false, maxLength: 900));
            AlterColumn("dbo.Videos", "ThumbnailPath", c => c.String(nullable: false, maxLength: 900));
            AlterColumn("dbo.Videos", "Title", c => c.String(nullable: false, maxLength: 130));
            CreateIndex("dbo.Channels", "ChannelName", unique: true);
            CreateIndex("dbo.Videos", "FilePath", unique: true);
            CreateIndex("dbo.Videos", "ThumbnailPath", unique: true);
            CreateIndex("dbo.Videos", "Title", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Videos", new[] { "Title" });
            DropIndex("dbo.Videos", new[] { "ThumbnailPath" });
            DropIndex("dbo.Videos", new[] { "FilePath" });
            DropIndex("dbo.Channels", new[] { "ChannelName" });
            AlterColumn("dbo.Videos", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Videos", "ThumbnailPath", c => c.String());
            AlterColumn("dbo.Videos", "FilePath", c => c.String());
            AlterColumn("dbo.Channels", "ChannelName", c => c.String(nullable: false));
        }
    }
}
