namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChannelModelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Channel_Channel_id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Channel_Channel_id");
            AddForeignKey("dbo.AspNetUsers", "Channel_Channel_id", "dbo.Channels", "Channel_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Channel_Channel_id", "dbo.Channels");
            DropIndex("dbo.AspNetUsers", new[] { "Channel_Channel_id" });
            DropColumn("dbo.AspNetUsers", "Channel_Channel_id");
        }
    }
}
