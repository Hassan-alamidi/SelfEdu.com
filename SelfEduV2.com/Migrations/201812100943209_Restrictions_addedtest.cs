namespace SelfEduV2.com.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Restrictions_addedtest : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Videos", new[] { "FilePath" });
            AlterColumn("dbo.Videos", "FilePath", c => c.String(nullable: false, maxLength: 900));
            CreateIndex("dbo.Videos", "FilePath", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Videos", new[] { "FilePath" });
            AlterColumn("dbo.Videos", "FilePath", c => c.String(nullable: false, maxLength: 850));
            CreateIndex("dbo.Videos", "FilePath", unique: true);
        }
    }
}
