namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class misteriousUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentDTOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        Rating = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CommentDTO_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CommentDTOes", t => t.CommentDTO_Id)
                .Index(t => t.CommentDTO_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommentDTOes", "CommentDTO_Id", "dbo.CommentDTOes");
            DropIndex("dbo.CommentDTOes", new[] { "CommentDTO_Id" });
            DropTable("dbo.CommentDTOes");
        }
    }
}
