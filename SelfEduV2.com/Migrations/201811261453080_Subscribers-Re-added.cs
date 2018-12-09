namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubscribersReadded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Channels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Channels", new[] { "ApplicationUser_Id" });
            CreateTable(
                "dbo.ChannelApplicationUsers",
                c => new
                    {
                        Channel_Channel_id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Channel_Channel_id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Channels", t => t.Channel_Channel_id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Channel_Channel_id)
                .Index(t => t.ApplicationUser_Id);
            
            DropColumn("dbo.Channels", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Channels", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.ChannelApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ChannelApplicationUsers", "Channel_Channel_id", "dbo.Channels");
            DropIndex("dbo.ChannelApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ChannelApplicationUsers", new[] { "Channel_Channel_id" });
            DropTable("dbo.ChannelApplicationUsers");
            CreateIndex("dbo.Channels", "ApplicationUser_Id");
            AddForeignKey("dbo.Channels", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
