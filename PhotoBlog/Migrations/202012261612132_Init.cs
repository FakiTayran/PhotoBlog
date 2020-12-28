namespace PhotoBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Head = c.String(),
                        Path = c.String(nullable: false),
                        Description = c.String(),
                        DateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagPhotoes",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Photo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Photo_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Photos", t => t.Photo_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Photo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagPhotoes", "Photo_Id", "dbo.Photos");
            DropForeignKey("dbo.TagPhotoes", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TagPhotoes", new[] { "Photo_Id" });
            DropIndex("dbo.TagPhotoes", new[] { "Tag_Id" });
            DropTable("dbo.TagPhotoes");
            DropTable("dbo.Tags");
            DropTable("dbo.Photos");
        }
    }
}
