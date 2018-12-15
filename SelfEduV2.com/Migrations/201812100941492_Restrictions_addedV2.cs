namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restrictions_addedV2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Videos", new[] { "FilePath" });
            DropIndex("dbo.Videos", new[] { "ThumbnailPath" });
            AlterColumn("dbo.Videos", "FilePath", c => c.String(nullable: false, maxLength: 850));
            AlterColumn("dbo.Videos", "ThumbnailPath", c => c.String(nullable: false, maxLength: 850));
            CreateIndex("dbo.Videos", "FilePath", unique: true);
            CreateIndex("dbo.Videos", "ThumbnailPath", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Videos", new[] { "ThumbnailPath" });
            DropIndex("dbo.Videos", new[] { "FilePath" });
            AlterColumn("dbo.Videos", "ThumbnailPath", c => c.String(nullable: false, maxLength: 900));
            AlterColumn("dbo.Videos", "FilePath", c => c.String(nullable: false, maxLength: 900));
            CreateIndex("dbo.Videos", "ThumbnailPath", unique: true);
            CreateIndex("dbo.Videos", "FilePath", unique: true);
        }
    }
}
