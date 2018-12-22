namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeRequirements : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ratings", "User_id", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ratings", "User_id", c => c.String(nullable: false));
        }
    }
}
