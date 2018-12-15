namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOverAllRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "OverAllRating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "OverAllRating");
        }
    }
}
