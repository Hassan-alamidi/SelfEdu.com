namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hopefullChannelFix4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChannelApplicationUsers", "Channel_Channel_id", "dbo.Channels");
            DropForeignKey("dbo.ChannelApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ChannelApplicationUsers", new[] { "Channel_Channel_id" });
            DropIndex("dbo.ChannelApplicationUsers", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.Channels", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Channels", "ApplicationUser_Id");
            AddForeignKey("dbo.Channels", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropTable("dbo.ChannelApplicationUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ChannelApplicationUsers",
                c => new
                    {
                        Channel_Channel_id = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Channel_Channel_id, t.ApplicationUser_Id });
            
            DropForeignKey("dbo.Channels", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Channels", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Channels", "ApplicationUser_Id");
            CreateIndex("dbo.ChannelApplicationUsers", "ApplicationUser_Id");
            CreateIndex("dbo.ChannelApplicationUsers", "Channel_Channel_id");
            AddForeignKey("dbo.ChannelApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ChannelApplicationUsers", "Channel_Channel_id", "dbo.Channels", "Channel_id", cascadeDelete: true);
        }
    }
}
