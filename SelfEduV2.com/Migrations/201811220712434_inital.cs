namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Article_id = c.Int(nullable: false, identity: true),
                        FilePath = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Keywords = c.String(),
                        ChannelId = c.Int(nullable: false),
                        Views = c.Int(nullable: false),
                        Channel_Channel_id = c.Int(),
                    })
                .PrimaryKey(t => t.Article_id)
                .ForeignKey("dbo.Channels", t => t.Channel_Channel_id)
                .Index(t => t.Channel_Channel_id);
            
            CreateTable(
                "dbo.UserComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        Rating = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        UserComments_Id = c.Int(),
                        Article_Article_id = c.Int(),
                        Video_Video_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserComments", t => t.UserComments_Id)
                .ForeignKey("dbo.Articles", t => t.Article_Article_id)
                .ForeignKey("dbo.Videos", t => t.Video_Video_id)
                .Index(t => t.UserComments_Id)
                .Index(t => t.Article_Article_id)
                .Index(t => t.Video_Video_id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Rating_id = c.Int(nullable: false, identity: true),
                        IsLike = c.Boolean(nullable: false),
                        Content_id = c.Int(nullable: false),
                        User_id = c.Int(nullable: false),
                        Article_Article_id = c.Int(),
                        Video_Video_id = c.Int(),
                    })
                .PrimaryKey(t => t.Rating_id)
                .ForeignKey("dbo.Articles", t => t.Article_Article_id)
                .ForeignKey("dbo.Videos", t => t.Video_Video_id)
                .Index(t => t.Article_Article_id)
                .Index(t => t.Video_Video_id);
            
            CreateTable(
                "dbo.Channels",
                c => new
                    {
                        Channel_id = c.Int(nullable: false, identity: true),
                        ChannelName = c.String(),
                        SubscriberCount = c.Int(nullable: false),
                        Keywords = c.String(),
                    })
                .PrimaryKey(t => t.Channel_id);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Video_id = c.Int(nullable: false, identity: true),
                        FilePath = c.String(),
                        Title = c.String(),
                        Description = c.String(),
                        Keywords = c.String(),
                        ChannelId = c.Int(nullable: false),
                        Views = c.Int(nullable: false),
                        Channel_Channel_id = c.Int(),
                    })
                .PrimaryKey(t => t.Video_id)
                .ForeignKey("dbo.Channels", t => t.Channel_Channel_id)
                .Index(t => t.Channel_Channel_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "Channel_Channel_id", "dbo.Channels");
            DropForeignKey("dbo.Ratings", "Video_Video_id", "dbo.Videos");
            DropForeignKey("dbo.UserComments", "Video_Video_id", "dbo.Videos");
            DropForeignKey("dbo.Articles", "Channel_Channel_id", "dbo.Channels");
            DropForeignKey("dbo.Ratings", "Article_Article_id", "dbo.Articles");
            DropForeignKey("dbo.UserComments", "Article_Article_id", "dbo.Articles");
            DropForeignKey("dbo.UserComments", "UserComments_Id", "dbo.UserComments");
            DropIndex("dbo.Videos", new[] { "Channel_Channel_id" });
            DropIndex("dbo.Ratings", new[] { "Video_Video_id" });
            DropIndex("dbo.Ratings", new[] { "Article_Article_id" });
            DropIndex("dbo.UserComments", new[] { "Video_Video_id" });
            DropIndex("dbo.UserComments", new[] { "Article_Article_id" });
            DropIndex("dbo.UserComments", new[] { "UserComments_Id" });
            DropIndex("dbo.Articles", new[] { "Channel_Channel_id" });
            DropTable("dbo.Videos");
            DropTable("dbo.Channels");
            DropTable("dbo.Ratings");
            DropTable("dbo.UserComments");
            DropTable("dbo.Articles");
        }
    }
}
