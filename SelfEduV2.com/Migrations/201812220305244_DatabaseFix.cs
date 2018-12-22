namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CommentDTOes", "CommentDTO_Id", "dbo.CommentDTOes");
            DropIndex("dbo.CommentDTOes", new[] { "CommentDTO_Id" });
            DropTable("dbo.CommentDTOes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CommentDTOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        Rating = c.Int(nullable: false),
                        Date = c.String(),
                        UserName = c.String(),
                        Video_id = c.Int(nullable: false),
                        CommentDTO_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.CommentDTOes", "CommentDTO_Id");
            AddForeignKey("dbo.CommentDTOes", "CommentDTO_Id", "dbo.CommentDTOes", "Id");
        }
    }
}
