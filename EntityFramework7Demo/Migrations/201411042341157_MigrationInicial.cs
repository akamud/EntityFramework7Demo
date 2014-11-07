using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Model;
using System;

namespace EntityFramework7Demo.Migrations
{
    public partial class MigrationInicial : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("Blog",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Url = c.String()
                    })
                .PrimaryKey("PK_Blog", t => t.BlogId);
            
            migrationBuilder.CreateTable("Post",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Title = c.String(),
                        BlogId = c.Int(nullable: false)
                    })
                .PrimaryKey("PK_Post", t => t.PostId);
            
            migrationBuilder.AddForeignKey("Post", "FK_Post_Blog_BlogId", new[] { "BlogId" }, "Blog", new[] { "BlogId" }, cascadeDelete: false);
        }
        
        public override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("Post", "FK_Post_Blog_BlogId");
            
            migrationBuilder.DropTable("Blog");
            
            migrationBuilder.DropTable("Post");
        }
    }
}