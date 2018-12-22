namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseFix2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "Channel_Channel_id", "dbo.Channels");
            DropIndex("dbo.Articles", new[] { "Channel_Channel_id" });
            DropColumn("dbo.Articles", "Channel_Channel_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "Channel_Channel_id", c => c.Int());
            CreateIndex("dbo.Articles", "Channel_Channel_id");
            AddForeignKey("dbo.Articles", "Channel_Channel_id", "dbo.Channels", "Channel_id");
        }
    }
}
