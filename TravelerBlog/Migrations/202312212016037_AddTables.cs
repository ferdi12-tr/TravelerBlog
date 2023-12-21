namespace TravelerBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlogPosts", "UserId", "dbo.Users");
            DropIndex("dbo.BlogPosts", new[] { "UserId" });
            CreateTable(
                "dbo.BlogLikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BlogPostId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogPosts", t => t.BlogPostId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.BlogPostId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CommentPostRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        BlogPostId = c.Int(nullable: false),
                        BlogCommentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogComments", t => t.BlogCommentId, cascadeDelete: true)
                .ForeignKey("dbo.BlogPosts", t => t.BlogPostId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BlogPostId)
                .Index(t => t.BlogCommentId);
            
            CreateTable(
                "dbo.BlogComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BlogCommentDate = c.DateTime(nullable: false),
                        Comment = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "Role_Id", c => c.Int());
            CreateIndex("dbo.Users", "Role_Id");
            AddForeignKey("dbo.Users", "Role_Id", "dbo.Roles", "Id");
            DropColumn("dbo.BlogPosts", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BlogPosts", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Users", "Role_Id", "dbo.Roles");
            DropForeignKey("dbo.CommentPostRelations", "UserId", "dbo.Users");
            DropForeignKey("dbo.CommentPostRelations", "BlogPostId", "dbo.BlogPosts");
            DropForeignKey("dbo.CommentPostRelations", "BlogCommentId", "dbo.BlogComments");
            DropForeignKey("dbo.BlogLikes", "UserId", "dbo.Users");
            DropForeignKey("dbo.BlogLikes", "BlogPostId", "dbo.BlogPosts");
            DropIndex("dbo.CommentPostRelations", new[] { "BlogCommentId" });
            DropIndex("dbo.CommentPostRelations", new[] { "BlogPostId" });
            DropIndex("dbo.CommentPostRelations", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Role_Id" });
            DropIndex("dbo.BlogLikes", new[] { "UserId" });
            DropIndex("dbo.BlogLikes", new[] { "BlogPostId" });
            DropColumn("dbo.Users", "Role_Id");
            DropTable("dbo.Roles");
            DropTable("dbo.BlogComments");
            DropTable("dbo.CommentPostRelations");
            DropTable("dbo.BlogLikes");
            CreateIndex("dbo.BlogPosts", "UserId");
            AddForeignKey("dbo.BlogPosts", "UserId", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
