namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notsure : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CommentDTOes", "Video_id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CommentDTOes", "Video_id");
        }
    }
}
