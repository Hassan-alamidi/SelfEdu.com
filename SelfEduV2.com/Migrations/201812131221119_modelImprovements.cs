namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelImprovements : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Videos", "Channel_Channel_id", "dbo.Channels");
            DropIndex("dbo.Videos", new[] { "Channel_Channel_id" });
            RenameColumn(table: "dbo.Videos", name: "Channel_Channel_id", newName: "CreatorChannel_Channel_id");
            AddColumn("dbo.AspNetUsers", "Channel_Channel_id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Channel_Channel_id1", c => c.Int());
            AlterColumn("dbo.Videos", "CreatorChannel_Channel_id", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "Channel_Channel_id");
            CreateIndex("dbo.AspNetUsers", "Channel_Channel_id1");
            CreateIndex("dbo.Videos", "CreatorChannel_Channel_id");
            AddForeignKey("dbo.AspNetUsers", "Channel_Channel_id", "dbo.Channels", "Channel_id");
            AddForeignKey("dbo.AspNetUsers", "Channel_Channel_id1", "dbo.Channels", "Channel_id");
            AddForeignKey("dbo.Videos", "CreatorChannel_Channel_id", "dbo.Channels", "Channel_id", cascadeDelete: true);
            DropColumn("dbo.AspNetUsers", "ChannelId");
            DropColumn("dbo.Videos", "ChannelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Videos", "ChannelId", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "ChannelId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Videos", "CreatorChannel_Channel_id", "dbo.Channels");
            DropForeignKey("dbo.AspNetUsers", "Channel_Channel_id1", "dbo.Channels");
            DropForeignKey("dbo.AspNetUsers", "Channel_Channel_id", "dbo.Channels");
            DropIndex("dbo.Videos", new[] { "CreatorChannel_Channel_id" });
            DropIndex("dbo.AspNetUsers", new[] { "Channel_Channel_id1" });
            DropIndex("dbo.AspNetUsers", new[] { "Channel_Channel_id" });
            AlterColumn("dbo.Videos", "CreatorChannel_Channel_id", c => c.Int());
            DropColumn("dbo.AspNetUsers", "Channel_Channel_id1");
            DropColumn("dbo.AspNetUsers", "Channel_Channel_id");
            RenameColumn(table: "dbo.Videos", name: "CreatorChannel_Channel_id", newName: "Channel_Channel_id");
            CreateIndex("dbo.Videos", "Channel_Channel_id");
            AddForeignKey("dbo.Videos", "Channel_Channel_id", "dbo.Channels", "Channel_id");
        }
    }
}
