namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUniqueFromPaths : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Videos", new[] { "FilePath" });
            DropIndex("dbo.Videos", new[] { "ThumbnailPath" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Videos", "ThumbnailPath", unique: true);
            CreateIndex("dbo.Videos", "FilePath", unique: true);
        }
    }
}
