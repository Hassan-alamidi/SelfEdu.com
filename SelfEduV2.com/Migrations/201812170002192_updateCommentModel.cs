namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCommentModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserComments", "UserId", c => c.String());
            AlterColumn("dbo.CommentDTOes", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CommentDTOes", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.UserComments", "UserId", c => c.Int(nullable: false));
        }
    }
}
