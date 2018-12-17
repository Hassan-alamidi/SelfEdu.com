namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notsure1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CommentDTOes", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CommentDTOes", "Date");
        }
    }
}
