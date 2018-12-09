namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hopefullChannelFix2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ApplicationUserChannels", newName: "ChannelApplicationUsers");
            DropPrimaryKey("dbo.ChannelApplicationUsers");
            AddColumn("dbo.UserComments", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.ChannelApplicationUsers", new[] { "Channel_Channel_id", "ApplicationUser_Id" });
            CreateIndex("dbo.UserComments", "ApplicationUser_Id");
            AddForeignKey("dbo.UserComments", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserComments", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserComments", new[] { "ApplicationUser_Id" });
            DropPrimaryKey("dbo.ChannelApplicationUsers");
            DropColumn("dbo.UserComments", "ApplicationUser_Id");
            AddPrimaryKey("dbo.ChannelApplicationUsers", new[] { "ApplicationUser_Id", "Channel_Channel_id" });
            RenameTable(name: "dbo.ChannelApplicationUsers", newName: "ApplicationUserChannels");
        }
    }
}
