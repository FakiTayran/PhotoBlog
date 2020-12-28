namespace PhotoBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoPathRequiredNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Photos", "Path", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Photos", "Path", c => c.String(nullable: false));
        }
    }
}
