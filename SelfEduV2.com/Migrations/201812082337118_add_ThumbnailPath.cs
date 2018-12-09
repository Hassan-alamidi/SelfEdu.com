namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_ThumbnailPath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "ThumbnailPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "ThumbnailPath");
        }
    }
}
