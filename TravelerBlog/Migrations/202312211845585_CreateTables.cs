namespace TravelerBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogCityRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BlogPostId = c.Int(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogPosts", t => t.BlogPostId, cascadeDelete: true)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.BlogPostId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        BlogCreatedDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        UserCreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogCityRelations", "CityId", "dbo.Cities");
            DropForeignKey("dbo.BlogPosts", "UserId", "dbo.Users");
            DropForeignKey("dbo.BlogCityRelations", "BlogPostId", "dbo.BlogPosts");
            DropIndex("dbo.BlogPosts", new[] { "UserId" });
            DropIndex("dbo.BlogCityRelations", new[] { "CityId" });
            DropIndex("dbo.BlogCityRelations", new[] { "BlogPostId" });
            DropTable("dbo.Cities");
            DropTable("dbo.Users");
            DropTable("dbo.BlogPosts");
            DropTable("dbo.BlogCityRelations");
        }
    }
}
