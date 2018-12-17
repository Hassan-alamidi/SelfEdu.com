namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserComments", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserComments", "Date");
        }
    }
}
