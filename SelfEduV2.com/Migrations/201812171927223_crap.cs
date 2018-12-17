namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class crap : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CommentDTOes", "Date", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CommentDTOes", "Date", c => c.DateTime(nullable: false));
        }
    }
}
