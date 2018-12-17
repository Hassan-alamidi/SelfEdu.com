namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usernametoComment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserComments", "UserName", c => c.String());
            AddColumn("dbo.CommentDTOes", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CommentDTOes", "UserName");
            DropColumn("dbo.UserComments", "UserName");
        }
    }
}
