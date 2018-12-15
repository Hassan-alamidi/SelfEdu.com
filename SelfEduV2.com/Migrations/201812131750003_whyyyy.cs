namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class whyyyy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Videos", "CreatorChannel_Channel_id", "dbo.Channels");
            DropIndex("dbo.Videos", new[] { "CreatorChannel_Channel_id" });
            //RenameColumn(table: "dbo.AspNetUsers", name: "Channel_Channel_id1", newName: "UserChannel_Channel_id");
            //RenameIndex(table: "dbo.AspNetUsers", name: "IX_Channel_Channel_id1", newName: "IX_UserChannel_Channel_id");
            AlterColumn("dbo.Videos", "CreatorChannel_Channel_id", c => c.Int());
            CreateIndex("dbo.Videos", "CreatorChannel_Channel_id");
            AddForeignKey("dbo.Videos", "CreatorChannel_Channel_id", "dbo.Channels", "Channel_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "CreatorChannel_Channel_id", "dbo.Channels");
            DropIndex("dbo.Videos", new[] { "CreatorChannel_Channel_id" });
            AlterColumn("dbo.Videos", "CreatorChannel_Channel_id", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_UserChannel_Channel_id", newName: "IX_Channel_Channel_id1");
            RenameColumn(table: "dbo.AspNetUsers", name: "UserChannel_Channel_id", newName: "Channel_Channel_id1");
            CreateIndex("dbo.Videos", "CreatorChannel_Channel_id");
            AddForeignKey("dbo.Videos", "CreatorChannel_Channel_id", "dbo.Channels", "Channel_id", cascadeDelete: true);
        }
    }
}
