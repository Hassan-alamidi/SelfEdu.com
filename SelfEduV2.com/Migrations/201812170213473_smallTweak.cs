namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smallTweak : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserComments", "UserId");
            DropColumn("dbo.CommentDTOes", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CommentDTOes", "UserId", c => c.String());
            AddColumn("dbo.UserComments", "UserId", c => c.String());
        }
    }
}
