namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userUpdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ChannelApplicationUsers", newName: "ApplicationUserChannels");
            DropPrimaryKey("dbo.ApplicationUserChannels");
            AddPrimaryKey("dbo.ApplicationUserChannels", new[] { "ApplicationUser_Id", "Channel_Channel_id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ApplicationUserChannels");
            AddPrimaryKey("dbo.ApplicationUserChannels", new[] { "Channel_Channel_id", "ApplicationUser_Id" });
            RenameTable(name: "dbo.ApplicationUserChannels", newName: "ChannelApplicationUsers");
        }
    }
}
